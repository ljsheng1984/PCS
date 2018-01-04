<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="denglu.aspx.cs" Inherits="LJSheng.Web.ljsheng.denglu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>后台管理系统</title>
    <script type="text/javascript" src="/js/jquery-2.1.4.min.js"></script>
    <script type="text/javascript" src="js/cloud.js"></script>
    <link href="css/global.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
	    $(function(){
            $('.loginbox').css({'position':'absolute','left':($(window).width()-692)/2});
	        $(window).resize(function(){  
                $('.loginbox').css({'position':'absolute','left':($(window).width()-692)/2});
            })  
	    });  
    </script>
</head>
<body style="background-color:#1c77ac; background-image:url(images/light.png); background-repeat:no-repeat; background-position:center top; overflow:hidden;">
    <form id="form1" runat="server">
    <div id="mainBody">
      <div id="cloud1" class="cloud"></div>
      <div id="cloud2" class="cloud"></div>
    </div>  
    <div class="logintop">    
    <span>欢迎登录后台管理界面平台</span>    
    <ul>
    <li><a href="#">回首页</a></li>
    </ul>    
    </div>
    <div class="loginbody">
        <span class="systemlogo"></span> 
        <div class="loginbox loginbox1">
        <ul>
        <li><input runat="server" id="zhanghao" type="text" class="loginuser" value="用户名"  minlength="3" maxlength="20" onclick="JavaScript:this.value=''"/></li>
        <li><input runat="server" id="mima" type="password" class="loginpwd" value="密码"  minlength="6" maxlength="20" onclick="JavaScript:this.value=''"/></li>
        <%--<li class="yzm">
        <span><input id="yzm" type="text" value="验证码" onclick="JavaScript:this.value=''"/></span>8888
        </li>--%>
        <li><asp:Button runat="server" ID="dl" Text="登录" class="loginbtn" OnClick="dl_Click" /><label><asp:CheckBox runat="server" ID="bcdl" />保持登录</label></li>
        </ul>
        </div>
    </div>
    <div class="loginbm">半半工作室 版权所有</div>
    </form>
</body>
</html>