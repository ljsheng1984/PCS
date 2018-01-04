<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jcxq.aspx.cs" Inherits="LJSheng.Web.weixin.jcxq" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="initial-scale=1,maximum-scale=1, minimum-scale=1" />
    <link href="/css/jiance.css" rel="stylesheet" type="text/css" />
    <title>检测详情</title>
</head>
<body style="background: #eee; margin: 0;">
    <form id="form1" runat="server">
        <div class="containner" style="padding: .2rem;">
            <div class="t1">
                <p class="lj">已成功拦截诈骗短信：<b runat="server" id="ljdx"></b>条</p>
                <div class="d1">
                    <p class="mess">
                        <%= Server.HtmlDecode(Request.QueryString["nr"]) %>
                    </p>
                    <small runat="server" id="sj"></small>
                    <p class="line"></p>
                    <div class="cx">
                        <div class="li"><span style="float: left;">类型：<b><%= Server.HtmlDecode(Request.QueryString["dxlx"]) %></b></span></div>
                        <div class="li"><span style="float: left;">相似度：<b><%= Request.QueryString["xsd"] %>%</b></span><span style="float: right;">危害度：<b><%= Request.QueryString["xsd"] %>%</b></span></div>
                    </div>
                </div>
            </div>
            <div class="t2">
                <p class="tit tit2">相似案例</p>
                <div class="t_list t_list2">
                    <ul runat="server" id="anli"></ul>
                </div>
            </div>
        </div>
        <script>
            window.onload = window.onresize = function () {
                var deviceWidth = document.documentElement.clientWidth;
                if (deviceWidth > 640) deviceWidth = 640;//根据设计图640可调
                document.documentElement.style.fontSize = deviceWidth / 6.4 + 'px';
            }
        </script>
    </form>
</body>
</html>
