<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="duanxin.aspx.cs" Inherits="LJSheng.Web.ljsheng.lin.duanxin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>短信管理</title>
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
                        手机号：<input type="text" id="shouji" runat="server" class="txt1" /> 短信内容：<input type="text" id="dxnr" runat="server" class="txt1" /> 
                        短信类型: <asp:DropDownList runat="server" ID="lxDDL">
                                    <asp:ListItem Value="0">= 全部 =</asp:ListItem>
                                    <asp:ListItem Value="2">验 证 码</asp:ListItem>
                                    <asp:ListItem Value="1">系统短信</asp:ListItem>
                                </asp:DropDownList>
                        日期:<input runat="server" id="kssj" class="txt1" style="width:80px;" onclick="laydate({istime: true, format: 'YYYY-MM-DD'})" placeholder="年-月-日" /> - <input runat="server" id="jssj" class="txt1" style="width:80px;" onclick="laydate({istime: true, format: 'YYYY-MM-DD'})" placeholder="年-月-日" />
                        <asp:Button runat="server" ID="sel" CssClass="btn1" Text="搜索" OnClick="sel_Click" />
                    </p>
                </div>
                <div class="content">
                    <asp:ListView ID="LVljsheng" runat="server" OnItemCommand="LVljsheng_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td><asp:Label ID="shouji" runat="server" Text='<%# Eval("shouji") %>' /><asp:Label ID="gid" runat="server" Text='<%# Eval("gid") %>' Visible="false" /></td>
                                <td><asp:Label ID="msg" runat="server" Text='<%# Eval("dxnr") %>'  /></td>
                                <td><%# Eval("tiaoshu")%></td>
                                <td><%# Eval("lx").ToString() == "2" ? "<b style=\"color:Green\">验证码<b />" : "<b style=\"color:Red\">系统短信<b />"%><asp:Label ID="lx" runat="server" Text='<%# Eval("lx") %>' Visible="false" /></td>
                                <td><%# Eval("beizhu")%></td>
                                <td>
                                    <%# Eval("rukusj")%>
                                </td>
                                <td><asp:Button ID="del" runat="server" Text="删除" CssClass="btn2" CommandName="del" OnClientClick="return confirm('确定删除吗？');" /> |  <asp:Button ID="send" runat="server" Text="重发" CssClass="btn2" CommandName="send" OnClientClick="return confirm('确定重新发送吗？');" /></td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <div>当前没有符合条件的数据</div>
                        </EmptyDataTemplate>
                        <LayoutTemplate>
                            <table id="list" border="1">
                                <tr runat="server" id="itemPlaceholderContainer">
                                    <th>发送号码</th>
                                    <th>短信内容</th>
                                    <th>计费条数</th>
                                    <th>短信类型</th>
                                    <th>接口返回信息</th>
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
        <script type="text/javascript" src="/ljsheng/js/tab.js"></script>
    </form>
</body>
</html>