<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="runapi.aspx.cs" Inherits="LJSheng.Web.ljsheng.runapi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/default.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-2.1.4.min.js"></script>
    <script type="text/javascript">
        function getapi(api) {
            var list = $("#api li input");
            var json = '{';
            for(var i=0;i<list.length;i++)
            {
                json += list[i].name + ":\"" + list[i].value + "\",";
            }
            json = json.substring(0, json.length - 1) + '}';
            $("#sendjson").val(json);
            $("#url").html("URL = ffm=" + $("#apiname").html().split('(')[0]);
            $.ajax({
                url: "/ajax/api.ashx",
                data: "function=post&ffm=" + $("#apiname").html().split('(')[0] + "&json=" + json,
                type: "post",
                cache: false,
                timeout: 50000,
                dataType: "json",
                ContentType: "application/json; charset=utf-8",
                error: function () { alert("哎哦喂!这是一个BUG哦!!!"); },
                beforeSend: function () { $("#json").text("开始请求ing..."); },
                success: function (data) {
                    $("#json").val(JSON.stringify(data));
                },
            });
        }
    </script>
    <title>API请求</title>
</head>
<body>
    <form id="form1" runat="server">
 <div class="cont">
        <div class="cont2">
            <div class="opera">
                <div class="p">
                    <span class="n_d"><tt>接口名称：</tt><label id="apiname"><%= Request.QueryString["ffm"] %></label></span>
                    <span class="n_d"><tt>简介：</tt><%= Server.UrlDecode(Request.QueryString["jj"]) %></span>
                    <a class="btn2" href="javascript: getapi('<%= Request.QueryString["ffm"] %>');">请求</a>
                </div>
            </div>
            <div class="content">
                <div id="api" class="p_tab cf">
                    <ul class="p_tit cf">
                        <li>参数名</li>
                        <li>参数值</li>
                        <li>简介</li>
                    </ul>
                    <ul class="p_con">
                        <li>sjxt</li>
                        <li><input type="text" name="sjxt" value="5" /></li>
                        <li>调用的系统</li>
                    </ul>
                    <ul class="p_con">
                        <li>sjxh</li>
                        <li><input type="text" name="sjxh" value="浏览器" /></li>
                        <li>手机型号</li>
                    </ul>
                    <ul class="p_con">
                        <li>bbh</li>
                        <li><input type="text" name="bbh" value="1.00" /></li>
                        <li>APP版本号</li>
                    </ul>
                    <ul class="p_con">
                        <li>gid</li>
                        <li><input type="text" name="gid" value="" /></li>
                        <li>用户的GID</li>
                    </ul>
                    <label runat="server" id="cslist"></label>
                </div>

                <div class="n_txt">
                    <div class="n_l">
                        <h3 class="n_tit">返回数据参数</h3>
                        <div class="n_con">
                            <ul runat="server" id="rlist">
                            </ul>
                        </div>
                    </div>
                    <div class="n_r">
                        <h3 class="n_tit">返回的JSON</h3>
                        <div class="n_con">
                            <textarea runat="server" id="json" style="width:550px; height:120px;"></textarea>
                        </div>
                        <h3 class="n_tit">请求数据:<label runat="server" id="url"></label></h3>
                        <div class="n_con">
                            <textarea runat="server" id="sendjson" style="width:550px; height:60px;"></textarea>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>