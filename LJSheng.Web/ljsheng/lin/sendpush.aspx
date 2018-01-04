<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sendpush.aspx.cs" Inherits="LJSheng.Web.ljsheng.lin.sendpush" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>推送</title>
    <link type="text/css" href="/ljsheng/css/default.css" rel="stylesheet"/>
    <script type="text/javascript" src="/js/jquery-2.1.4.min.js"></script>
    <script type="text/javascript" src="/js/jquery.validate.js"></script>
    <script type="text/javascript">
        $().ready(function () {
            $("#form1").validate();
            $("#lxRB label").eq(0).click(function () {
                document.getElementById("t").innerHTML = "通知标题";
                document.getElementById("n").innerHTML = "通知内容";
                console.log("0" + $("#lxRB label").eq(0));
            });
            $("#lxRB label").eq(1).click(function () {
                document.getElementById("t").innerHTML = "网页标题";
                document.getElementById("n").innerHTML = "网页URL";
                console.log("1" + $("#lxRB label").eq(1));
            });
            $("#lxRB label").eq(2).click(function () {
                document.getElementById("t").innerHTML = "发送号码";
                document.getElementById("n").innerHTML = "短信内容";
                console.log("2" + $("#lxRB label").eq(2));
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="cont">
            <table id="add">
                <tr>
                    <th>推送类型：</th>
                    <td>
                         <asp:RadioButtonList ID="lxRB" runat="server" BorderStyle="None" RepeatDirection="Horizontal">
                            <asp:ListItem Value="0" Selected="True">通知</asp:ListItem>
                            <asp:ListItem Value="1">网页</asp:ListItem>
<%--                            <asp:ListItem Value="2">短信</asp:ListItem>--%>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <th id="t">推送标题/网页标题/发送号码：</th>
                    <td><input runat="server" id="title" class="required" /></td> 
                </tr>
                <tr>
                    <th id="n">推送内容/网页URL/短信内容：</th>
                    <td><textarea runat="server" id="nrong" style="width:300px; height:100px;" class="required"></textarea></td>
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
