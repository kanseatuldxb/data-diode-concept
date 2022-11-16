<%@ Page Title="Retrive" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <asp:Button ID="Button1" runat="server" Text="Retrive" OnClick="Button1_Click" class="btn btn-primary btn-lg"/>
    <h3><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h3>
    
</asp:Content>
