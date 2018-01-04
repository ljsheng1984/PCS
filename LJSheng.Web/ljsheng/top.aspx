<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="top.aspx.cs" Inherits="LJSheng.Web.ljsheng.top" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="refresh" content="88;url=top.aspx" />
    <title>top</title>
    <link href="css/global.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">
    <div class="head">
	    <div class="hcon">
            <p>欢迎您！<strong><%= LJSheng.Common.LSession.GetJsonSession("ljsheng") %></strong> <a href="/loginout.aspx?url=/ljsheng/denglu.aspx">[ 安全退出 ]</a> <a href="shouye.aspx" target="main">后台首页</a></p>
            <div class="t_logo"><img src="images/logo.png" />防骗助手管理系统</div>
            <div class="t_menu">
                <a href="lin/lanjie.aspx" target="main"><em runat="server" id="lj">0</em>拦截</a>
                <a href="lin/jubao.aspx" target="main"><em runat="server" id="jb">0</em>举报</a>
                <a href="lin/jiance.aspx" target="main"><em runat="server" id="jc">0</em>检测</a>
                <a href="lin/jpush.aspx" target="main"><em runat="server" id="app">0</em>APP安装量</a>
                <a href="lin/appapi.aspx?ffm=appstart" target="main"><em runat="server" id="qd">0</em>启动次数</a>
                <a href="lin/yjfk.aspx" target="main"><em runat="server" id="yjfk">0</em>意见反馈</a>
            </div>
        </div>
    </div>
</form>
</body>
</html>