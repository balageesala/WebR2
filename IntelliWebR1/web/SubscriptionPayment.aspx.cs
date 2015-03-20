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
    public partial class SubscriptionPayment : System.Web.UI.Page
    {
        public String TrData;
        public Boolean TransactionSuccessful;
        public String ErrorMessage;

        public virtual void Page_Load(object sender, EventArgs args)
        {
            TransactionSuccessful = false;
            ErrorMessage = String.Empty;
            if (Session["days"] != null && Session["Type"] != null)
            {
                try
                {
                    int _NoOfDays= Convert.ToInt32(Session["days"]);
                    int _SubType = Convert.ToInt32(Session["Type"]);
                    int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                    int _NoOfMonths = Convert.ToInt32(_NoOfDays / 30);
                    decimal _Price;
                    if (_SubType == 1)
                    {
                        decimal _TopSubscriptionRate = Convert.ToDecimal(ConfigurationManager.AppSettings["TopSubscription"]);
                        _Price = (decimal)(_TopSubscriptionRate * _NoOfMonths);
                        divSubcriptionType.InnerHtml = "Subcription Type: Top Subcription";
                    }
                    else
                    {
                        decimal _BasicSubscriptionRate = Convert.ToDecimal(ConfigurationManager.AppSettings["BasicSubscription"]);
                        _Price = (decimal)(_BasicSubscriptionRate * _NoOfMonths);
                        divSubcriptionType.InnerHtml = "Subcription Type: Basic Subcription";
                    }


                    divSubcriptionPrice.InnerHtml="Total Price : " + _Price.ToString();

                    DateTime _StartDate = DateTime.Now;
                    DateTime _EndDate = DateTime.Now.AddDays(_NoOfDays);
                    divSubcriptionDate.InnerHtml="Your subscription valid :  " + _StartDate.ToShortDateString() + " to " + _EndDate.ToShortDateString();

                    if (Request.Url.Query.Length > 0)
                    {
                        TransactionSuccessful = confirmTransparentRedirect();
                        ErrorMessage = "Problem with your credit card number or expiration date.";
                        //check payment is done or not
                        if (TransactionSuccessful)
                        {   
                            UserSubscriptionDetails _AddDetails = new UserSubscriptionDetails().AddUserSubscriptionDetails(UserID, _SubType, _StartDate, _EndDate);
                            if (_AddDetails != null)
                            {
                                //sucessfull subscription
                                //clear session
                                Session["Mounth"] = null;
                                Session["Type"] = null;
                            }
                            else
                            {
                                //refound maney back to end user
                            }
                        }
                       
                    }
                    else
                    {
                        TrData = buildTransparentRedirectData(Convert.ToDecimal(_Price));
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
            return braintreeGateway().Transaction.SaleTrData(transactionRequest, SitePath + "web/SubscriptionPayment");
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