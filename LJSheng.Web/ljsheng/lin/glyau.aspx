<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="glyau.aspx.cs" Inherits="LJSheng.Web.ljsheng.lin.glyau" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>管理员操作</title>
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
                    <th>登录名：</th>
                    <td>
                        <input type="text" runat="server" id="zhanghao" class="txt required" minlength="3" maxlength="20" /><em class="tip">请输入登录名3-20位</em></td>
                </tr>
                <tr>
                    <th>密码：</th>
                    <td>
                        <input type="text" runat="server" id="mima" class="txt required" minlength="6" /><em class="tip">请输入密码6-20位</em></td>
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