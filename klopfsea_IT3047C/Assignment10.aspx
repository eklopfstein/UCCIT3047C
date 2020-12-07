<%------------------------------------------------------------------------------
 - Elijah Klopfstein                                                           -
 - klopfsea@mail.uc.edu                                                        -
 - Assignment 10                                                               -
 - Due: April 19th 2020                                                        -
 - IT3047C Spring 2020                                                         -
 - HTML for the Assignment 10 page                                             -
 - Takes in user query and displays results                                    -
 -  https://fdc.nal.usda.gov/api-guide.html                                    -
-------------------------------------------------------------------------------%>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Assignment10.aspx.cs" Inherits="Assignment10" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <main>
        <h2>Assignment10</h2>
        <h3>Query an API</h3>
        <p>Queries the FDC API to display food details. <a href="https://fdc.nal.usda.gov/api-guide.html" target="_blank">API link</a> </p>
        <p>Type in a food item, manufacturer, or retailer to get results.</p>
        <br />

        <asp:TextBox ID="txtQuery" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
        <br />
        <asp:Label ID="lblError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
        <asp:Table ID="tblResults" runat="server" BorderColor="Black" BorderStyle="Solid" HorizontalAlign="Center">
        </asp:Table>
    </main>
</asp:Content>

