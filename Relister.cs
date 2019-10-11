using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
//using eBay.Service.Call;
//using eBay.Service.Core.Sdk;
//using eBay.Service.Util;
//using eBay.Service.Core.Soap;
//using GeteBayOfficialTime.com.ebay.developer;
using eBay.Service.Call;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using eBay.Service.Util;
using System.Data.OleDb;

//using System.Collections.CollectionBase;

namespace GeteBayOfficialTime
{
    public partial class Relister : Form
    {
        public Relister()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* string devID, appID, certID, serverUrl, userToken, appPath;
             int siteID;

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
             //string callname = "GeteBayOfficialTime";
             string callname = "GetSellerEvents";

             //Console.WriteLine("Making the call... \n");
             textBox1.Text="Making the call... ";

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
                 textBox1.Text = "eBay System Time: {0}" + response.Timestamp.ToString();
                 //Console.WriteLine("eBay System Time:", response.Timestamp.ToString());
             }
             catch (Exception ex)
             {
                 textBox1.Text = ex.Message;
                 //Console.WriteLine(ex.Message);
             }
             //Console.WriteLine("\nPress Enter to close");
             //Console.ReadLine();
             * */
        }
        void Getinfo()
        {
            /*
            // define what's needed to build the request url
            // to call the ebay soap api

            // endpoint can be either sandbox or production
            // make sure credentials are for that environment
            string devID, appID, certID, serverUrl, userToken, appPath;
            //int siteID;

           //Get the Keys from App.Config file
            devID = ConfigurationManager.AppSettings["DevID"];
            appID = ConfigurationManager.AppSettings["AppID"];
            certID = ConfigurationManager.AppSettings["CertID"];

            //string endpoint = "https://api.sandbox.ebay.com/wsapi";    // sandbox
            string endpoint = "https://api.ebay.com/wsapi";               // production

            // credentials are hard-coded for this example

            //Get the User Token to Use
            userToken = ConfigurationManager.AppSettings["UserToken"];


            // call name, site id, and version are required
            string callName = "GetUser";
            string siteID = "0";
            string version = "433";

            // build the request url
            string requestURL = endpoint
                + "?callname=" + callName
                + "&siteid=" + siteID
                + "&appid=" + appID
                + "&version=" + version
                + "&routing=default";

            // create the service object
            eBayAPIInterfaceService service = new eBayAPIInterfaceService();

            // assign the request url to the service object
            service.Url = requestURL;

            // add the token
            service.RequesterCredentials = new CustomSecurityHeaderType();
            service.RequesterCredentials.eBayAuthToken = userToken;

            // add the three ids
            service.RequesterCredentials.Credentials = new UserIdPasswordType();
            service.RequesterCredentials.Credentials.AppId = appID;
            service.RequesterCredentials.Credentials.DevId = devID;
            service.RequesterCredentials.Credentials.AuthCert = certID;

            string userid = null;
            userid = txtUserID.Text;

            // create the request object
            GetUserRequestType request = new GetUserRequestType();
            request.Version = "433";   // required for soap api
            request.UserID = userid;    // add a user id here


            // make the call
            GetUserResponseType response = service.GetUser(request);

            // parse the response
            /*Console.WriteLine("Here's the user info:");
            Console.WriteLine("The user id is " + response.User.UserID);
            Console.WriteLine("The feedback score is " + response.User.FeedbackScore);
            Console.WriteLine("The feedback rating star is " + response.User.FeedbackRatingStar);
            Console.WriteLine("And we're done!");
            Console.ReadLine();*/
            //txtResults.Text = "The feedback score is " + response.User.FeedbackScore;

        }
        void GetSellerList()
        {
            /*
            // define what's needed to build the request url
            // to call the ebay soap api

            // endpoint can be either sandbox or production
            // make sure credentials are for that environment
            string devID, appID, certID, serverUrl, userToken, appPath;
            //int siteID;
            int nPageNumber = 0;
            int nNoOnAPage = 0;


            //Get the Keys from App.Config file
            devID = ConfigurationManager.AppSettings["DevID"];
            appID = ConfigurationManager.AppSettings["AppID"];
            certID = ConfigurationManager.AppSettings["CertID"];

            //string endpoint = "https://api.sandbox.ebay.com/wsapi";    // sandbox
            string endpoint = "https://api.ebay.com/wsapi";               // production

            // credentials are hard-coded for this example

            //Get the User Token to Use
            userToken = ConfigurationManager.AppSettings["UserToken"];


            // call name, site id, and version are required
            string callName = "GetSellerList";
            string siteID = "0";
            string version = "459";

            // build the request url
            string requestURL = endpoint
                + "?callname=" + callName
                + "&siteid=" + siteID
                + "&appid=" + appID
                + "&version=" + version
                + "&routing=default";

            // create the service object
            eBayAPIInterfaceService service = new eBayAPIInterfaceService();

            // assign the request url to the service object
            service.Url = requestURL;

            // add the token
            service.RequesterCredentials = new CustomSecurityHeaderType();
            service.RequesterCredentials.eBayAuthToken = userToken;

            // add the three ids
            service.RequesterCredentials.Credentials = new UserIdPasswordType();
            service.RequesterCredentials.Credentials.AppId = appID;
            service.RequesterCredentials.Credentials.DevId = devID;
            service.RequesterCredentials.Credentials.AuthCert = certID;

            string userid = null;
            userid = txtUserID.Text;

            // create the request object
            GetSellerListRequestType request = new GetSellerListRequestType();
            request.Version = "575";   // required for soap api
            request.UserID = userid;    // add a user id here
            request.EndTimeFrom = DateTime.Today;
            request.EndTimeTo = DateTime.Today.AddDays(1);
            
            PaginationType oPagination = new PaginationType();
            oPagination.EntriesPerPage = 200;
            oPagination.EntriesPerPageSpecified = true;
            oPagination.PageNumber = 1;
            oPagination.PageNumberSpecified = true;
            request.Pagination = oPagination;

            //request. = new TimeFilter(DateTime.Now, DateTime.Now.AddMonths(3));
            
            // make the call
            GetSellerListResponseType response = service.GetSellerList(request);

            // parse the response
            /*Console.WriteLine("Here's the user info:");
            Console.WriteLine("The user id is " + response.User.UserID);
            Console.WriteLine("The feedback score is " + response.User.FeedbackScore);
            Console.WriteLine("The feedback rating star is " + response.User.FeedbackRatingStar);
            Console.WriteLine("And we're done!");
            Console.ReadLine();*/
            //txtResults.Text = "The feedback score is " + response.User.FeedbackScore;

        }
        void GetSellerListOfItems()
        {
            ApiContext oContext = new ApiContext();
            int nNumberofTotalListing = 0;
            int nNumberofSoldListing = 0;
            double nTotalAmount = 0;
            int nAlreadyRelistedCount = 0;
            int nEligibleItemForRelist = 0;
            string szShippingType;

            dataGridView1.Rows.Clear();
            Cursor.Current = Cursors.WaitCursor;

            txtResults.Text = " ";
            // set the dev,app,cert information
            oContext.ApiCredential.ApiAccount.Developer = ConfigurationManager.AppSettings["DevID"];
            oContext.ApiCredential.ApiAccount.Application = ConfigurationManager.AppSettings["AppID"];
            oContext.ApiCredential.ApiAccount.Certificate = ConfigurationManager.AppSettings["CertID"];

            // set the AuthToken
            oContext.ApiCredential.eBayToken = ConfigurationManager.AppSettings["UserToken"];

            // set the base SOAP URL .. use https://api.sandbox.ebay.com/wsapi for Sandbox calls
            //oContext.SoapApiServerUrl = "https://api.ebay.com/wsapi";
            oContext.SoapApiServerUrl = ConfigurationManager.AppSettings["ServerUrl"];

            // set the Site of the Context
            oContext.Site = eBay.Service.Core.Soap.SiteCodeType.US;

            // very important, let's setup the logging
            ApiLogManager oLogManager = new ApiLogManager();
            oLogManager.ApiLoggerList.Add(new eBay.Service.Util.FileLogger("GetSellerList459NETSDK.log", true, true, true));
            oLogManager.EnableLogging = true;
            oContext.ApiLogManager = oLogManager;

            // the WSDL Version used for this SDK build
            oContext.Version = "459";

            // set the CallRetry properties
            CallRetry oCallRetry = new CallRetry();
            // set the delay between each retry to 1 millisecond
            oCallRetry.DelayTime = 1;
            // set the maximum number of retries
            oCallRetry.MaximumRetries = 3;
            // set the error codes on which to retry
            StringCollection oErrorCodes = new StringCollection();
            oErrorCodes.Add("10007"); // Internal error to the application ... general error
            oErrorCodes.Add("2"); // unsupported verb error
            oErrorCodes.Add("251"); // eBay Structured Exception ... general error
            oCallRetry.TriggerErrorCodes = oErrorCodes;
            // set the exception types on which to retry
            TypeCollection oExceptions = new TypeCollection();
            oExceptions.Add(typeof(System.Net.ProtocolViolationException));
            // the "Client found response content type of 'text/plain'" exception is of type SdkException, so let's add that to the list
            oExceptions.Add(typeof(SdkException));
            oCallRetry.TriggerExceptions = oExceptions;

            // set CallRetry back to ApiContext
            oContext.CallRetry = oCallRetry;

            // set the timeout to 2 minutes
            oContext.Timeout = 120000;

            GetSellerListCall oGetSellerListCall = new GetSellerListCall(oContext);

            // set the Version used in the call
            oGetSellerListCall.Version = oContext.Version;

            // set the Site of the call
            oGetSellerListCall.Site = oContext.Site;

            // enable the compression feature
            oGetSellerListCall.EnableCompression = true;

            // use GranularityLevel of Fine
            oGetSellerListCall.GranularityLevel = GranularityLevelCodeType.Fine;

            // get the first page, 200 items per page
            PaginationType oPagination = new PaginationType();
            oPagination.EntriesPerPage = 200;
            //oPagination.EntriesPerPageSpecified = true;
            oPagination.PageNumber = 1;
            //oPagination.PageNumberSpecified = true;

            oGetSellerListCall.Pagination = oPagination;

            oGetSellerListCall.UserID = txtUserID.Text;

            // ask for all items that are ending in the future (active items)
            //oGetSellerListCall.EndTimeFilter = new TimeFilter(DateTime.Now.AddDays(-3),DateTime.Now);
            //oGetSellerListCall.EndTimeFilter = new TimeFilter(dateTimePicker1.Value, DateTime.Now);
            oGetSellerListCall.EndTimeFilter = new TimeFilter(dateTimePicker1.Value, dateTimePicker2.Value);

            // return items that end soonest first
            oGetSellerListCall.Sort = 1;
            // see http://developer.ebay.com/DevZone/SOAP/docs/WSDL/xsd/1/element/1597.htm for Sort documentation

            try
            {
                ItemTypeCollection oItems = oGetSellerListCall.GetSellerList();
                // output some of the data
                nNumberofTotalListing = 0;
                nNumberofSoldListing = 0;
                int pagenumber = 1;

                while (pagenumber <= oGetSellerListCall.PaginationResult.TotalNumberOfPages)
                {
                    if (pagenumber > 1)
                    {
                        oGetSellerListCall.Pagination.PageNumber = pagenumber;
                        //oGetSellerListCall.Execute();
                        oItems = oGetSellerListCall.GetSellerList();
                    }

                    foreach (ItemType oItem in oItems)
                    {
                        nNumberofTotalListing = nNumberofTotalListing + 1;
                        if (oItem.ShippingDetails.ShippingType == ShippingTypeCodeType.Free)
                            szShippingType = "FREE";

                        if (oItem.SellingStatus.HighBidder != null)
                        {
                            if (!(chkbx_OnlyRelistOnes.Checked))
                            {
                                dataGridView1.Rows.Add(oItem.ItemID, oItem.ListingType, oItem.Title, oItem.SubTitle, oItem.ListingDetails.StartTime.ToShortDateString(), oItem.ListingDetails.EndTime.ToShortDateString(), oItem.SellingStatus.CurrentPrice.Value, oItem.SellingStatus.HighBidder.UserID);
                            }
                            nNumberofSoldListing = nNumberofSoldListing + 1;
                            nTotalAmount = nTotalAmount + Convert.ToDouble(oItem.SellingStatus.CurrentPrice.Value);

                        }
                        else
                        {
                            if (oItem.ListingDetails.RelistedItemID == null)
                            {
                                dataGridView1.Rows.Add(oItem.ItemID, oItem.ListingType, oItem.Title, oItem.SubTitle, oItem.ListingDetails.StartTime.ToShortDateString(), oItem.ListingDetails.EndTime.ToShortDateString(), oItem.SellingStatus.CurrentPrice.Value, "DNS");
                                nEligibleItemForRelist += 1;
                            }
                            else
                                nAlreadyRelistedCount += 1;
                        }

                        //Console.WriteLine("ItemID is " + oItem.ItemID);
                        //Console.WriteLine("This item is of type " + oItem.ListingType.ToString());
                        //if (0 < oItem.SellingStatus.BidCount)
                        //{
                        // The HighBidder element is valid only if there is at least 1 bid
                        //    Console.WriteLine("High Bidder is " + oItem.SellingStatus.HighBidder.UserID);
                        //}
                        //Console.WriteLine("Current Price is " + oItem.SellingStatus.CurrentPrice.currencyID.ToString() + " " + oItem.SellingStatus.CurrentPrice.Value.ToString());
                        //Console.WriteLine("End Time is " + oItem.ListingDetails.EndTime.ToLongDateString() + " " + oItem.ListingDetails.EndTime.ToLongTimeString());
                        //Console.WriteLine("");
                        // the data that is accessible through the item object
                        // for different GranularityLevel and DetailLevel choices
                        // can be found at the following URL:
                        // http://developer.ebay.com/DevZone/SOAP/docs/WebHelp/GetSellerListCall-GetSellerList_Best_Practices.html
                    }
                    pagenumber += 1;
                }
                //pagenumber += 1;

                //    
                //    
                //    
                //Console.WriteLine("Done");
                txtbx_AmountSold.Text = nTotalAmount.ToString();
                txtbx_NumberOfListing.Text = nNumberofTotalListing.ToString();
                txtbx_NumberofSold.Text = nNumberofSoldListing.ToString();
                txtbx_AlreadyListed.Text = nAlreadyRelistedCount.ToString();
                txtbx_relistEligible.Text = nEligibleItemForRelist.ToString();
            }

            catch (ApiException oApiEx)
            {
                // process exception ... pass to caller, implement retry logic here or in caller, whatever you want to do
                txtResults.Text = oApiEx.Message;
                return;
            }
            catch (SdkException oSdkEx)
            {
                // process exception ... pass to caller, implement retry logic here or in caller, whatever you want to do
                txtResults.Text = oSdkEx.Message;
                return;
            }
            catch (Exception oEx)
            {
                // process exception ... pass to caller, implement retry logic here or in caller, whatever you want to do
                txtResults.Text = oEx.Message;
                return;
            }
            Cursor.Current = Cursors.Default;
        }
        void RelistEbayItem(string szItem, double dNewStartingPrice, double dNewBuyNowPrice, string szNewCategory, string szNumberofDays, string szListingType)
        {
            txtResults.Text = " ";
            ApiContext oContext = new ApiContext();

            // set the dev,app,cert information
            oContext.ApiCredential.ApiAccount.Developer = ConfigurationManager.AppSettings["DevID"];
            oContext.ApiCredential.ApiAccount.Application = ConfigurationManager.AppSettings["AppID"];
            oContext.ApiCredential.ApiAccount.Certificate = ConfigurationManager.AppSettings["CertID"];

            // set the AuthToken
            oContext.ApiCredential.eBayToken = ConfigurationManager.AppSettings["UserToken"];

            // set the base SOAP URL .. use https://api.sandbox.ebay.com/wsapi for Sandbox calls
            //oContext.SoapApiServerUrl = "https://api.ebay.com/wsapi";
            oContext.SoapApiServerUrl = ConfigurationManager.AppSettings["ServerUrl"];

            // set the Site of the Context
            oContext.Site = eBay.Service.Core.Soap.SiteCodeType.US;

            // very important, let's setup the logging
            ApiLogManager oLogManager = new ApiLogManager();
            oLogManager.ApiLoggerList.Add(new eBay.Service.Util.FileLogger("GetSellerList459NETSDK.log", true, true, true));
            oLogManager.EnableLogging = true;
            oContext.ApiLogManager = oLogManager;

            // the WSDL Version used for this SDK build
            oContext.Version = "459";

            // set the CallRetry properties
            CallRetry oCallRetry = new CallRetry();
            // set the delay between each retry to 1 millisecond
            oCallRetry.DelayTime = 1;
            // set the maximum number of retries
            oCallRetry.MaximumRetries = 3;
            // set the error codes on which to retry
            StringCollection oErrorCodes = new StringCollection();
            oErrorCodes.Add("10007"); // Internal error to the application ... general error
            oErrorCodes.Add("2"); // unsupported verb error
            oErrorCodes.Add("251"); // eBay Structured Exception ... general error
            oCallRetry.TriggerErrorCodes = oErrorCodes;

            // set the exception types on which to retry
            TypeCollection oExceptions = new TypeCollection();
            oExceptions.Add(typeof(System.Net.ProtocolViolationException));
            // the "Client found response content type of 'text/plain'" exception is of type SdkException, so let's add that to the list
            oExceptions.Add(typeof(SdkException));
            oCallRetry.TriggerExceptions = oExceptions;

            // set CallRetry back to ApiContext
            oContext.CallRetry = oCallRetry;

            // set the timeout to 2 minutes
            oContext.Timeout = 120000;

            RelistItemCall oRelistItemCall = new RelistItemCall(oContext);

            // set the Version used in the call
            oRelistItemCall.Version = oContext.Version;

            // set the Site of the call
            oRelistItemCall.Site = oContext.Site;

            // enable the compression feature
            oRelistItemCall.EnableCompression = true;


            ItemType item = new ItemType();
            item.ItemID = szItem;
            item.BuyItNowPrice = new AmountType();
            item.BuyItNowPrice.Value = dNewBuyNowPrice;
            item.StartPrice = new AmountType();
            item.StartPrice.Value = dNewStartingPrice;
            item.StartPrice.currencyID = CurrencyCodeType.USD;
            item.BuyItNowPrice.currencyID = CurrencyCodeType.USD;
            item.ListingType = new ListingTypeCodeType();
            item.ListingType = ListingTypeCodeType.Chinese;
            item.DispatchTimeMax = 2;
            item.ReturnPolicy = new ReturnPolicyType();
            item.ReturnPolicy.ReturnsAcceptedOption = "ReturnsAccepted";
            //item.ReturnPolicy.ReturnsWithin = "Days_3";
            item.ReturnPolicy.ShippingCostPaidBy = "Buyer";
            item.ReturnPolicy.ReturnsWithinOption = "Days_3";
            item.ReturnPolicy.RefundOption = "Exchange";
            item.ReturnPolicy.Description = "Retund policy applies to item that are sold with Guaranteed or Warranty.  Refund policy does not apply to anything that is being sold AS-IS with no warranty.  Please read item description carefully.  If you have any questions about warranty please do not hesitate to call us at 303-521-3869 or email us";

            //item.ListingDuration =szNumberofDays;
            //item.ListingDuration = "Days_7";


            try
            {
                oRelistItemCall.RelistItem(item);
            }

            catch (ApiException oApiEx)
            {
                // process exception ... pass to caller, implement retry logic here or in caller, whatever you want to do
                txtResults.Text = oApiEx.Message;
                return;
            }
            catch (SdkException oSdkEx)
            {
                // process exception ... pass to caller, implement retry logic here or in caller, whatever you want to do
                txtResults.Text = oSdkEx.Message;
                return;
            }
            catch (Exception oEx)
            {
                // process exception ... pass to caller, implement retry logic here or in caller, whatever you want to do
                txtResults.Text = oEx.Message;
                return;
            }

            DataGridViewRow theRow = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index];
            theRow.DefaultCellStyle.BackColor = Color.Red;

            Cursor.Current = Cursors.Default;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //Getinfo();
            //GetSellerList();
            GetSellerListOfItems();
        }

        private void txtUserID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Relist_Click(object sender, EventArgs e)
        {
            string szitem = null;
            double dNewStartingPrice = 0;
            double dNewBuyNowPrice = 0;
            string szNewCategory = null;
            string szNewNumberofDays = null;
            string szNewListingType = null;

            szitem = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[8].Value != null)
                dNewStartingPrice = Convert.ToDouble(dataGridView1.CurrentRow.Cells[8].Value);
            if (dataGridView1.CurrentRow.Cells[9].Value != null)
                dNewBuyNowPrice = Convert.ToDouble(dataGridView1.CurrentRow.Cells[9].Value);
            if (dataGridView1.CurrentRow.Cells[10].Value != null)
                szNewCategory = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[11].Value != null)
                szNewNumberofDays = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            else
                szNewNumberofDays = "7";
            if (dataGridView1.CurrentRow.Cells[11].Value != null)
                szNewListingType = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            else
                szNewListingType = "Chinese";
            if (chkbx_Schedule.Checked)
            {
                //Schedule the listing
                storeschedulelisitng(szitem, dNewStartingPrice, dNewBuyNowPrice, szNewCategory, szNewNumberofDays, szNewListingType);
            }
            else
            {
                RelistEbayItem(szitem, dNewStartingPrice, dNewBuyNowPrice, szNewCategory, szNewNumberofDays, szNewListingType);
            }
        }

        void ListScheduleListing()
        {
            string szError = "";
            string szSelectString_Value = "";
            DateTime dtStartingTime;

            System.Data.OleDb.OleDbConnection conn_newdb = new System.Data.OleDb.OleDbConnection();
            conn_newdb.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" + "Data source= " + txtbx_ReListSchTblePath.Text;


            try
            {
                conn_newdb.Open();
            }
            catch (Exception)
            {
                szError = "Can't Open DB";
            }

            szSelectString_Value = "SELECT * FROM [Schedule] where ListedFlag = \"N\"";
            OleDbCommand cmd3 = new OleDbCommand(szSelectString_Value, conn_newdb);
            OleDbDataReader reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            {
                //Check the date, if the date is less then the date 
                dtStartingTime = Convert.ToDateTime(reader3["StartingTime"].ToString());
                if (DateTime.Compare(dtStartingTime, DateTime.Now) > 0)
                {
                    //
                }

            }
            conn_newdb.Close();
        }
        void storeschedulelisitng(string szItem, double dNewStartingPrice, double dNewBuyNowPrice, string szNewCategory, string szNumberofDays, string szListingType)
        {
            string szError = "";
            string szInsertStatementString = "";
            DateTime dStartTime;
            System.Data.OleDb.OleDbConnection conn_newdb = new System.Data.OleDb.OleDbConnection();
            conn_newdb.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" + "Data source= " + txtbx_ReListSchTblePath.Text;


            try
            {
                conn_newdb.Open();
            }
            catch (Exception)
            {
                szError = "Can't Open DB";
            }
            txtbx_error.Text = szError;
            if (txtbx_StartTime.Text == "")
                txtbx_StartTime.Text = DateTime.Now.AddMinutes(2).ToString();
            else
            {
                dStartTime = Convert.ToDateTime(txtbx_StartTime.Text);
                dStartTime.AddMinutes(2);
                txtbx_StartTime.Text = dStartTime.ToString();
            }
            dStartTime = Convert.ToDateTime(txtbx_StartTime.Text);
            szInsertStatementString = "insert into Schedule (" +
                                                                "SZITEMID," +
                                                                "StartingPrice," +
                                                                "BuyNowPrice," +
                                                                "StartingTime," +
                                                                "ListedFlag" +
                                                                ") VALUES ( "
                                                                + "\"" + szItem + "\"" + "," +
                                                                +dNewStartingPrice + "," +
                                                                +dNewBuyNowPrice + ","
                                                                + "\"" + dStartTime + "\"" + "," +
                                                                "N" +
                                                                ")";
            OleDbCommand cmd4 = new OleDbCommand(szInsertStatementString, conn_newdb);
            cmd4.ExecuteNonQuery();
            szInsertStatementString = null;


            conn_newdb.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("IAMHERE");
        }
        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            double dStartingPrice = 0;
            double dNewBuyNowPrice = 0;

            if (e.ColumnIndex == 8)
            {

                //dStartingPrice = Convert.ToDouble(dataGridView1.CurrentRow.Cells[8].Value);
                //dNewBuyNowPrice = dStartingPrice + (dStartingPrice * 0.10);
                //MessageBox.Show(dNewBuyNowPrice.ToString());
            }

            //dataGridView1[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Empty;

            //
        }
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            double dStartingPrice = 0;
            double dNewBuyNowPrice = 0;

            if (e.ColumnIndex == 9)
            {

                dStartingPrice = Convert.ToDouble(dataGridView1.CurrentRow.Cells[8].Value);
                dNewBuyNowPrice = dStartingPrice + (dStartingPrice * 0.10);
                dNewBuyNowPrice = Math.Round(dNewBuyNowPrice, 2);
                dataGridView1.CurrentRow.Cells[9].Value = dNewBuyNowPrice.ToString();
            }
            //MessageBox.Show("IAMHERELEAVE");
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_Analysis newform = new frm_Analysis();
            newform.ShowDialog();
        }

        private void EbayApplication_Load(object sender, EventArgs e)
        {
            txtbx_ReListSchTblePath.Text = "C:\\sumcomputers\\relistschedule\\RLSch.mdb";


        }

        private void button4_Click(object sender, EventArgs e)
        {
            ListScheduleListing();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string szError = "";

            string szInsertStatementString = "";
            System.Data.OleDb.OleDbConnection conn_newdb = new System.Data.OleDb.OleDbConnection();
            conn_newdb.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" + "Data source= " + @"C:\sumcomputers\InventoryMonitor\InventoryMonitor.mdb";
            try
            {
                conn_newdb.Open();
            }
            catch (Exception)
            {
                szError = "Can't Open DB";
            }
            
            string[] lines = System.IO.File.ReadAllLines(@"C:\sumcomputers\InventoryMonitor\UpdateSQL.txt");
            int nCount = 0;
            // Display the file contents by using a foreach loop.
            //System.Console.WriteLine("Contents of WriteLines2.txt = ");
            while (nCount<951)
            {
                nCount++;
                // Use a tab to indent each line of the file.
                szInsertStatementString = lines[nCount];
                OleDbCommand cmd4 = new OleDbCommand(szInsertStatementString, conn_newdb);
                cmd4.ExecuteNonQuery();
                szInsertStatementString = null;

            }

            conn_newdb.Close();

        }

    }        
    
}