<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yjfk.aspx.cs" Inherits="LJSheng.Web.ljsheng.lin.yjfk" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>意见反馈管理</title>
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
                        <img src="/ljsheng/images/16.png" />
                        反馈问题：<input type="text" id="wenti" runat="server" class="txt1" /> 回复内容：<input type="text" id="huifu" runat="server" class="txt1" />
                        日期:<input runat="server" id="kssj" class="txt1" style="width:80px;" onclick="laydate({istime: true, format: 'YYYY-MM-DD'})" placeholder="年-月-日" /> - <input runat="server" id="jssj" class="txt1" style="width:80px;" onclick="laydate({istime: true, format: 'YYYY-MM-DD'})" placeholder="年-月-日" />
                        状态: <asp:DropDownList runat="server" ID="ztDDL">
                                    <asp:ListItem Value="0">= 全部 =</asp:ListItem>
                                    <asp:ListItem Value="1">已解决</asp:ListItem>
                                    <asp:ListItem Value="2">未解决</asp:ListItem>
                                </asp:DropDownList>
                        <asp:Button runat="server" ID="sel" CssClass="btn1" Text="搜索" OnClick="sel_Click" />
                    </p>
                </div>
                <div class="content">
                    <asp:ListView ID="LVljsheng" runat="server" OnItemCommand="LVljsheng_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("wenti")%><asp:Label ID="gid" runat="server" Text='<%# Eval("gid") %>' Visible="false" /></td>
                                <td><%# Eval("lxfs")%></td>
                                <td>
                                    <asp:TextBox runat="server" ID="huifu" Text='<%# Eval("huifu")%>' Height="50px" TextMode="MultiLine"></asp:TextBox>
                                    <asp:Button ID="hf" runat="server" Text="回复标注已解决" CssClass="btn2" CommandName="hf" />
                                </td>
                                <td>
                                    <%# string.IsNullOrEmpty(Eval("hfsj").ToString())?"" : DateTime.Parse(Eval("hfsj").ToString()).ToString("yyyy-MM-dd HH:mm")%>
                                    <br />
                                    <%# DateTime.Parse(Eval("rukusj").ToString()).ToString("yyyy-MM-dd HH:mm")%>
                                </td>
                                <td><%# Eval("beizhu")%></td>
                                <td><%# Eval("zt").ToString()=="1"?"已解决":"未解决"%></td>
                                <td><a href="javascript:showiframe('<%# Eval("wenti")%>','yjtp.aspx?gid=<%#Eval("gid") %>')">查看图片</a> | <asp:Button ID="del" runat="server" Text="删除" CssClass="btn2" CommandName="del" OnClientClick="return confirm('确定删除吗？');" /></td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <div>当前没有符合条件的数据</div>
                        </EmptyDataTemplate>
                        <LayoutTemplate>
                            <table id="list" border="1">
                                <tr runat="server" id="itemPlaceholderContainer">
                                    <th>意见反馈</th>
                                    <th>联系方式</th>
                                    <th>回复内容</th>
                                    <th>回复时间/反馈时间</th>
                                    <th>手机信息</th>
                                    <th>状态</th>
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
