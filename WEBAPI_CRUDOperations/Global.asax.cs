using System.Web.Http;

namespace WEBAPI_CRUDOperations
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {         
            WebApiConfig.Register(GlobalConfiguration.Configuration);
        }
    }
}
