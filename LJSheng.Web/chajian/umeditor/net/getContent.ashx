<%@ WebHandler  Language="C#"  Class="getContent" %>
using System;
using System.Web;

public class getContent : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";

        //获取数据
        string content = context.Request.Form["nrong"];


        //存入数据库或者其他操作
        //-------------

        //显示


        context.Response.Write("<script src='/js/jquery-1.js'></script>");
        context.Response.Write("<script src='../third-party/mathquill/mathquill.min.js'></script>");
        context.Response.Write("<link rel='stylesheet' href='../third-party/mathquill/mathquill.css'/>");
        context.Response.Write("<div class='content'>" + content + "</div>");

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}