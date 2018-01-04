<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="appapi.aspx.cs" Inherits="LJSheng.Web.ljsheng.lin.appapi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>API访问统计</title>
    <link type="text/css" rel="stylesheet" href="/ljsheng/css/default.css" />
    <script type="text/javascript" src="/chajian/laydate/laydate.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="cont">
            <div class="cont2">
                <div class="opera">
                    <p>
                        <img src="/ljsheng/images/16.png" /> 函数名:<input type="text" id="ffm" runat="server" class="txt1" />
                        访问系统 <asp:DropDownList runat="server" ID="GMDDL">
                            <asp:ListItem Text="= 全 部 =" Value="0"></asp:ListItem>
                            <asp:ListItem Text="苹果" Value="1"></asp:ListItem>
                            <asp:ListItem Text="安卓" Value="2"></asp:ListItem>
                            <asp:ListItem Text="苹果PAD" Value="3"></asp:ListItem>
                            <asp:ListItem Text="安卓PAD" Value="4"></asp:ListItem>
                            <asp:ListItem Text="WEB" Value="5"></asp:ListItem>
                            </asp:DropDownList>
                        日期:<input runat="server" id="kssj" class="txt1" style="width:80px;" onclick="laydate({istime: true, format: 'YYYY-MM-DD'})" placeholder="年-月-日" /> - <input runat="server" id="jssj" class="txt1" style="width:80px;" onclick="laydate({istime: true, format: 'YYYY-MM-DD'})" placeholder="年-月-日" />
                        <asp:Button runat="server" ID="sel" CssClass="btn1" Text="搜索" OnClick="sel_Click" />
                    </p>
                </div>
                <div class="content">
                    <asp:ListView ID="LVljsheng" runat="server" OnItemCommand="LVljsheng_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("ffm")%><asp:Label ID="gid" runat="server" Text='<%# Eval("gid") %>' Visible="false" /></td>
                                <td><%# String.IsNullOrEmpty(Eval("sjxt").ToString())?"":((LJSheng.Data.Helps.sjxt)Enum.Parse(typeof(LJSheng.Data.Helps.sjxt), Eval("sjxt").ToString(), true)).ToString()%></td>
                                <td><%# Eval("bbh")%></td>
                                <td><%# Eval("sjxh")%></td>
                                <td><%# Eval("imei")%></td>
                                <td><%# Eval("dizhi")%><br />经度=<%# Eval("jingdu")%>,纬度=<%# Eval("weidu")%></td>
                                <td><%# Eval("haoshi")%></td>
                                <td><%# Eval("rukusj").ToString() %></td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <div>当前没有符合条件的数据</div>
                        </EmptyDataTemplate>
                        <LayoutTemplate>
                            <table id="list" border="1">
                                <tr runat="server" id="itemPlaceholderContainer">
                                    <th>函数名</th>
                                    <th>访问系统</th>
                                    <th>APP版本</th>
                                    <th>手机型号</th>
                                    <th>手机标识</th>
                                    <th>地址经纬度</th>
                                    <th>接口耗时(毫秒)</th>
                                    <th>访问时间</th>
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