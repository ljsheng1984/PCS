<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dxau.aspx.cs" Inherits="LJSheng.Web.ljsheng.lin.dxau" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>ljsheng</title>
    <script type="text/javascript" src="/js/jquery-2.1.4.min.js"></script>
    <script type="text/javascript" src="/js/jquery.validate.js"></script>
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
                    <th>短信内容：</th>
                    <td>
                        <textarea runat="server" id="duanxin" style="width:300px; height:100px;"></textarea><em class="tip">防骗短信内容</em></td>
                </tr>
                <tr>
                    <th>防骗关键字：</th>
                    <td>
                        <input type="text" runat="server" id="gjz" class="txt" style="width:500px;" minlength="2" maxlength="500" /><em class="tip">多个关键字用英文 | 分开</em></td>
                </tr>
                <tr style="display:none;">
                    <th>危害程度：</th>
                    <td>
                        <input type="text" runat="server" value="50" id="weihai" class="txt" onkeyup="value=value.replace(/[^\d]/g,'');" /><em class="tip"></em></td>
                </tr>
<%--                 <tr>
                    <th>受骗人数：</th>
                    <td>
                        <input type="text" runat="server" value="0" id="cishu" class="txt" onkeyup="value=value.replace(/[^\d]/g,'');" /><em class="tip"></em></td>
                </tr>--%>
                 <tr>
                    <th>短信类型：</th>
                    <td>
                        <asp:RadioButtonList ID="lxRB" runat="server" BorderStyle="None" RepeatDirection="Horizontal">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                 <tr>
                    <th>是否启用：</th>
                    <td>
                        <asp:RadioButtonList ID="ztRB" runat="server" BorderStyle="None" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1" Selected="True">启用</asp:ListItem>
                            <asp:ListItem Value="2">不启用</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
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
