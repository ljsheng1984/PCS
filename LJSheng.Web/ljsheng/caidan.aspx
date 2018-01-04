<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="caidan.aspx.cs" Inherits="LJSheng.Web.ljsheng.caidan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>菜单</title>
    <script type="text/javascript" src="/js/jquery-2.1.4.min.js"></script>
    <link type="text/css" href="css/global.css" rel="stylesheet" />
    <style type="text/css">
        html {
            height: 100%;
        }

        body {
            height: 100%;
            background: #eee;
            border-right: 1px solid #ddd;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="menu" id="menu" runat="server">
            <h2><img src="images/01.png" />管理员</h2>
            <ul>
                <li><a href="lin/glylist.aspx" target="main">管理员管理</a></li>
                <li><a href="lin/glyau.aspx" target="main">添加管理员</a></li>
            </ul>
            <h2><img src="images/02.png" />会员系统</h2>
            <ul>
                <li><a href="lin/hylist.aspx" target="main">会员管理</a></li>
                <li><a href="lin/hyau.aspx" target="main">会员添加</a></li>
            </ul>
            <h2>
                <img src="images/03.png" />APP相关</h2>
            <ul>
                <li><a href="lin/applist.aspx" target="main">APP版本管理</a></li>
                <li><a href="lin/appau.aspx" target="main">添加APP版本</a></li>
                <li><a href="lin/appapi.aspx?ffm=appstart" target="main">APP启动</a></li>
            </ul>
            <h2>
                <img src="images/14.png" />特号管理</h2>
            <ul>
                <li><a href="lin/mclist.aspx" target="main">号码管理</a></li>
                <li><a href="lin/mcau.aspx" target="main">号码添加</a></li>
            </ul>
            <h2>
                <img src="images/03.png" />拦截管理</h2>
            <ul>
                <li><a href="lin/lanjie.aspx" target="main">拦截记录</a></li>
            </ul>
            <h2>
                <img src="images/04.png" />防骗短信</h2>
            <ul>
                <li><a href="lin/dxlist.aspx" target="main">短信管理</a></li>
                <li><a href="lin/dxau.aspx" target="main">短信添加</a></li>
            </ul>
<%--            <h2>
                <img src="images/05.png" />防骗银行卡</h2>
            <ul>
                <li><a href="lin/yhklist.aspx" target="main">银行卡管理</a></li>
                <li><a href="lin/yhkau.aspx" target="main">银行卡添加</a></li>
            </ul>
            <h2>
                <img src="images/02.png" />防骗电话</h2>
             <ul>
                <li><a href="lin/dhlist.aspx" target="main">电话管理</a></li>
                <li><a href="lin/dhau.aspx" target="main">电话添加</a></li>
            </ul>
            <h2>
                <img src="images/06.png" />防骗网站</h2>
             <ul>
                <li><a href="lin/weblist.aspx" target="main">网站管理</a></li>
                <li><a href="lin/webau.aspx" target="main">网站添加</a></li>
            </ul>--%>
            <h2>
                <img src="images/11.png" />新闻资讯</h2>
            <ul>
                <li><a href="lin/xinwenlist.aspx" target="main">新闻管理</a></li>
                <li><a href="lin/xinwenau.aspx" target="main">新闻添加</a></li>
            </ul>
            <h2>
                <img src="images/09.png" />微信系统</h2>
            <ul>
                <li><a href="lin/gjzlist.aspx" target="main">关键字管理</a></li>
                <li><a href="lin/gjzau.aspx" target="main">关键字添加</a></li>
            </ul>
            <h2>
                <img src="images/02.png" />微信活动</h2>
            <ul>
                <li><a href="lin/zfhdlist.aspx" target="main">转发活动</a></li>
                <li><a href="lin/jbhdlist.aspx" target="main">举报活动</a></li>
                <li><a href="lin/huodong.aspx" target="main">活动统计</a></li>
            </ul>
            <h2>
                <img src="images/07.png" />检测举报</h2>
            <ul>
                <li><a href="lin/jiance.aspx" target="main">检测管理</a></li>
                <li><a href="lin/jubao.aspx" target="main">举报管理</a></li>
            </ul>
             <h2>
                <img src="images/10.png" />推送管理</h2>
            <ul>
                <li><a href="lin/jpush.aspx?lx=0" target="main">手机推送用户</a></li>
                <li><a href="lin/tuisong.aspx?lx=0" target="main">手机推送管理</a></li>
            </ul>
            <h2>
                <img src="images/08.png" />系统管理</h2>
            <ul>
                <li><a href="lin/zidian.aspx" target="main">字典管理</a></li>
                <li><a href="lin/yjfk.aspx" target="main">意见反馈</a></li>
            </ul>
            <h2>
                <img src="images/12.png" />开发帮助</h2>
            <ul>
                <li><a href="/ljsheng/api.aspx" target="main">接口调试</a></li>
                <li><a href="/ljsheng/biao.aspx" target="main">数据库结构</a></li>
                <li><a href="/ljsheng/dbbak.aspx" target="main">数据库备份</a></li>
                <li><a href="/ljsheng/lin/appapi.aspx" target="main">API统计</a></li>
                <li><a href="/ljsheng/lin/apibug.aspx" target="main">APIBUG</a></li>
                <li><a href="/ljsheng/lin/apibug.aspx?ffm=安卓" target="main">安卓BUG</a></li>
                <li><a href="/ljsheng/lin/apibug.aspx?ffm=苹果" target="main">苹果BUG</a></li>
            </ul>
        </div>
        <script type="text/javascript">
            $(".menu h2").click(function () {
                $(this).next("ul").slideToggle(300).siblings("ul").slideUp(400);
                $(this).addClass("hover").siblings().removeClass("hover");
            })
            $(".menu a").click(function () {
                $(".menu a").removeClass("cur"); $(this).addClass("cur");
                $(window.parent.frames["title"].document).find('span').html($(this).html()).end().find('em').html($(this).parents("ul").prev().text());
                $(window.parent.frames["main"].document).find('html').html('').css({ "background": "#fff url(/ljsheng/images/loading.gif) center center no-repeat", "height": "100%" });//图片路径注意
            })

        </script>
    </form>
</body>
</html>