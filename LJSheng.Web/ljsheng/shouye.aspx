<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shouye.aspx.cs" Inherits="LJSheng.Web.ljsheng.shouye" %>
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
                    <th>设置拦截标题提示 </th>
                    <td><input runat="server" id="biaoti" /><em class="tip"></em></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button runat="server" ID="ok" Text="设置" OnClick="ok_Click" /></td>
                </tr>
            </table>
            <hr />
            <div style="margin-left:50px; font-size:18px;">
                匹配规则:<p />
                防骗匹配主要在于你对每条短信的关键字提取程度匹配,<br />
                如果你当前短信匹配到一个关键字,那只要短信包含这个关键字就100%是拦截<br />
                如果是设置了2个以上的关键字,那么是每个关键字匹配的相似度总和除以几个关键字<br />
                比如 你设置了关键字  诈骗|汇款  诈骗相似度 80% 汇款相似度 60% 那就是(60%+80%)/2=70%,最后的结果稀释度大于30%就拦截.<p />
                举例:如果短信诈骗是 网址 电话 银行卡 这样的就只要输入银行 网址 电话其中一个关键字就可以了<p />
                PS:注意哦.多关键字之间用英文状态的 | 分割
                <hr />
                注意.输入的关键字最后的时候不能带 | ,还有关键字只能是数字,英文,中文的组合.不能有其他任何字符,包括空格
                <br />
                带网址 http://www.520299.com/zuoai.aspx?caoni=521555 类似这样取  www.520299.com 就是只取符号之间的
            </div>
        </div>
    </form>
</body>
</html>