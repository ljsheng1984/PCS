<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dbbak.aspx.cs" Inherits="LJSheng.Web.ljsheng.dbbak" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>数据库备份</title>
    <link type="text/css" rel="stylesheet" href="/ljsheng/css/default.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="cont">
            <div class="cont2">
                <div class="opera">
                   <p>
                        <img src="/ljsheng/images/16.png" /><asp:Button runat="server" ID="bf" CssClass="btn1" Text="手动备份" OnClick="bf_Click" />
                   </p>
                </div>
                <div class="content">
                    <asp:ListView ID="LVljsheng" runat="server" OnItemCommand="LVljsheng_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="name" runat="server" Text='<%# Eval("name") %>' />
                                </td>
                                <td>
                                    <%#Eval("CreationTime")%>
                                </td>
                                <td>
                                     <asp:Button ID="del" runat="server" Text="删除" CssClass="btn2" CommandName="del" OnClientClick="return confirm('确定删除吗？');" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <div>当前没有符合条件的数据</div>
                        </EmptyDataTemplate>
                        <LayoutTemplate>
                            <table id="list" border="1">
                                <tr runat="server" id="itemPlaceholderContainer">
                                    <th>备份文件名</th>
                                    <th>备份时间</th>
                                    <th>操作</th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </LayoutTemplate>
                    </asp:ListView>
                </div>
            </div>
        </div>
        <script type="text/javascript" src="/ljsheng/js/tab.js"></script>
    </form>
</body>
</html>
