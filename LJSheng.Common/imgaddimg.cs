using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace LJSheng.Common
{
    public class imgaddimg
    {
        /// <summary>    
        /// 二维码打上LOGO  
        /// </summary>     
        /// <param name="ewm">推荐人的二维码</param>    
        public static void Cewm(Image ewm,string gid)
        {
            Image imgBack = ewm;
            //Image img = Image.FromFile(System.Web.HttpContext.Current.Server.MapPath("/uploadfiles/ewm/logo.jpg"));        //照片图片      
            //if (img.Height > 120 || img.Width > 120)
            //{
            //    img = KiResizeImage(img, 120, 120, 0);
            //}
            //Graphics g = Graphics.FromImage(imgBack);

            //g.DrawImage(imgBack, 0, 0, 250, 250);    
            //g.DrawImage(img, imgBack.Width / 2 - img.Width / 2, imgBack.Width / 2 - img.Width / 2, img.Width, img.Height);
            //GC.Collect();
            string path = System.Web.HttpContext.Current.Server.MapPath("/uploadfiles/ewm/");
            imgBack.Save(path + gid + ".jpg");
            imgBack.Dispose();
        }

        /// <summary>    
        /// 二维码打上背景图片  
        /// </summary>     
        /// <param name="ewm">推荐人的二维码</param>    
        public static Image Ctjr(Image ewm,string gid)
        {
            Image imgBack = Image.FromFile(System.Web.HttpContext.Current.Server.MapPath("/uploadfiles/ewm/tjr.jpg"));
            Image img = Image.FromFile(System.Web.HttpContext.Current.Server.MapPath("/uploadfiles/ewm/" + gid + ".jpg"));
            img = KiResizeImage(img, 250, 250, 0);
            Graphics g = Graphics.FromImage(imgBack);

            g.DrawImage(imgBack, 0, 0, imgBack.Width, imgBack.Height);      //g.DrawImage(imgBack, 0, 0, 相框宽, 相框高);     
            g.DrawImage(img, 45, 560, img.Width, img.Height);
            GC.Collect();
            return imgBack;
        }
        /// <summary>    
        /// 调用此函数后使此两种图片合并，类似相册，有个背景图，中间贴自己的目标图片    
        /// </summary>    
        /// <param name="imgBack">粘贴的源图片</param>    
        /// <param name="destImg">粘贴的目标图片</param>    
        public static Image CombinImage(string Backimg, string destImg)
        {
            Image imgBack = Image.FromFile(Backimg); ;
            Image img = Image.FromFile(destImg);        //照片图片      
            if (img.Height > 200 || img.Width > 200)
            {
                img = KiResizeImage(img, 200, 200, 0);
            }
            Graphics g = Graphics.FromImage(imgBack);

            g.DrawImage(imgBack, 0, 0, imgBack.Width, imgBack.Height);      //g.DrawImage(imgBack, 0, 0, 相框宽, 相框高);     

            //g.FillRectangle(System.Drawing.Brushes.White, imgBack.Width / 2 - img.Width / 2 - 1, imgBack.Width / 2 - img.Width / 2 - 1,1,1);//相片四周刷一层黑色边框    

            //g.DrawImage(img, 照片与相框的左边距, 照片与相框的上边距, 照片宽, 照片高);    

            g.DrawImage(img, imgBack.Width / 2 - img.Width / 2, imgBack.Width / 2 - img.Width / 2, img.Width, img.Height);
            GC.Collect();
            return imgBack;
        }


        /// <summary>    
        /// Resize图片    
        /// </summary>    
        /// <param name="bmp">原始Bitmap</param>    
        /// <param name="newW">新的宽度</param>    
        /// <param name="newH">新的高度</param>    
        /// <param name="Mode">保留着，暂时未用</param>    
        /// <returns>处理以后的图片</returns>    
        public static Image KiResizeImage(Image bmp, int newW, int newH, int Mode)
        {
            try
            {
                Image b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);
                // 插值算法的质量    
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return b;
            }
            catch
            {
                return null;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }  
    }
}
