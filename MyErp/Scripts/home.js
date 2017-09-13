//获取菜单
$(function () {
    // $.getJSON("/Admin/LoadMenuData", { channelID: "6fabd404-9d79-42a2-a98d-a4b0eb607812" },  这个你自己要重写了。MVC 的Action返回一个json，就是菜单要的数据了。
    $.getJSON("/data/menu.json",
        function (data) {
            $.each(data,
                function (i, item) {
                    var groupInfo = item;
                    var strMenuItemHTML = "";
                    $.each(item.MenuItems,
                        function (j, menu) { //font-weight:bold
                            strMenuItemHTML +=
                                '<a href="#" style="width:100px;height:100px;" class="easyui-linkbutton" data-options="iconCls:\'icon-large-picture\',size:\'large\',iconAlign:\'top\',plain:\'true\'" src="' + menu.Src + '" onclick="addTab(this)">' + menu.MenuName + '</a>';

                        });
                    $("#menus").accordion('add',
                    {
                        title: groupInfo.GroupName,
                        content: strMenuItemHTML,
                        selected: false
                    });
                });
            addHomeTab();
        });
});

function addHomeTab() {
    var title = "欢迎页";
    var src = "Welcome.html";
    createtabs();
    var strHtml = '<iframe id="frame" width="100%" height="99%" frameborder="0" scrolling="yes" src="' + src + '"></iframe>';
    //判断Tab标签中是否有相同的数据标签
    var isExist = $("#tabs").tabs('exists', "主页");
    if (!isExist) {
        $('#tabs').tabs('add', {
            title: title,
            fit: true,
            content: strHtml,
            closable: false
        });
    }
    else {
        $('#tabs').tabs('select', title);
    }
}

var addTab = function (obj) {
    var menuItem = $(obj);
    var title = menuItem.text();
    var src = menuItem.attr("src");
    createtabs();
    var strHtml = '<iframe id="frame" width="100%" height="100%" frameborder="0" scrolling="yes" src="' + src + '"></iframe>';
    //判断Tab标签中是否有相同的数据标签
    var isExist = $("#tabs").tabs('exists', title);
    if (!isExist) {
        $('#tabs').tabs('add', {
            title: title,
            fit: true,
            content: strHtml,
            closable: true
        });
    }
    else {
        $('#tabs').tabs('select', title);
    }
}

var createtabs = function () {
    if ($("#tabs").length > 0) {
        $("#tabs").show();
        return;
    }
    $("#main").html('<div id="tabs"></div>');
    $('#tabs').tabs({
        border: false,
        fit: true,
        onClose: clearTabs
    });
}
var clearTabs = function () {
    if ($('#tabs').tabs("tabs").length === 0) {
        $("#tabs").hide();
    }
}