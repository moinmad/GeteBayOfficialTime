using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using eBay.Service.Call;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using eBay.Service.Util;
using System.Configuration;
using System.Data.OleDb;

namespace GeteBayOfficialTime
{
    public partial class frm_Analysis : Form
    {
        public frm_Analysis()
        {
            InitializeComponent();
            txtbx_dbpath.Text = "C:\\sumcomputers\\EbayAnalysis\\EbayAnalysis.mdb";
            txtbx_InvDBPath.Text = "C:\\sumcomputers\\InventoryMonitor\\InventoryMonitor.mdb";
            
        }

        bool CheckRecordExistence(string szCustomLabel, string szItemNumber)
        {
            bool bRtnValue=false;
            string szError = "";
            string szSelectString="";

            System.Data.OleDb.OleDbConnection conn_newdb = new System.Data.OleDb.OleDbConnection();
            conn_newdb.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" + "Data source= " + txtbx_dbpath.Text;
            try
            {
                conn_newdb.Open();
            }
            catch (Exception)
            {
                szError = "Failed";
            }

            szSelectString = "SELECT * from [EbayAnalysis] where CustomItemNumber = \""+szCustomLabel +"\" and EbayItemNumber = \""+szItemNumber+"\"";

            OleDbCommand cmd7 = new OleDbCommand(szSelectString, conn_newdb);
            OleDbDataReader reader = cmd7.ExecuteReader();
            while (reader.Read())
            {
                bRtnValue = true;
                break;
            }
            conn_newdb.Close();

            return bRtnValue;
        }

        void GetEbayTime()
        {
            //create new service
            string szServerURL = "";
            string callname = "GeteBayOfficialTime";
            string devID, appID, certID, userToken;
            int siteID;
            string version = "551";

            eBayAPIInterfaceService service = new eBayAPIInterfaceService();
            szServerURL = ConfigurationManager.AppSettings["ServerUrl"];

            devID = ConfigurationManager.AppSettings["DevID"];
            appID = ConfigurationManager.AppSettings["AppID"];
            certID = ConfigurationManager.AppSettings["CertID"];

            //Get the User Token to Use
            userToken = ConfigurationManager.AppSettings["UserToken"];

            //SiteID = 0  (US) - UK = 3, Canada = 2, Australia = 15, ....
            //SiteID Indicates the eBay site to associate the call with
            siteID = 0;
            
            service.RequesterCredentials = new CustomSecurityHeaderType();
            service.RequesterCredentials.eBayAuthToken = ConfigurationManager.AppSettings["UserToken"];    // use your token 
            
            service.RequesterCredentials.Credentials = new UserIdPasswordType();
            service.RequesterCredentials.Credentials.AppId = ConfigurationManager.AppSettings["AppID"];
            service.RequesterCredentials.Credentials.DevId = ConfigurationManager.AppSettings["DevID"];
            service.RequesterCredentials.Credentials.AuthCert = ConfigurationManager.AppSettings["CertID"];


            string requestURL = szServerURL + "?callname=" + callname + "&siteid=" + siteID
                                + "&appid=" + appID + "&version=" + version + "&routing=default";
            service.Url = requestURL;

            GeteBayOfficialTimeRequestType request = new GeteBayOfficialTimeRequestType();
            request.Version = "459";
            GeteBayOfficialTimeResponseType response = service.GeteBayOfficialTime(request); 

            datepick_ebay.Value = response.Timestamp;
            datepick_ebay.Value=datepick_ebay.Value.AddHours(-7);
            label2.Text = datepick_ebay.Value.ToString();
            //label2.Text = response.Timestamp.ToString();
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
            string szError = "";
            string szInsertString = "";
            string[] szArray = new string[30];
            string[] szItemArray = new string[30];
            int nCount = 0;
            string szHighBidder = "";
            string szSubTitle = " ";
            string szTitle = " ";
            string szDescription = " ";
            string szSelectString = " ";
            DateTime jddate = new DateTime();
            string szInventoryCategory =" ";
            string szInventoryCamera = " ";
            string szInventoryLocation = " ";
            string szInventorySource=" ";
            DateTime jdInvShipDate = new DateTime();
            DateTime jdListedDate = new DateTime();
            double dInvPrice = 0;
            int nQtyAvail = 0;
            int nQtySold = 0;
            int nLotSize = 0;

            //dataGridView1.Rows.Clear();
            Cursor.Current = Cursors.WaitCursor;


            System.Data.OleDb.OleDbConnection conn_newdb = new System.Data.OleDb.OleDbConnection();
            
            conn_newdb.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" + "Data source= " + txtbx_dbpath.Text;
            try
            {
                conn_newdb.Open();
            }
            catch (Exception)
            {
                szError = "Failed";
            }
            /*the inventory header database connection*/
            System.Data.OleDb.OleDbConnection conn_newdb2 = new System.Data.OleDb.OleDbConnection();
            conn_newdb2.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" + "Data source= " + txtbx_InvDBPath.Text;
            try
            {
                conn_newdb2.Open();
            }
            catch (Exception)
            {
                szError = "Failed";
            }


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
            //oGetSellerListCall.GranularityLevel = GranularityLevelCodeType.Fine;
            
            oGetSellerListCall.DetailLevelList.Add(DetailLevelCodeType.ReturnAll);

            // get the first page, 200 items per page
            PaginationType oPagination = new PaginationType();
            oPagination.EntriesPerPage = 200;
            //oPagination.EntriesPerPageSpecified = true;
            oPagination.PageNumber = 1;
            //oPagination.PageNumberSpecified = true;

            oGetSellerListCall.Pagination = oPagination;

            oGetSellerListCall.UserID = txtbx_userid.Text;

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
                        if (oItem.SKU != null)
                            szArray = oItem.SKU.Split(' ');
                        else
                            szArray[0] = "BLANK";
                        nQtySold = oItem.SellingStatus.QuantitySold;
                        nQtyAvail = oItem.Quantity - nQtySold;
                        nLotSize = oItem.LotSize;


                        szItemArray = szArray[0].Split(',');
                        szItemArray = szItemArray[0].Split('.');


                        if (oItem.SellingStatus.HighBidder != null)
                            szHighBidder = oItem.SellingStatus.HighBidder.UserID;
                        else
                            szHighBidder = " ";

                        if (oItem.SubTitle != null)
                            szSubTitle = oItem.SubTitle.Replace('\"', ' ');
                        else
                            szSubTitle = " ";

                        if (oItem.Title != null)
                            szTitle = oItem.Title.Replace('\"', ' ' );
                        else
                            szTitle = " ";



                        //ShippingServiceOptionsTypeCollection shippingCol = new ShippingServiceOptionsTypeCollection();
                        //shippingCol = oItem.ShippingDetails.ShippingServiceOptions;
                        ShippingServiceOptionsType[] opt = new ShippingServiceOptionsType[10];

                        if (oItem.ShippingDetails.ShippingServiceOptions.Count == 0)
                        {
                            szShippingType = "NOTKNOWN";
                        }
                        else
                        {
                            opt[0] = oItem.ShippingDetails.ShippingServiceOptions[0];
                            if (opt[0].ShippingServiceCost == null)
                                szShippingType = "FREE";
                            else
                            {
                                if (opt[0].ShippingServiceCost.Value > 0)
                                    szShippingType = "NOT FREE";
                                else
                                    szShippingType = "FREE";
                            }
                        }

                        nNumberofTotalListing = nNumberofTotalListing + 1;
                        //oItem.ShippingDetails.ShippingServiceOptions.
                        //if (oItem.ShippingDetails.ShippingServiceOptions.IndexO == ShippingTypeCodeType.Free)
                        //if (oItem.ShippingDetails.ShippingType == ShippingTypeCodeType.Free)
                        //    szShippingType = "FREE";

                        if (oItem.SellingStatus.HighBidder != null)
                        {
                            /*if (!(chkbx_OnlyRelistOnes.Checked))
                            {
                                dataGridView1.Rows.Add(oItem.ItemID, oItem.ListingType, oItem.Title, oItem.SubTitle, oItem.ListingDetails.StartTime.ToShortDateString(), oItem.ListingDetails.EndTime.ToShortDateString(), oItem.SellingStatus.CurrentPrice.Value, oItem.SellingStatus.HighBidder.UserID);
                            }*/
                            nNumberofSoldListing = nNumberofSoldListing + 1;
                            nTotalAmount = nTotalAmount + Convert.ToDouble(oItem.SellingStatus.CurrentPrice.Value);

                        }
                        else
                        {
                            if (oItem.ListingDetails.RelistedItemID == null)
                            {
                              //  dataGridView1.Rows.Add(oItem.ItemID, oItem.ListingType, oItem.Title, oItem.SubTitle, oItem.ListingDetails.StartTime.ToShortDateString(), oItem.ListingDetails.EndTime.ToShortDateString(), oItem.SellingStatus.CurrentPrice.Value, "DNS");
                                nEligibleItemForRelist += 1;
                            }
                            else
                                nAlreadyRelistedCount += 1;
                        }
                        /**/
                        /*Get the data from the inventory header so that we can load this main db*/
                        /*************************************************************************/
                        szSelectString = " ";
                        int outnumber = 0;
                        //jdInvShipDate = new DateTime(0);
                        
                        if (int.TryParse(szItemArray[0].ToString(), out outnumber))
                        //if (int.TryParse(szItemArray[0].ToString()), out value)
                        {
                            szSelectString = "Select * from InventoryHeader where INVITEM = " + szItemArray[0] ;
                            OleDbCommand cmd_InvMon = new OleDbCommand(szSelectString, conn_newdb2);
                            OleDbDataReader reader_InvMon = cmd_InvMon.ExecuteReader();
                            while (reader_InvMon.Read())
                            {
                                if (reader_InvMon != null)
                                {
                                    if ((reader_InvMon["INVDATE"].ToString() != null) && reader_InvMon["INVDATE"].ToString() != " " && reader_InvMon["INVDATE"].ToString() != "")
                                        jddate = Convert.ToDateTime(reader_InvMon["INVDATE"].ToString());
                                    if ((reader_InvMon["INVSOLDDATE"].ToString() != null) && reader_InvMon["INVSOLDDATE"].ToString() != " " && reader_InvMon["INVSOLDDATE"].ToString() != "")
                                        jdInvShipDate = Convert.ToDateTime(reader_InvMon["INVSOLDDATE"].ToString());
                                    else
                                        jdInvShipDate = Convert.ToDateTime("01/01/1974");
                                    if ((reader_InvMon["INVLISTEDDATE"].ToString() != null) && reader_InvMon["INVLISTEDDATE"].ToString() != " " && reader_InvMon["INVLISTEDDATE"].ToString() != "")
                                        jdListedDate = Convert.ToDateTime(reader_InvMon["INVLISTEDDATE"].ToString());
                                    szInventoryCamera = reader_InvMon["INVCAMERA"].ToString();
                                    szInventoryCategory = reader_InvMon["INVHEADER"].ToString();
                                    szInventoryLocation = reader_InvMon["INVLOCATION"].ToString();
                                    szInventorySource = reader_InvMon["INVCHECKINDATE"].ToString();
                                    dInvPrice = Convert.ToDouble(reader_InvMon["INVPRICE"].ToString());
                                }
                                break;
                            }
                        }
                        /*************************************************************************/
                        szDescription = "";
                        //szDescription = oItem.Description;
                        //szDescription = szDescription.Replace("\"", "\"\"");
                        
                        if (CheckRecordExistence(szItemArray[0], oItem.ItemID))
                        {
                            
                           //Update
                            szInsertString = "";
                            szInsertString = "Update EbayAnalysis Set " +
                                            "SoldDate = " + "\"" + oItem.ListingDetails.EndTime.AddHours(-7) + "\"," +
                                            "ListedDate = " + "\"" + oItem.ListingDetails.StartTime.AddHours(-7) + "\"," +
                                            "HighBidder = " + "\"" + szHighBidder + "\"," +
                                            "SoldPrice = " + oItem.SellingStatus.CurrentPrice.Value + "," +
                                            "Description = " + "\"" + szDescription + "\"," +
                                            "Category = " + "\""+ oItem.PrimaryCategory.CategoryID +"\"," +
                                            "CategoryDescription = " + "\""+oItem.PrimaryCategory.CategoryName+"\","+
                                            "ShippingType = " + "\"" + szShippingType + "\"," +
                                            "InventoryDate = " + "\"" + jddate + "\"," +
                                            "InventoryShipDate = " + "\"" + jdInvShipDate + "\"," +
                                            //"InventoryListedDate = " + "\"" + jdListedDate + "\"," +
                                            "InventoryCategory = " + "\"" + szInventoryCategory + "\","+
                                            "InventoryCamera = " + "\"" + szInventoryCamera + "\"," +
                                            "InventoryLocation = " + "\"" + szInventoryLocation + "\"," +
                                            "InventorySource = " + "\"" + szInventorySource + "\"," +
                                            "InventoryPrice = " + dInvPrice + ","+
                                            "QtySold = " + nQtySold+","+
                                            "QtyAvailable = " + nQtyAvail + "," +
                                            "LotSize = " + nLotSize +
                                            " Where ( CustomItemNumber = "
                                            + "\"" + szItemArray[0] + "\"" + "AND "
                                            + "EbayItemNumber = "
                                            + "\"" + oItem.ItemID + "\""+
                                            ")";
                        }
                        else
                        {
                            szInsertString = "";
                            szInsertString = "insert into EbayAnalysis (" +
                                            "CustomItemNumber," +
                                            "EbayItemNumber," +
                                            "SoldDate," +
                                            "ListedDate," +
                                            "HighBidder," +
                                            "StartingPrice,"+
                                            "SoldPrice,"+
                                            "NumberOfDays,"+
                                            "Title,"+
                                            "SubTitle,"+
                                            "Description,"+
                                            "Category," + 
                                            "CategoryDescription," + 
                                            "ShippingType," +
                                            "InventoryDate," +
                                            "InventoryShipDate," +
                                            "InventoryListedDate," +
                                            "InventoryCategory," +
                                            "InventoryCamera," +
                                            "InventoryLocation," +
                                            "InventorySource," +
                                            "InventoryPrice," +
                                            "QtySold," +
                                            "QtyAvailable," +
                                            "LotSize" +
                                            ") VALUES ( "
                                            + "\"" + szItemArray[0] + "\"," +
                                            oItem.ItemID + "," +
                                            "\"" + oItem.ListingDetails.EndTime.AddHours(-7) + "\"," +
                                            "\"" + oItem.ListingDetails.StartTime.AddHours(-7) + "\","+
                                            "\"" + szHighBidder + "\"," + 
                                            oItem.StartPrice.Value + ","+
                                            oItem.SellingStatus.CurrentPrice.Value + ","+
                                            "0" + "," +
                                            "\"" + szTitle + "\"" + "," +
                                            "\""+ szSubTitle +"\""+ "," +
                                            "\"" + szDescription + "\"," +
                                            "\"" + oItem.PrimaryCategory.CategoryID + "\"," +
                                            "\"" + oItem.PrimaryCategory.CategoryName + "\"," +
                                            "\"" + szShippingType + "\","+
                                            "\"" + jddate + "\"," +
                                            "\"" + jdInvShipDate + "\"," +
                                            "\"" + jdListedDate + "\"," +
                                            "\"" + szInventoryCategory + "\"," +
                                            "\"" + szInventoryCamera + "\"," +
                                            "\"" + szInventoryLocation + "\"," +
                                            "\"" + szInventorySource + "\"," +
                                            dInvPrice + ","+
                                            nQtySold + "," +
                                            nQtyAvail + "," +
                                            nLotSize +
                                            ")";
                        }
                        OleDbCommand cmd6 = new OleDbCommand(szInsertString, conn_newdb);
                        cmd6.ExecuteNonQuery();
                        nCount++;
                        label1.Text = nCount.ToString();
                        label1.Refresh();

                    }
                    pagenumber += 1;
                }
                conn_newdb.Close();
                conn_newdb2.Close();
                //pagenumber += 1;

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
        
        private void btn_loadEbayData_Click(object sender, EventArgs e)
        {
            GetSellerListOfItems();
        }

        private bool CheckItemShipped(string szCustomLabel, OleDbConnection invdbconn)
        {
            string szSoldDate = "";
            bool bRetValue = false;
            string szSelectString = "";
            long nCustomLabel = 0;
            string[] szArray = new string[10];

            szArray = szCustomLabel.Split('_');
            szArray = szArray[0].Split(',');
            if (szArray[0] == "BLANK" || szArray[0] =="Lister")
                nCustomLabel = 0;
            else
                try
                {
                    nCustomLabel = Convert.ToInt64(szArray[0]);
                }
                catch
                {
                    nCustomLabel = 0;
                }

            szSelectString = "Select * from InventoryHeader where INVITEM = " + nCustomLabel;
            OleDbCommand cmd = new OleDbCommand(szSelectString, invdbconn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                szSoldDate = reader["INVSOLDDATE"].ToString();
                if (szSoldDate != "" && szSoldDate != null &&szSoldDate!=" ") 
                    bRetValue = true;
                //if (reader["INVSOLDDATE"].ToString()!= " " && reader["INVSOLDDATE"].ToString()!=null );
                //    bRetValue = true;
                break;
            }

            reader.Close();
            return bRetValue;

        }
        private void btn_loaddata_Click(object sender, EventArgs e)
        {
            string szShippingStatus = "";
            string szError = "";
            string szSelectString = "";
            dataGridView1.Rows.Clear();
            Cursor.Current = Cursors.WaitCursor;
            DateTime dtEbayEndDate = new DateTime();
            int nActiveCount=0;

            GetEbayTime();

            System.Data.OleDb.OleDbConnection conn_newdb = new System.Data.OleDb.OleDbConnection();
            conn_newdb.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" + "Data source= " + txtbx_dbpath.Text;

            System.Data.OleDb.OleDbConnection conn_Invdb = new System.Data.OleDb.OleDbConnection();
            conn_Invdb.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" + "Data source= " + txtbx_InvDBPath.Text;

            try
            {
                conn_newdb.Open();
                conn_Invdb.Open();
            }
            catch (Exception)
            {
                szError = "Failed";
            }
            szSelectString = "";
            szSelectString = "Select * from EbayAnalysis order by CustomItemNumber";
                            //Set " +
                            //"SoldDate = " + "\"" + oItem.ListingDetails.EndTime + "\"," +
                            //"ListedDate = " + "\"" + oItem.ListingDetails.StartTime + "\"," +
                            //"HighBidder = " + "\"" + szHighBidder + "\"," +
                            //"SoldPrice = " + oItem.SellingStatus.CurrentPrice.Value + //"," +
                            //" Where ( CustomItemNumber = "
                            //+ "\"" + szItemArray[0] + "\"" + "AND "
                            //+ "EbayItemNumber = "
                            //+ "\"" + oItem.ItemID + "\"" +
                            //")";

            OleDbCommand cmd = new OleDbCommand(szSelectString, conn_newdb);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (chkbx_Active.Checked)
                {
                    dtEbayEndDate=(DateTime)reader["SoldDate"];
                    if (datepick_ebay.Value <= dtEbayEndDate)
                    {
                        nActiveCount++;
                        if (CheckItemShipped(reader["CustomItemNumber"].ToString(), conn_Invdb))
                            szShippingStatus = "Shipped";
                        else
                            szShippingStatus = " ";
                        dataGridView1.Rows.Add(reader["CustomItemNumber"].ToString(), reader["EbayItemNumber"].ToString(), reader["ListedDate"].ToString(),reader["SoldDate"].ToString(),
                                   reader["HighBidder"].ToString(),szShippingStatus,reader["ShippingType"].ToString(),reader["Title"].ToString(),reader["SubTitle"].ToString(), reader["Description"].ToString());
                        
                    }

                }
                else
                {
                    if (CheckItemShipped(reader["CustomItemNumber"].ToString(), conn_Invdb))
                        szShippingStatus = "Shipped";
                    else
                        szShippingStatus = " ";

                    dataGridView1.Rows.Add(reader["CustomItemNumber"].ToString(), reader["EbayItemNumber"].ToString(), reader["ListedDate"].ToString(),reader["SoldDate"].ToString(),
                                   reader["HighBidder"].ToString(), szShippingStatus,reader["ShippingType"].ToString(),reader["Title"].ToString(),reader["SubTitle"].ToString(),reader["Description"].ToString());
                    
                }
                lbl_ActiveListing.Text=nActiveCount.ToString();
            }
            conn_newdb.Close();
            conn_Invdb.Close();
        }

        private void btn_chkfordups_Click(object sender, EventArgs e)
        {
            int nRowCount = 0;
            int nCounter = 0;
            int nCounter2 = 0;
            string szCustomLabel = " ";
            string szCustomLabel2 = " ";

            nRowCount = dataGridView1.RowCount;
            while (nCounter < nRowCount-1)
            {
                szCustomLabel=dataGridView1.Rows[nCounter].Cells[0].Value.ToString();
                //Now check each row for duplicate
                nCounter2 = 0;
                DataGridViewRow theRow = dataGridView1.Rows[dataGridView1.Rows[nCounter].Index];
                theRow.DefaultCellStyle.BackColor = Color.Empty;
                while (nCounter2 < nRowCount - 1)
                {
                    szCustomLabel2 = dataGridView1.Rows[nCounter2].Cells[0].Value.ToString();
                    //Now check each row for duplicate
                    if (nCounter == nCounter2)
                    {
                    }
                    else
                    {
                        if (nCounter2 > nCounter)
                        {
                            if (szCustomLabel == szCustomLabel2)
                            {
                                theRow = dataGridView1.Rows[dataGridView1.Rows[nCounter].Index];
                                theRow.DefaultCellStyle.BackColor = Color.Red;
                                break;
                            }
                        }
                    }
                    nCounter2++;
                }
                

                nCounter++;
            }
        }
    }
}