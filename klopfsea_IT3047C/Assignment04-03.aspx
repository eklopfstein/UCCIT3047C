<%------------------------------------------------------------------------------
 - Elijah Klopfstein                                                           -
 - klopfsea@mail.uc.edu                                                        -
 - Assigment 04                                                                -
 - Due: Febuary 19th 2020                                                      -
 - IT3047C Spring 2020                                                         -
 - HTML for the assignment04-03 page                                           -
 - Displays all of the given billing info in read-only                         -
-------------------------------------------------------------------------------%>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Assignment04-03.aspx.cs" Inherits="Assignment04_03" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <main>
        <h2>Assignment04</h2>
        <h3>Session Variables</h3>
        <p>Create pages that take user information and stores them with the session object.</p>
        <p>By the end of the form have a C# object that encapsulates all the information given and store that in the session object.</p>
        <asp:Label ID="lblName" runat="server" Text="Name: "></asp:Label>
        <asp:TextBox ID="tbName" runat="server" Enabled="false"></asp:TextBox>
        <br />
        <asp:Label ID="lblAddress" runat="server" Text="Adress: "></asp:Label>
        <asp:TextBox ID="tbAddress" runat="server" Enabled="false"></asp:TextBox>
        <br />
        <asp:Label ID="lblPhone" runat="server" Text="Phone Number: "></asp:Label>
        <asp:TextBox ID="tbPhone" runat="server" Enabled="false"></asp:TextBox>
        <br />
        <asp:Label ID="lblCity" runat="server" Text="City: "></asp:Label>
        <asp:TextBox ID="tbCity" runat="server" Enabled="false"></asp:TextBox>
        <br />
        <asp:Label ID="lblState" runat="server" Text="State: "></asp:Label>
        <asp:TextBox ID="tbState" runat="server" Enabled="false"></asp:TextBox>
        <br />
        <asp:Label ID="lblZip" runat="server" Text="Zip Code: "></asp:Label>
        <asp:TextBox ID="tbZip" runat="server" Enabled="false"></asp:TextBox>
        <br />
        <asp:Label ID="lblCard" runat="server" Text="Card Number: "></asp:Label>
        <asp:TextBox ID="tbCard" runat="server" Enabled="false"></asp:TextBox>
        <br />
        <asp:Label ID="lblExpire" runat="server" Text="Expiration Date: "></asp:Label>
        <asp:TextBox ID="tbExpire" runat="server" Enabled="false"></asp:TextBox>
        <br />
        <asp:Label ID="lblSecurity" runat="server" Text="Secuirty Code: "></asp:Label>
        <asp:TextBox ID="tbSecurity" runat="server" Enabled="false"></asp:TextBox>
        <br />
    </main>
</asp:Content>

