using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NAVWebApplication.ExportDataWebService;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace NAVWebApplication
{
    public partial class _Default : Page
    {

        // for development only - trust unsafe ssl certificate
        public static bool OnValidationCallback(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // for development only - trust unsafe ssl certificate
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(OnValidationCallback);

            Export_Data Service = new Export_Data();
            Service.UseDefaultCredentials = true;
            Service.Url = "https://pibe1:10067/DynamicsNAV100-3/WS/CRONUS%20Polska%20Sp.%20z%20o.o./Codeunit/Export_Data";
            NAVItem navitems = new NAVItem();
            Service.ExportItems(ref navitems);
            GridView1.DataSource = navitems.NAVItem1;
            GridView1.DataBind();
        }
    }
}


