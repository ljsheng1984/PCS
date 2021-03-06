﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gjzlist.aspx.cs" Inherits="LJSheng.Web.ljsheng.gjzlist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>管理员管理</title>
    <link type="text/css" rel="stylesheet" href="/ljsheng/css/default.css" />
    <script type="text/javascript" src="/chajian/laydate/laydate.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="cont">
            <div class="cont2">
                <div class="opera">
                    <p>
                        <img src="../images/16.png" />
                        关键字/回复内容：<input type="text" id="gjz" runat="server" class="txt1" />
                        日期:<input runat="server" id="kssj" class="txt1" style="width:80px;" onclick="laydate({istime: true, format: 'YYYY-MM-DD'})" placeholder="年-月-日" /> - <input runat="server" id="jssj" class="txt1" style="width:80px;" onclick="laydate({istime: true, format: 'YYYY-MM-DD'})" placeholder="年-月-日" />
                        <asp:Button runat="server" ID="sel" CssClass="btn1" Text="搜索" OnClick="sel_Click" />
                    </p>
                </div>
                <div class="content">
                    <asp:ListView ID="LVljsheng" runat="server" OnItemCommand="LVljsheng_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("gjz")%><asp:Label ID="gid" runat="server" Text='<%# Eval("gid") %>' Visible="false" /></td>
                                <td><%# Eval("lx").ToString() == "2" ?Eval("huifu") : "<b style=\"color:Red\">图文消息类型<b />"%></td>
                                <td>
                                    <%# DateTime.Parse(Eval("rukusj").ToString()).ToString("yyyy-MM-dd HH:mm")%>
                                </td>
                                <td><a href='gjzau.aspx?gid=<%#Eval("gid") %>'>修改</a> | <asp:Button ID="del" runat="server" Text="删除" CssClass="btn2" CommandName="del" OnClientClick="return confirm('确定删除吗？');" /></td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <div>当前没有符合条件的数据</div>
                        </EmptyDataTemplate>
                        <LayoutTemplate>
                            <table id="list" border="1">
                                <tr runat="server" id="itemPlaceholderContainer">
                                    <th>关键字</th>
                                    <th>回复内容</th>
                                    <th>增加时间</th>
                                    <th>操作</th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </LayoutTemplate>
                    </asp:ListView>
                    <div class="page">
                        <%= string.Format("共<span style='color:#3399FF'>{0}</span>条记录 &nbsp;每页显示<span style='color:#3399FF'>{1}</span>条 &nbsp;共<span style='color:#3399FF'>{2}</span>页 &nbsp;当前第<span style='color:#3399FF'>{3}</span>页&nbsp;&nbsp;&nbsp;&nbsp;", pager.TotalRowCount, pager.PageSize, Math.Ceiling(pager.TotalRowCount * 1.0 / pager.PageSize), (pager.StartRowIndex / pager.PageSize) + 1)%>
                        <asp:DataPager runat="server" ID="pager" PagedControlID="LVljsheng" PageSize="20" OnPreRender="pager_PreRender">
                            <Fields>
                                <asp:NextPreviousPagerField FirstPageText="首页" PreviousPageText="上一页" NextPageText="下一页" ButtonType="Button" ButtonCssClass="button"
                                    LastPageText="尾页" ShowFirstPageButton="true" ShowLastPageButton="true" ShowNextPageButton="true" ShowPreviousPageButton="true" />
                                <asp:NumericPagerField ButtonCount="5" NumericButtonCssClass="button" ButtonType="Button" NextPreviousButtonCssClass="button" />
                            </Fields>
                        </asp:DataPager>
                    </div>
                </div>
            </div>
        </div>
        <script type="text/javascript" src="/js/tab.js"></script> 
    </form>
</body>
</html>
