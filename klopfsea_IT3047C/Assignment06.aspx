<%------------------------------------------------------------------------------
 - Elijah Klopfstein                                                           -
 - klopfsea@mail.uc.edu                                                        -
 - Assigment 06                                                                -
 - Due: March 4th 2020                                                         -
 - IT3047C Spring 2020                                                         -
 - HTML for the assignment06 page                                              -
 - Allows user to select a store and see it's status                           -
-------------------------------------------------------------------------------%>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Assignment06.aspx.cs" Inherits="Assignment06" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <main>
        <h2>Assignment06</h2>
        <h3>Database Variables & AJAX</h3>
        <p>Connect to the database and use the data in some creative way and use AJAX to keep it up to date.</p>
        <p>I will be allowing the user to select a store drom a dropdown list and see it's status.</p>
        <asp:UpdatePanel ID="updStores" runat="server">
            <ContentTemplate>
                <asp:DropDownList ID="ddlStores" runat="server" OnSelectedIndexChanged="ddlStores_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                <br />
                <asp:Label ID="lblSelectedStatus" runat="server" Text=""></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
    </main>
</asp:Content>

