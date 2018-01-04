<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zhibo.aspx.cs" Inherits="LJSheng.Web.zhibo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:CheckBox ID="lmcb" runat="server" Text="连码" /><br /><br />
        <asp:CheckBox ID="zjcb" runat="server" Text="证件" /><br /><br />
        <asp:CheckBox ID="phbcb" runat="server" Text="排行榜" /><br /><br />
        <asp:CheckBox ID="cjcb" runat="server" Text="抽奖" /><br /><br />
        <asp:CheckBox ID="xqcb" runat="server" Text="相亲" /><br /><br />
        <asp:CheckBox ID="pkcb" runat="server" Text="PK对战" /><br /><br />
        <asp:CheckBox ID="xqpkcb" runat="server" Text="相亲PK" /><br /><br />
        <asp:CheckBox ID="spxqcb" runat="server" Text="视频相亲" /><br /><br />
        <asp:Button runat="server" ID="zhuce" Text="关闭页面" OnClick="zhuce_Click" Visible="false" />
    </form>
</body>
</html>
