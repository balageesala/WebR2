using Braintree;
using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace IntellidateR1Web.web
{
    public partial class AlaCartePayment : System.Web.UI.Page
    {
        public String TrData;
        public Boolean TransactionSuccessful;
        public String ErrorMessage;

        public virtual void Page_Load(object sender, EventArgs args)
        {
            TransactionSuccessful = false;
            ErrorMessage = String.Empty;
            if (Session["OtherUserID"] != null && Session["CartType"] !=null)
            {
                try
                {
                    /// <summary>
                    ///  1 = Rematch (this is contain expire date) 2.5$
                    ///  2 = Compatability report 1$ (only one report for 1$)
                    ///  3 = facebook and linkedin contacts(mutual friends) 1$
                    ///  4 = read/deleted 0.5 $ (this is for 2 users conversations read/delete status)
                    /// </summary>
                    int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                    int _RematchID = Convert.ToInt32(Session["OtherUserID"]);
                    int _CartType = Convert.ToInt32(Session["CartType"]);
                    decimal _AlaCartPrice;
                    if (_CartType == 1)
                    {
                        _AlaCartPrice = Convert.ToDecimal(ConfigurationManager.AppSettings["ReMatchPrice"]);
                        divCartDetails.InnerHtml = "Ala cart type : Re-match.";
                        divCartPrice.InnerHtml = "Ala cart price : " + _AlaCartPrice.ToString();
                    }
                    else if (_CartType == 2)
                    {
                        _AlaCartPrice = Convert.ToDecimal(ConfigurationManager.AppSettings["CompatibilityReport"]);
                        divCartDetails.InnerHtml = "Ala cart type : Compatibility report.";
                        divCartPrice.InnerHtml = "Ala cart price : " + _AlaCartPrice.ToString();
                    }
                    else if (_CartType == 3)
                    {
                        _AlaCartPrice = Convert.ToDecimal(ConfigurationManager.AppSettings["FacebookLinkedIn"]);
                        divCartDetails.InnerHtml = "Ala cart type : Facebook / LinkedIn mutual contacts.";
                        divCartPrice.InnerHtml = "Ala cart price : " + _AlaCartPrice.ToString();

                    }
                    else if (_CartType == 4)
                    {
                        _AlaCartPrice = Convert.ToDecimal(ConfigurationManager.AppSettings["ReadDelete"]);
                        divCartDetails.InnerHtml = "Ala cart type : Read / Delete status";
                        divCartPrice.InnerHtml = "Ala cart price : " + _AlaCartPrice.ToString();
                    }
                    else
                    {
                        _AlaCartPrice = Convert.ToDecimal(ConfigurationManager.AppSettings["OtherPrice"]);
                        divCartPrice.InnerHtml = "Ala cart price : " + _AlaCartPrice.ToString();
                    }
                    

                    if (Request.Url.Query.Length > 0)
                    {
                        TransactionSuccessful = confirmTransparentRedirect();
                        ErrorMessage = "Problem with your credit card number or expiration date.";
                        if(TransactionSuccessful)
                        {
                            //add alacart details
                            new UserAlaCart().AddUserAlaCart(UserID, _RematchID, _CartType, _AlaCartPrice, DateTime.Now, DateTime.Now, false);
                            if (_CartType == 1)
                            {
                              ProfileRematch _BookRematch = new ProfileRematch().AddUserProfileRematch(UserID, _RematchID, DateTime.Now);
                              if (_BookRematch != null)
                              {
                                //after buy please clear session RematchID
                                  Session["OtherUserID"] = null;
                                  Session["CartType"] = null;
                              }
                            }
                            else if (_CartType == 2)
                            {
                               // Response.op.Redirect("CompatibilityReport?OtherUserID=" + _RematchID);
                                Response.Write("<script type='text/javascript'> window.open('CompatibilityReport?OtherUserID=" + _RematchID + "','_blank'); </script>");

                            }
                        }
                        

                        
                    }
                    else
                    {
                        TrData = buildTransparentRedirectData(Convert.ToDecimal("2.50"));
                    }

                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        public String buildTransparentRedirectData(decimal _Price)
        {
            var transactionRequest = new TransactionRequest
            {
                Amount = _Price
            };
            string SitePath = System.Configuration.ConfigurationManager.AppSettings["SitePath"].ToString();
            return braintreeGateway().Transaction.SaleTrData(transactionRequest, SitePath + "web/AlaCartePayment");
        }

        public Boolean confirmTransparentRedirect()
        {
            Result<Transaction> ChargeResult = braintreeGateway().TransparentRedirect.ConfirmTransaction(Request.Url.Query);
            Transaction transaction = ChargeResult.Target;
            return ChargeResult.IsSuccess();
        }

        public BraintreeGateway braintreeGateway()
        {
            return new BraintreeGateway
            {
                Environment = Braintree.Environment.SANDBOX,
                MerchantId = "9t27q2xvh6hwxy6q",
                PublicKey = "ctktqbfg7438wyfy",
                PrivateKey = "67eee8ea5fdb5ec57bd14074fb044492"
            };
        }
    }
}