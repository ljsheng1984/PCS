<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jiance.aspx.cs" Inherits="LJSheng.Web.weixin.jiance" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="initial-scale=1,maximum-scale=1, minimum-scale=1" />
    <script src="/js/jquery-2.1.4.min.js"></script>
    <script type="text/javascript" src="/chajian/layer/layer.js"></script>
    <script type="text/javascript" src="/js/ljsheng.js"></script>
    <link href="/css/jiance.css" rel="stylesheet" type="text/css" />
    <title>检测举报</title>
    <script type="text/javascript">
        function jiance()
        {
            if (document.getElementById("nr").value.length < 5) {
                layer.alert('内容太少了', { icon: 6 });
            }
            else {
                $.ajax({
                    url: "/ajax/api.ashx",
                    data: "function=jiance&nr=" + encodeURI($("#nr").val()),
                    type: "post",
                    cache: false,
                    timeout: 50000,
                    dataType: "text",
                    ContentType: "text/xml ",
                    error: function () { layer.alert('BUG哦', { icon: 6 }); },
                    beforeSend: function () {  },
                    success: function (data) {
                        if (data.length > 18)
                        {
                            location.href = data;
                        }
                        else
                        {
                            layer.alert(data, { icon: 6 });
                        }
                    },
                });
            }
        }

        function jubao() {
            if (document.getElementById("nr").value.length < 5) {
                layer.alert('内容太少了', { icon: 6 });
            }
            else {
                $.ajax({
                    url: "/ajax/api.ashx",
                    data: "function=jubao&nr=" + encodeURI($("#nr").val()),
                    type: "post",
                    cache: false,
                    timeout: 50000,
                    dataType: "text",
                    error: function () { layer.alert('BUG哦', { icon: 6 }); },
                    beforeSend: function () { },
                    success: function (data) {
                        layer.alert(data, { icon: 6 });
                    },
                });
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="containner">
            <div class="form">
                <div class="f_inner">
                    <textarea runat="server" id="nr" class="txt"></textarea>
                    <input type="button" id="jc" class="btn l" value="检测" onclick="jiance();" />
                    <input type="button" id="jb" class="btn r" value="举报" onclick="jubao();" />
<%--                    <asp:Button runat="server" ID="jc" Text="检测" CssClass="btn l" OnClick="jc_Click" OnClientClick="return ck();" />
                    <asp:Button runat="server" ID="jb" Text="举报" CssClass="btn r" OnClick="jb_Click" OnClientClick="return ck();" />--%>
                </div>
            </div>
            <p class="tit">历史记录检测</p>
            <div class="t_list">
                <ul runat="server" id="lsjl">

                </ul>
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
