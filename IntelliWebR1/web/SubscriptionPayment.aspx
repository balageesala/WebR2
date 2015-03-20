<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubscriptionPayment.aspx.cs" Inherits="IntellidateR1Web.web.SubscriptionPayment" %>

<!DOCTYPE html>
<script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>

<form id="NewPaymentForm" method="post" action="<%= braintreeGateway().TransparentRedirect.Url %>">
        <div style="float: left;width: 100%;">
		<% if (TransactionSuccessful) { %>
			<h1>Thank you!</h1>
            <div><input type="button" id="BtnGotoHomePage" value="Go to home page"/></div>
		<% } else { %>
			<% if (ErrorMessage.Length > 0) { %>
			<p style="color:red;"><%= ErrorMessage %></p>
			<% } %>
			<input id="tr_data" name="tr_data" type="hidden" value="<%= TrData %>" />
			<div id="divSubcriptionType" runat="server"></div>
            <div id="divSubcriptionDate" runat="server"></div>
            <div id="divSubcriptionPrice" runat="server"></div>
			<p>
				<label>Credit Card Number</label>
				<input type="text" value="4111111111111111" name="transaction[credit_card][number]" />
			</p>
			
			<p>
				<label>Expiration Date</label>
				<input type="text" value="10/14" name="transaction[credit_card][expiration_date]" />
               
			</p>
			
			<input type="submit" value="Pay" />
		<% } %>
            </div>
	</form>
<script type="text/javascript">

    $(document).ready(function () {
        $("#BtnGotoHomePage").click(function () {
            window.location.href = "Home";
        });
    });


</script>
