<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoadUserPhoto.aspx.cs" Inherits="IntelliWebR1.web.service.LoadUserPhoto" %>

<%@ OutputCache VaryByParam="ouid" Duration="100000" %>
<%@ Register Src="~/web/uc/convuserpic.ascx" TagPrefix="uc1" TagName="convuserpic" %>


<uc1:convuserpic runat="server" ID="convuserpic" />
