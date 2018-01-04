﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="apibug.aspx.cs" Inherits="LJSheng.Web.ljsheng.lin.apibug" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>APIBUG</title>
    <link type="text/css" rel="stylesheet" href="/ljsheng/css/default.css" />
    <script type="text/javascript" src="/js/jquery-2.1.4.min.js"></script>
    <script type="text/javascript" src="/chajian/laydate/laydate.js"></script>
    <script type="text/javascript" src="/chajian/layer/layer.js"></script>
    <script type="text/javascript" src="/js/ljsheng.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="cont">
            <div class="cont2">
                <div class="opera">
                    <p>
                        <img src="/ljsheng/images/16.png" />
                        函数名：<input type="text" id="ffm" runat="server" class="txt1" />
                        日期:<input runat="server" id="kssj" class="txt1" style="width:80px;" onclick="laydate({istime: true, format: 'YYYY-MM-DD'})" placeholder="年-月-日" /> - <input runat="server" id="jssj" class="txt1" style="width:80px;" onclick="laydate({istime: true, format: 'YYYY-MM-DD'})" placeholder="年-月-日" />
                        <asp:Button runat="server" ID="sel" CssClass="btn1" Text="搜索" OnClick="sel_Click" />
                    </p>
                </div>
                <div class="content">
                    <asp:ListView ID="LVljsheng" runat="server" OnItemCommand="LVljsheng_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("ffm")%><asp:Label ID="gid" runat="server" Text='<%# Eval("gid") %>' Visible="false" /></td>
                                <td><%# Eval("mcheng")%></td>
                                <td><%# Eval("xiaoxi")%></td>
                                <td><%# Eval("duizhai")%></td>
                                <td><%# Eval("canshu") %></td>
                                <td><%# Eval("deskey") %></td>
                                <td><%# LJSheng.Common.DESRSA.Decrypt(Eval("canshu").ToString(),Eval("deskey").ToString()) %></td>
                                <td>
                                    <%# Eval("rukusj").ToString() %>
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
                                    <th>调用的函数</th>
                                    <th>异常类型名称</th>
                                    <th>异常消息</th>
                                    <th>堆栈消息</th>
                                    <th>参数</th>
                                    <th>DES</th>
                                    <th>解密结果</th>
                                    <th>操作时间</th>
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
        <script type="text/javascript" src="/ljsheng/js/tab.js"></script>
    </form>
</body>
</html>