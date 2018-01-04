namespace LJSheng.Data
{
    public class PubConstant
    {        
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectionString
        {           
            get 
            {
                //string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString;
                string _connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SQL"].ConnectionString;
                return _connectionString; 
            }
        }
    }
}