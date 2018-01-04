<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gjzau.aspx.cs" Inherits="LJSheng.Web.ljsheng.gjzau" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>增加关键字</title>
    <link type="text/css" rel="stylesheet" href="/ljsheng/css/default.css" />
    <script src="/js/jquery-2.1.4.min.js"></script>
    <script type="text/javascript" src="/chajian/laydate/laydate.js"></script>
    <script type="text/javascript">
        $().ready(function () {
            $("#lxRB label").eq(1).click(function () {
                document.getElementById("wzlist").style.display = "none";
            });
            $("#lxRB label").eq(0).click(function () {
                document.getElementById("wzlist").style.display = "";
            });
        });
        function addwz(gid)
        {
            $("#"+gid).html("已添加");
            if($("#huifu").val()=="")
            {
                $("#huifu").val($("#huifu").val()+gid);
            }
            else
            {
                $("#huifu").val($("#huifu").val()+"$"+gid);
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="cont">
            <table id="add">
                <tr>
                    <th>关键字：</th>
                    <td>
                        <input type="text" runat="server" id="gjz" class="txt required" /><em class="tip">收到的关键字</em></td>
                </tr>
                <tr>
                    <th>回复类型：</th>
                    <td>
                        <asp:RadioButtonList ID="lxRB" runat="server" BorderStyle="None" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="1">图文消息</asp:ListItem>
                        <asp:ListItem Value="2">普通文字</asp:ListItem>
                    </asp:RadioButtonList>
                    </td>
                </tr>
                <tr id="huifudiv">
                    <th>回复内容：</th>
                    <td>
                        <textarea runat="server" id="huifu" class="required" style="margin: 0px; width: 500px; height: 100px;"></textarea><em class="tip">用户接受到的回复内容</em></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button runat="server" ID="tijiao" Text="提交" CssClass="btn_40" OnClick="tijiao_Click" /> 图文消息请不要在回复内容里输入如何字符,请在下面添加文章</td>
                </tr>
                 <tr id="wzlist">
                    <td colspan="2">
                        <div class="cont">
            <div class="cont2">
                <div class="opera">
                    <p>
                        <img src="../images/16.png" />
                        标题：<input type="text" id="biaoti" runat="server" class="txt1" />
                        日期:<input runat="server" id="kssj" class="txt1" style="width:80px;" onclick="laydate({istime: true, format: 'YYYY-MM-DD'})" placeholder="年-月-日" /> - <input runat="server" id="jssj" class="txt1" style="width:80px;" onclick="laydate({istime: true, format: 'YYYY-MM-DD'})" placeholder="年-月-日" />
                        <asp:Button runat="server" ID="sel" CssClass="btn1" Text="搜索" OnClick="sel_Click" />
                    </p>
                </div>
                <div class="content">
                    <asp:ListView ID="LVljsheng" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><a target="_blank" href="/app/xw.aspx?gid=<%# Eval("gid")%>"><%# Eval("biaoti")%></a></td>
                                <td><a target="_blank" href='/uploadfiles/xinwen/<%# Eval("tupian") %>'><img width="80" height="80" src='/uploadfiles/xinwen/<%# Eval("tupian") %>' /></a></td>
                                <td><%# Eval("fubiao")%></td>
                                <td>
                                    <%# DateTime.Parse(Eval("rukusj").ToString()).ToString("yyyy-MM-dd HH:mm")%>
                                </td>
                                <td id="<%# Eval("gid") %>"><input type="button" value="添加文章" class="btn2" onclick="addwz('<%# Eval("gid") %>');" /></td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <div>当前没有符合条件的数据</div>
                        </EmptyDataTemplate>
                        <LayoutTemplate>
                            <table id="list" border="1">
                                <tr runat="server" id="itemPlaceholderContainer">
                                    <th>标题</th>
                                    <th>副标题</th>
                                    <th>正文</th>
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
                        <asp:DataPager runat="server" ID="pager" PagedControlID="LVljsheng" PageSize="50" OnPreRender="pager_PreRender">
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
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>