<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hd.aspx.cs" Inherits="LJSheng.Web.app.hd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, minimum-scale=1.0, maximum-scale=1.0" />
    <title>防骗助手活动</title>
    <link href="/css/index.css" rel="stylesheet" />
    <style type="text/css">
        .txt {padding:8px 5px;width:200px;border:1px solid #ccc;border-bottom:1px solid #eee;border-right:1px solid #eee;background:#fdfdfd;}
        .btn2 {margin:3px;padding:0 4px;border:1px solid #ccc;background:#fff url(../images/h2.gif) repeat-x;overflow:visible;height:20px;display:inline-block;vertical-align:middle;line-height:20px;color:#1c64b1;border:1px solid #ccc;box-sizeing:border-box;}
    </style>
    <script type="text/javascript">
        function ck()
        {
            if (document.getElementById("xingming").value.length >1 && document.getElementById("shouji").value.length >6) {
                return true;
            }
            else {
                alert("你的资料填写不完整,请检查!!");
                return false;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrap">
            <div class="title">
                <h1 id="t"><label>活动信息登记</label></h1>
            </div>
            <div class="artical">
                <div class="content">
                    姓名:<asp:TextBox runat="server" ID="xingming" CssClass="txt"></asp:TextBox>
                    <br /><br />
                    手机:<asp:TextBox runat="server" ID="shouji" CssClass="txt"></asp:TextBox>
                    <br /><br />
                    <asp:Button runat="server" ID="tijiao" CssClass="btn2" Text="提交资料" OnClick="tijiao_Click" Width="120px" Height="50px" OnClientClick="return ck();" /> <span style="color:#ff0000;">参加者请补充以上领奖资料</span>
                    <hr />全城征集防骗达人，一键举报让骗子无处遁形，通过防骗助手的APP及防骗助手微信服务号(微信里搜索 防骗助手 关注)举报来自手机短信和网络诈骗信息相关的内容一经后台审核属实即可参加防骗达人举报有奖活动，活动如下：
                    <br />一、成功下载安装防骗助手APP和关注防骗助手微信服务号后正式参加活动。
                    <br />二、转发分享微信朋友圈并集合50个点赞即可换取移动公司赠送的1G流量包。通过微信服务号发送手机截图到后台进行认证换取流量包。
                    <br />三、通过防骗助手APP或者微信服务号进行诈骗内容举报的一经后台审核通过每条信息即可累计一个积分。累计200个积分即可成为防骗达人换取雍和会海鲜姿造价值358元的免费海鲜自助餐券一张。（注：举报内容规则，短信诈骗内容、携带木马病毒网址信息、虚假新闻、及一切各种新型诈骗内容等均可举报。）
                </div>
            </div>
        </div>
    </form>
</body>
</html>
