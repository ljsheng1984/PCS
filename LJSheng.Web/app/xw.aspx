<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xw.aspx.cs" Inherits="LJSheng.Web.app.xw" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, minimum-scale=1.0, maximum-scale=1.0" />
    <title></title>
    <link href="/css/index.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrap">
            <div class="title">
                <h1 id="t"><label runat="server" id="biaoti"></label></h1>
                <p><em runat="server" id="shijian"></em>来源：<label runat="server" id="laiyuan"></label></p>
            </div>
            <div class="artical">
                <div class="content" runat="server" id="nrong">
                    
                </div>
            </div>
            <div class="artical">
                <ul>
                    <li>下载防骗助手</li>
                    <li><a href="http://www.fpzs110.com/"><img src="/images/fpzs.png" width="150" height="150" /></a></li>
                </ul>
                <ul>
                    <li>&nbsp;&nbsp;&nbsp;&nbsp;关注微信号</li>
                    <li><img src="/images/weixin.jpg" width="150" height="150" /></li>
                </ul>
            </div>
        </div>
        <script type="text/javascript">
        //检测浏览器语言 - 我爱你爱久久 - 520299.com
        currentLang = navigator.language;   //判断除IE外其他浏览器使用语言
        if (!currentLang) {//判断IE浏览器使用语言
            currentLang = navigator.browserLanguage;
        }
        //判断访问终端 - 我爱你爱久久 - 520299.com
        var browser = {
            versions: function () {
                var u = navigator.userAgent, app = navigator.appVersion;
                return {
                    trident: u.indexOf('Trident') > -1, //IE内核
                    presto: u.indexOf('Presto') > -1, //opera内核
                    webKit: u.indexOf('AppleWebKit') > -1, //苹果、谷歌内核
                    gecko: u.indexOf('Gecko') > -1 && u.indexOf('KHTML') == -1,//火狐内核
                    mobile: !!u.match(/AppleWebKit.*Mobile.*/), //是否为移动终端
                    ios: !!u.match(/\(i[^;]+;( U;)? CPU.+Mac OS X/), //ios终端
                    android: u.indexOf('Android') > -1 || u.indexOf('Linux') > -1, //android终端或者uc浏览器
                    iPhone: u.indexOf('iPhone') > -1, //是否为iPhone或者QQHD浏览器
                    iPad: u.indexOf('iPad') > -1, //是否iPad
                    webApp: u.indexOf('Safari') == -1 //是否web应该程序，没有头部与底部
                };
            }(),
            language: (navigator.browserLanguage || navigator.language).toLowerCase()
        }
        if (browser.versions.webApp == true) {
            document.getElementById("t").style.display = "none";
        }
    </script>
    </form>
</body>
</html>
