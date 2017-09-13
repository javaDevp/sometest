<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Login</title>
    <link rel="stylesheet" type="text/css" href="Scripts/themes/default/easyui.css">
    <link rel="stylesheet" type="text/css" href="Scripts/themes/icon.css">
    <script type="text/javascript" src="Scripts/jquery.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.easyui.min.js"></script>
    <link rel="stylesheet" type="text/css" href="css/style.css">
</head>
<body>
    <div id="loginDlg" class="easyui-dialog" title="登录窗口" data-options="iconCls:'icon-lock'" style="width: 400px; height: 300px;">
        <h2>MyErp</h2>
        <form>
            <table style="height: 100%">
                <tr>
                    <td rowspan="2">
                        <img src='..' /></td>
                    <td>
                        <input id="username" class="easyui-textbox" data-options="required:true,prompt:'用户名',iconCls:'icon-man',iconWidth:38" /></td>
                </tr>
                <tr>
                    <td>
                        <input id="password" class="easyui-textbox" type="password" data-options="required:true,prompt:'密码',iconCls:'icon-lock',iconWidth:38"></td>
                </tr>
                <tr style="height: 25px">
                    <td colspan="2" style="background-color: #f3f3f3">
                        <a href="#" class="easyui-linkbutton" iconcls="icon-lock">登录</a>
                        <a href="#" class="easyui-linkbutton" iconcls="icon-reload">重置</a>
                    </td>
                </tr>
            </table>
        </form>
    </div>
</body>
</html>
