<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET SHA256 Calculator</h1>
        <p class="lead">Create Export Datafile with following entry just enter any String for name of person and submit</p>
        <asp:TextBox ID="TextBox1" runat="server" class="btn btn-warning btn-lg" ></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Generate File" OnClick="Button1_Click" class="btn btn-primary btn-lg"/>
    </div>
</asp:Content>
