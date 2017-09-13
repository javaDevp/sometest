<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Asp.Net.LifeCycle.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="txtEmail" ID="RequiredFieldValidator1" runat="server" ErrorMessage="必须填写电子邮件地址。" Text="*" ValidationGroup="allValidators"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ControlToValidate="txtEmail" ID="RegularExpressionValidator1" runat="server" ErrorMessage="电子邮件地址必须采用 name@domain.xyz 格式。" Text="无效的格式!" ValidationGroup="allValidators" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <asp:TextBox ID="txtNumberInParty" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtPreferedDate" runat="server"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_OnClick" Text="Submit" ValidationGroup="allValidators" />
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
