<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hyau.aspx.cs" Inherits="LJSheng.Web.ljsheng.lin.hyau" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>会员操作</title>
    <script type="text/javascript" src="/js/jquery-2.1.4.min.js"></script>
    <script type="text/javascript" src="/js/jquery.validate.js"></script>
    <script type="text/javascript" src="/chajian/laydate/laydate.js"></script>
    <link type="text/css" href="/ljsheng/css/default.css" rel="stylesheet"/>
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
                    <th>登录帐号：</th>
                    <td>
                        <input type="text" runat="server" id="zhanghao" class="txt required" minlength="11" maxlength="11" /><em class="tip">注册的帐号</em></td>
                </tr>
                <tr>
                    <th>密码:</th>
                    <td>
                        <input type="text" runat="server" id="mima" class="txt required" minlength="6" /><em class="tip">请输入密码6-20位</em></td>
                </tr>
                <tr>
                    <th>联系方式:</th>
                    <td>
                        <input type="text" runat="server" id="shouji" class="txt" /><em class="tip">会员手机号</em></td>
                </tr>
                <tr>
                    <th>姓名：</th>
                    <td>
                        <input type="text" runat="server" id="xingming" class="txt" /><em class="tip">用户姓名</em></td>
                </tr>
                <tr>
                    <th>昵称：</th>
                    <td>
                        <input type="text" runat="server" id="nicheng" class="txt" /><em class="tip">昵称</em></td>
                </tr>
                <tr>
                    <th>头像：</th>
                    <td>
                        <input type="file" runat="server" id="tupian" /><em class="tip">用户头像</em> <img runat="server" id="fmlogo" style="width:80px;height:80px;" onerror="this.src='/ljsheng/images/nopic.png'" /></td>
                </tr>
                <tr>
                    <th>性别：</th>
                    <td>
                        <asp:RadioButtonList ID="xbRB" runat="server" BorderStyle="None" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="0">未设置</asp:ListItem>
                            <asp:ListItem Value="1">男</asp:ListItem>
                            <asp:ListItem Value="2">女</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <th>出生日期：</th>
                    <td>
                        <input runat="server" id="csrq" class="txt1" onclick="laydate({istime: true, format: 'YYYY-MM-DD'})" placeholder="年-月-日" /><em class="tip">出生日期</em></td>
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