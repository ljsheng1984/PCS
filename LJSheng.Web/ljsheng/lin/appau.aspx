<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="appau.aspx.cs" Inherits="LJSheng.Web.ljsheng.lin.appau" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>APP版本操作</title>
    <script type="text/javascript" src="/js/jquery-2.1.4.min.js"></script>
    <script type="text/javascript" src="/js/jquery.validate.js"></script>
    <link href="/ljsheng/css/default.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $().ready(function () {
            $("#form1").validate();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="cont">
            <table id="add">
                <tr>
                    <th>手机操作系统：</th>
                    <td>
                        <asp:RadioButtonList ID="sjRB" runat="server" BorderStyle="None" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1" Selected="True">苹果</asp:ListItem>
                            <asp:ListItem Value="2">安卓</asp:ListItem>
                            <asp:ListItem Value="3">苹果PAD</asp:ListItem>
                            <asp:ListItem Value="4">安卓PAD</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <th>当前版本号：</th>
                    <td>
                        <input type="text" runat="server" id="bbh" class="txt required" onkeyup="value=value.replace(/[^\d.]/g,'');" /></td>
                </tr>
                <tr>
                    <th>内部版本号：</th>
                    <td>
                        <input type="text" runat="server" id="nbbbh" class="txt required" onkeyup="value=value.replace(/[^\d]/g,'');" /></td>
                </tr>
                <tr>
                    <th>是否强更新：</th>
                    <td>
                        <asp:RadioButtonList ID="gxRB" runat="server" BorderStyle="None" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1" Selected="True">不是</asp:ListItem>
                            <asp:ListItem Value="2">是</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <th>提示用户更新内容：</th>
                     <td><textarea runat="server" id="gxnr" style="width:300px; height:100px;"></textarea></td>
                </tr>
                <tr>
                    <th>更新的APP地址：</th>
                    <td>
                        <input type="text" runat="server" id="url" value="http://ljsheng.qmaixuexi.com:8080/uploadfiles/app/" class="txt required" style="width:350px;" /></td>
                </tr>
                <tr>
                    <th>APP文件：</th>
                    <td><input type="file" runat="server" id="file" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button runat="server" ID="tijiao" Text="提交数据" CssClass="btn_40" OnClick="tijiao_Click" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>