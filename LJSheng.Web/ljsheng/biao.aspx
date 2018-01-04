<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="biao.aspx.cs" Inherits="LJSheng.Web.ljsheng.biao" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>数据字典</title>
</head>
<body style="">
    <form id="form1" runat="server">
        <%=LJSheng.Data.DBtoFile.DBToHtml("pcs",Guid.Parse("6A4588A2-D2E6-4FEC-B91A-978E944D5841")) %>
    </form>
</body>
</html>
