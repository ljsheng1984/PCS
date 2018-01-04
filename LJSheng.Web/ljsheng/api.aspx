<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="api.aspx.cs" Inherits="LJSheng.Web.ljsheng.api" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/default.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-2.1.4.min.js"></script>
    <script type="text/javascript" src="/chajian/layer/layer.js"></script>
    <script type="text/javascript" src="/js/ljsheng.js"></script>
    <title>API调试</title>
</head>
<body>
    <form id="form1" runat="server">
<div class="cont">
  <div class="cont2">
    <div class="tbar">
    <div class="tbar_con">
        接口地址：http://内外网地址/api.ashx  <br />
        http请求URL参数：ffm=API名称<br />
        http请求POST参数：param=参数字符串,格式为json的字符串<br />
        参数字符串：所有的接口都传sjxt[1=苹果 2=安卓 3=苹果PAD 4=安卓PAD 5=WEB]=手机系统,sjxh=手机型号,bbh=APP版本号,gid=用户的GID<br />
        具体需要传递的参数，点击调用查看。<br />
        返回值的基本结构是{"code":200,"msg":"200是调用成功","data":{}}<br />
        code：<br />
        Success = 200,//访问成功<br />
        ParameterError = 400,//参数错误<br />
        Error = 500,//自定义错误<br />
    </div>
    </div>
    <div class="content">
     <div class="p_tab p2 cf">
        <ul class="p_tit cf">
            <li>方法名称</li>
            <li>方法说明</li>
            <li>技术人员</li>
            <li>调用</li>
        </ul>
         <%= getff() %>
</div>
    </div>
  </div>
</div>
    </form>
</body>
</html>
