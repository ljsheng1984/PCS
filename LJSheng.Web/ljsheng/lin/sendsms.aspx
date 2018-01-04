<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sendsms.aspx.cs" Inherits="LJSheng.Web.ljsheng.lin.sendsms" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>推送</title>
    <link type="text/css" href="/ljsheng/css/default.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="cont">
            <table id="add">
                <tr>
                    <th>发送号码</th>
                    <td><input runat="server" id="zhanghao" /> </td>
                </tr>
                <tr>
                    <th>短信内容：</th>
                    <td><textarea runat="server" id="nrong" style="width:300px; height:100px;"></textarea></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button runat="server" ID="tijiao" Text="发送" CssClass="btn_40" OnClick="tijiao_Click" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
