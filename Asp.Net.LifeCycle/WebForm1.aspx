<%@ Page TraceMode="SortByTime" Trace="true" Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Asp.Net.LifeCycle.WebForm1" %>

<%@ Register TagPrefix="test" TagName="MyCtrl" Src="WebUserControl1.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
     <script src="https://code.jquery.com/jquery-2.2.4.js" integrity="sha256-iT6Q9iMJYuQiMWNd9lDyBUStIq/8PuOW33aOqmvFpqI=" crossorigin="anonymous"></script>
    <link href="https://cdn.bootcss.com/bootstrap/3.3.5/css/bootstrap.css" rel="stylesheet" />
    <script src="https://cdn.bootcss.com/bootstrap/3.3.5/js/bootstrap.js"></script> 
    <script type="text/javascript">
        $(document).ready(function() {
            $("#skinChange").change(function () {
                var theme = $(this).val();
                var url = window.location.href.replace(/[?].*$/g, "");//获取去处两边空格之后当前url             
                if (url.indexOf("?") === -1) { //查找？的索引位置  
                    url += "?theme=" + theme;
                } else if (url.indexOf("?") === url.length - 1) {
                    url += "theme=" + theme;
                } else {
                    url += "&theme=" + theme;
                }
                window.location = url;//重新加载当前页  
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div>
                <select id="skinChange" runat="server">
                    <option value="Skin1">Skin1</option>
                    <option value="Skin2">Skin2</option>
                </select>
            </div>
            <div class="col-lg-4 md-lg-4">
                <test:MyCtrl runat="server" ID="MyControl"></test:MyCtrl>
            </div>
            <div class="col-lg-4 md-lg-4">
                <table>
                    <thead>
                        <tr>
                            <th>Page事件（阶段)</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="eventRepeater" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%#Container.DataItem%></td>
                                </tr>
                            </ItemTemplate>

                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
            <div class="col-lg-4 md-lg-4">
                <table>
                    <thead>
                        <tr>
                            <th>Page&Control事件（阶段)</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="eventRepeaterAll" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%#Container.DataItem%></td>
                                </tr>
                            </ItemTemplate>

                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
