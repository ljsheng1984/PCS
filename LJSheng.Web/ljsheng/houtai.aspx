<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="houtai.aspx.cs" Inherits="LJSheng.Web.ljsheng.houtai" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title>后台管理系统</title>
    <script type="text/javascript" src="/js/jquery-2.1.4.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            if (getQueryString("url") != null) {
                $("frame[name='main']").attr("src", getQueryString("url"));
            }
        });
        //获取URL参数
        function getQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return r[2]; return null;
        }
    </script>
</head >
        <frameset cols="*" rows="78, *" id="frame_main"  border="0">
  <frame src="top.aspx" noresize="noresize" name="header">
  </frame>
  <frameset cols="180, *">
    <frame src="caidan.aspx" name="left" noresize="noresize">
    </frame>
    <frameset rows="37,*" border="0">
      <frame src="title.html" name="title" noresize="noresize" scrolling="no"></frame>
      <frame src="shouye.aspx" name="main" noresize="noresize"></frame>
    </frameset>
  </frameset>
</frameset><noframes></noframes>
<body>
    <form id="form1" runat="server">
    </form>
</body>
</html>