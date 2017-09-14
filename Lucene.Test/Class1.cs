using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.PanGu;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using NUnit.Framework;
using Directory = Lucene.Net.Store.Directory;
using Version = Lucene.Net.Util.Version;

namespace Lucene.Test
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void RunnableTokenStreamTest()
        {
            List<Analyzer> analysis = new List<Analyzer>() { 
                new KeywordAnalyzer(),
                new SimpleAnalyzer(),
                new StandardAnalyzer(Version.LUCENE_20, new HashSet<string>(){" "}),
                new StopAnalyzer(Version.LUCENE_20, new HashSet<string>(){" "}),
                new WhitespaceAnalyzer()
                };
            foreach (var analy in analysis)
            {
                Console.WriteLine("======={0}========", analy.GetType().Name);
                TestFactory.TestFunc(analy);

            }
        }

        [Test]
        public void EasyAnylyzerTest()
        {
            //TestFactory.TestFunc(new EasyAnalyzer());
            TestFactory.TestFunc(new MyCharAnalyzer());
        }

        /// <summary>
        /// 执行测试的入口
        /// </summary>
        [Test]
        public void SearcherTest()
        {
            Index();
            List<string> list = new List<string>() { "中华", "中国", "人民", "中国人民", "人民" };
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("搜索词：" + list[i]);
                Console.WriteLine("结果：");
                Searcher(list[i]);
                Console.WriteLine("-----------------------------------");
            }
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="querystring">搜索输入</param>
        private void Searcher(string querystring)
        {
            Analyzer analyzer = new StandardAnalyzer(Version.LUCENE_30);
            Directory directory = new SimpleFSDirectory(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "IndexDirectory"));
            IndexSearcher searcher = new IndexSearcher(directory);
            QueryParser parser = new QueryParser(Version.LUCENE_30, "content", analyzer);
            Query query = parser.Parse(querystring);
            //TopScoreDocCollector盛放查询结果的容器
            TopScoreDocCollector collector = TopScoreDocCollector.Create(1000, true);
            searcher.Search(query, null, collector);
            //TopDocs 指定0到GetTotalHits() 即所有查询结果中的文档 如果TopDocs(20,10)则意味着获取第20-30之间文档内容 达到分页的效果
            ScoreDoc[] docs = collector.TopDocs(0, collector.TotalHits).ScoreDocs;
            for (int i = 0; i < docs.Length; i++)
            {
                int docId = docs[i].Doc;//得到查询结果文档的id（Lucene内部分配的id）
                Document doc = searcher.Doc(docId);//根据文档id来获得文档对象Document
                Console.WriteLine(doc.Get("content"));
            }
        }

        /// <summary>
        /// 索引数据
        /// </summary>
        private void Index()
        {
            Analyzer analyzer = new StandardAnalyzer(Version.LUCENE_30);
            Directory directory = new SimpleFSDirectory(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "IndexDirectory"));
            bool isExist = IndexReader.IndexExists(directory);
            IndexWriter writer = new IndexWriter(directory, analyzer, !isExist, IndexWriter.MaxFieldLength.UNLIMITED);
            AddDocument(writer, "中华人民共和国");
            AddDocument(writer, "中国人民解放军");
            AddDocument(writer, "人民是伟大的，祖国是伟大的。");
            AddDocument(writer, "你站在边上，我站在中央。");
            writer.Optimize();
            writer.Close();
        }
        /// <summary>
        /// 为索引准备数据
        /// </summary>
        /// <param name="writer">索引实例</param>
        /// <param name="content">需要索引的数据</param>
        void AddDocument(IndexWriter writer, string content)
        {
            Document document = new Document();
            document.Add(new Field("content", content, Field.Store.YES, Field.Index.ANALYZED));
            writer.AddDocument(document);
        }
    }
}
