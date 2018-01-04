<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xinwenau.aspx.cs" Inherits="LJSheng.Web.ljsheng.lin.xinwenau" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新闻添加</title>
    <script type="text/javascript" src="/js/jquery-2.1.4.min.js"></script>
    <script type="text/javascript" src="/js/jquery.validate.js"></script>
    <script type="text/javascript" charset="utf-8" src="/chajian/umeditor/umeditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="/chajian/umeditor/umeditor.min.js"></script>
    <link type="text/css" href="/chajian/umeditor/themes/default/css/umeditor.css" rel="stylesheet" />
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
                    <th>标题：</th>
                    <td>
                        <input type="text" runat="server" id="biaoti" class="txt required" minlength="2" maxlength="200" /><em class="tip"></em></td>
                </tr>
                <tr>
                    <th>副标题：</th>
                    <td>
                        <textarea runat="server" id="fubiao" style="width:300px; height:100px;" maxlength="500" ></textarea><em class="tip">不要超过500字</em></td>
                </tr>
                <tr>
                    <th>封面：</th>
                    <td><input type="file" runat="server" id="tupian" /><em class="tip">封面</em> <img runat="server" id="fmlogo" style="width:80px;height:80px;" onerror="this.src='/ljsheng/images/nopic.png'" /></td>
                </tr>
                <tr>
                    <th>外部链接：</th>
                    <td>
                        <input type="text" runat="server" id="url" class="txt" minlength="10" maxlength="200" /><em class="tip">为空的话显示下面的内容</em></td>
                </tr>
                <tr>
                    <th>正文：</th>
                    <td>
                        <script type="text/plain" id="nrong" style="width: 800px; height: 240px;">
                            <p><% = nrong %></p>
                        </script>
                    </td>
                </tr>
                <tr>
                    <th>来源：</th>
                    <td>
                        <input type="text" runat="server" id="laiyuan" value="网络" class="txt" minlength="2" maxlength="100" /><em class="tip"></em></td>
                </tr>
                <tr>
                    <th>作者：</th>
                    <td>
                        <input type="text" runat="server" id="zuozhe" value="防骗助手" class="txt" minlength="2" maxlength="50" /><em class="tip"></em></td>
                </tr>
                <tr>
                    <th>排序：</th>
                    <td>
                        <input type="text" runat="server" value="0" id="px" class="txt" onkeyup="value=value.replace(/[^\d.]/g,'');" /><em class="tip">排序</em></td>
                </tr>
                 <tr>
                    <th>访问量：</th>
                    <td>
                        <input type="text" runat="server" value="0" id="fwl" class="txt" onkeyup="value=value.replace(/[^\d.]/g,'');" /><em class="tip">访问量</em></td>
                </tr>
                 <tr>
                    <th>是否显示：</th>
                    <td>
                        <asp:RadioButtonList ID="xsRB" runat="server" BorderStyle="None" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1" Selected="True">显示</asp:ListItem>
                            <asp:ListItem Value="2">不显示</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button runat="server" ID="tijiao" Text="提交数据" CssClass="btn_40" OnClick="tijiao_Click" /></td>
                </tr>
            </table>
        </div>
        <script type="text/javascript">
            //实例化编辑器
            var um = UM.getEditor('nrong');
        </script>
    </form>
</body>
</html>