<%------------------------------------------------------------------------------
 - Elijah Klopfstein                                                           -
 - klopfsea@mail.uc.edu                                                        -
 - Assigment 04                                                                -
 - Due: Febuary 19th 2020                                                      -
 - IT3047C Spring 2020                                                         -
 - HTML for the assignment04 page                                              -
 - Takes user's basic billing info (no card info yet)                          -
-------------------------------------------------------------------------------%>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Assignment04.aspx.cs" Inherits="Assignment04_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <main>
        <h2>Assignment04</h2>
        <h3>Session Variables</h3>
        <p>Create pages that take user information and stores them with the session object.</p>
        <p>By the end of the form have a C# object that encapsulates all the information given and store that in the session object.</p>
        <asp:Label ID="lblName" runat="server" Text="Name: "></asp:Label>
        <asp:TextBox ID="tbName" runat="server">Jeffery Bauer</asp:TextBox>
        <br />
        <asp:Label ID="lblAddress" runat="server" Text="Adress: "></asp:Label>
        <asp:TextBox ID="tbAddress" runat="server">4200 University Ln</asp:TextBox>
        <br />
        <asp:Label ID="lblPhone" runat="server" Text="Phone Number: "></asp:Label>
        <asp:TextBox ID="tbPhone" runat="server">(513)732-5200</asp:TextBox>
        <br />
        <asp:Label ID="lblCity" runat="server" Text="City: "></asp:Label>
        <asp:TextBox ID="tbCity" runat="server">Batavia</asp:TextBox>
        <br />
        <asp:Label ID="lblState" runat="server" Text="State: "></asp:Label>
        <asp:TextBox ID="tbState" runat="server">Ohio</asp:TextBox>
        <br />
        <asp:Label ID="lblZip" runat="server" Text="Zip Code: "></asp:Label>
        <asp:TextBox ID="tbZip" runat="server">45103</asp:TextBox>
        <br />
        <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" />
    </main>
</asp:Content>

