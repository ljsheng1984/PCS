using System;

namespace cn.jpush.api.common.resp
{
    public class APIConnectionException:Exception
    {
        public APIConnectionException(String message):base(message)
        {
            
        }
    }
}
