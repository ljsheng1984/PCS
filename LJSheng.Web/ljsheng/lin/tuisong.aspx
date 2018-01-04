<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tuisong.aspx.cs" Inherits="LJSheng.Web.ljsheng.lin.tuisong" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>推送管理</title>
    <link type="text/css" rel="stylesheet" href="/ljsheng/css/default.css" />
    <script type="text/javascript" src="/chajian/laydate/laydate.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="cont">
            <div class="cont2">
                <div class="opera">
                    <p>
                        <img src="/ljsheng/images/16.png" />
                        别名：<input type="text" id="alias" runat="server" class="txt1" /> 内容：<input type="text" id="nrong" runat="server" class="txt1" />
                        日期:<input runat="server" id="kssj" class="txt1" style="width:80px;" onclick="laydate({istime: true, format: 'YYYY-MM-DD'})" placeholder="年-月-日" /> - <input runat="server" id="jssj" class="txt1" style="width:80px;" onclick="laydate({istime: true, format: 'YYYY-MM-DD'})" placeholder="年-月-日" />
                        <asp:Button runat="server" ID="sel" CssClass="btn1" Text="搜索" OnClick="sel_Click" />
                    </p>
                </div>
                <div class="content">
                    <asp:ListView ID="LVljsheng" runat="server" OnItemCommand="LVljsheng_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%# Eval("alias") %><asp:Label ID="gid" runat="server" Text='<%# Eval("gid") %>' Visible="false" />
                                </td>
                                <td><%# String.IsNullOrEmpty(Eval("lx").ToString())?"":((LJSheng.Data.Helps.sjxt)Enum.Parse(typeof(LJSheng.Data.Helps.sjxt), Eval("lx").ToString(), true)).ToString()%></td>
                                <td><%# Eval("title")%></td>
                                <td><%# Eval("nrong") %></td>
                                <td><%# Eval("extras")%></td>
                                <td><%# Eval("sendno")%></td>
                                <td><%# Eval("ifacereturn")%></td>
                                <td><%# Eval("httpcode")%></td>
                                <td><%# Eval("messageid")%></td>
                                <td>
                                    <%# DateTime.Parse(Eval("rukusj").ToString()).ToString("yyyy-MM-dd HH:mm")%>
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
                                    <th>推送别名</th>
                                    <th>手机系统</th>
                                    <th>标题</th>
                                    <th>内容</th>
                                    <th>附加信息</th>
                                    <th>发送序列号</th>
                                    <th>接口返回内容</th>
                                    <th>http状态值</th>
                                    <th>消息id</th>
                                    <th>入库时间</th>
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
