<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bc.aspx.cs" Inherits="LJSheng.Web.demo.bc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>半半情人- 抽奖编号转换表格</title>
</head>
<body>
    <br />
    <form id="form1" runat="server">
        <div style="margin-left:50px;">
            <ul style="line-height:50px;">
                <li>表格宽度:<input type="text" runat="server" id="kuan" value="500" /></li>
                <li><input type="file" runat="server" id="file" /> <asp:Button runat="server" ID="daoru" Text="自动计算并生成论坛表格数据" OnClick="daoru_Click" /></li>
                <li><textarea runat="server" id="haoma" style="width:800px; height:500px;"></textarea></li>
                <li><label runat="server" id="msg" /></li>
                <li>excel导入的表格请按一下格式,第一行为标题,第二行开始是论坛ID和回帖楼层
                    <table height="95" width="342" border="1" style="background-color:red; color:white;">
                        <tr height="19">
                            <td>论坛ID</td>
                            <td>回帖楼层</td>
                        </tr>
                        <tr height="19">
                            <td>半半情人</td>
                            <td>002</td>
                        </tr>
                        <tr height="19">
                            <td>情人一号</td>
                            <td>003</td>
                        </tr>
                    </table>
                </li>
            </ul>
        </div>
    </form>
</body>
</html>
