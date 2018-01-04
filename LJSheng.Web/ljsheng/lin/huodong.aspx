<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="huodong.aspx.cs" Inherits="LJSheng.Web.ljsheng.lin.huodong" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>ljsheng</title>
    <link type="text/css" rel="stylesheet" href="/ljsheng/css/default.css" />
    <script src="/js/jquery-2.1.4.min.js"></script>
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
                        <img src="/ljsheng/images/16.png" /> 用户：<input type="text" id="zhanghao" runat="server" class="txt1" />
                        状态:<asp:DropDownList runat="server" ID="ztDDL">
                            <asp:ListItem Text="全部" Value="0"></asp:ListItem>
                            <asp:ListItem Text="未发" Value="1"></asp:ListItem>
                            <asp:ListItem Text="已发" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        类型:<asp:DropDownList runat="server" ID="lxDDL">
                            <asp:ListItem Text="全部" Value="0"></asp:ListItem>
                            <asp:ListItem Text="举报" Value="1"></asp:ListItem>
                            <asp:ListItem Text="转发" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        日期:<input runat="server" id="kssj" class="txt1" style="width:80px;" onclick="laydate({istime: true, format: 'YYYY-MM-DD'})" placeholder="年-月-日" /> - <input runat="server" id="jssj" class="txt1" style="width:80px;" onclick="laydate({istime: true, format: 'YYYY-MM-DD'})" placeholder="年-月-日" />
                        <asp:Button runat="server" ID="sel" CssClass="btn1" Text="搜索" OnClick="sel_Click" />
                    </p>
                </div>
                <div class="content">
                    <asp:ListView ID="LVljsheng" runat="server" OnItemCommand="LVljsheng_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("zhanghao")%><asp:Label ID="gid" runat="server" Text='<%# Eval("gid") %>' Visible="false" /></td>
                                <td><%# Eval("xingming")%><br /><%# Eval("lxfs")%></td>
                                <td><%# Eval("lx").ToString() == "1" ? "举报活动" : "转发活动"%></td>
                                <td><%# Eval("cishu")%></td>
                                <td>
                                    联系人:<asp:TextBox runat="server" ID="lxr" Text='<%# Eval("lxr") %>' />
                                    <br />
                                    联系方式:<asp:TextBox runat="server" ID="shouji" Text='<%# Eval("shouji") %>' />
                                    <br />
                                    地址:<asp:TextBox runat="server" ID="dizhi" Text='<%# Eval("dizhi") %>' />
                                </td>
                                <td>
                                    <div <%# Eval("zt").ToString() == "1" ? "" : "style=\"display:none;\""%>><asp:Button ID="zt" runat="server" CssClass="btn1" Text='<%# Eval("zt").ToString() == "1" ? "未发放" : "已发放"%>' CommandName="zt" CommandArgument='<%# Eval("zt") %>' /></div>
                                    <br />
                                    奖品:<asp:TextBox runat="server" ID="jp" Text='<%# Eval("jp") %>' />
                                </td>
                                <td><%# DateTime.Parse(Eval("rukusj").ToString()).ToString("yyyy-MM-dd HH:mm")%></td>
                                <td><asp:Button ID="up" runat="server" Text="更新" CssClass="btn2" CommandName="up" /> <asp:Button ID="del" runat="server" Text="删除" CssClass="btn2" CommandName="del" OnClientClick="return confirm('确定删除吗？');" /></td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <div>当前没有符合条件的数据</div>
                        </EmptyDataTemplate>
                        <LayoutTemplate>
                            <table id="list" border="1">
                                <tr runat="server" id="itemPlaceholderContainer">
                                    <th>用户</th>
                                    <th>会员信息</th>
                                    <th>活动类型</th>
                                    <th>满足次数</th>
                                    <th>领奖信息</th>
                                    <th>奖品状态</th>
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
