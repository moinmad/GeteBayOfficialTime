#region Copyright
//This program is licensed under the terms of the eBay Common Development and
//Distribution License (CDDL) Version 1.0 (the "License") and any subsequent
//version thereof released by eBay.  The then-current version of the License
//can be found at http://www.opensource.org/licenses/cddl1.php
#endregion

using System;
using System.Configuration;
//using GeteBayOfficialTime.com.ebay.developer;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GeteBayOfficialTime
{
    class Program
    {
        static string devID, appID, certID, serverUrl, userToken, appPath;
        static int siteID;

        static void Main(string[] args)
        {
            /*
            #region Initialise Needed Variables
            //Get the Keys from App.Config file
            devID = ConfigurationManager.AppSettings["DevID"];
            appID = ConfigurationManager.AppSettings["AppID"];
            certID = ConfigurationManager.AppSettings["CertID"];

            //Get the Server to use (Sandbox or Production)
            serverUrl = ConfigurationManager.AppSettings["ServerUrl"];

            //Get the User Token to Use
            userToken = ConfigurationManager.AppSettings["UserToken"];

            //SiteID = 0  (US) - UK = 3, Canada = 2, Australia = 15, ....
            //SiteID Indicates the eBay site to associate the call with
            siteID = 0;
            #endregion

            string version = "551";
            string callname = "GeteBayOfficialTime";

            Console.WriteLine("Making the call... \n");

            eBayAPIInterfaceService service = new eBayAPIInterfaceService();
            string requestURL = serverUrl + "?callname=" + callname + "&siteid=" + siteID
                                + "&appid=" + appID + "&version=" + version + "&routing=default";
            service.Url = requestURL;
            // Set credentials
            service.RequesterCredentials = new CustomSecurityHeaderType();
             service.RequesterCredentials.Credentials = new UserIdPasswordType();
            service.RequesterCredentials.Credentials.AppId = appID;
            service.RequesterCredentials.Credentials.DevId = devID;
            service.RequesterCredentials.Credentials.AuthCert = certID;
            service.RequesterCredentials.eBayAuthToken = userToken;

            GeteBayOfficialTimeRequestType request = new GeteBayOfficialTimeRequestType();
            request.Version = version;
         
            //make the call
            try
            {
                GeteBayOfficialTimeResponseType response = service.GeteBayOfficialTime(request);
                Console.WriteLine("eBay System Time: {0}", response.Timestamp.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("\nPress Enter to close");
            Console.ReadLine();
            */
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Relister());


        }
    }
}
