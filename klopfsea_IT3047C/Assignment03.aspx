<%------------------------------------------------------------------------------
 - Elijah Klopfstein                                                           -
 - klopfsea@mail.uc.edu                                                        -
 - Assigment 03                                                                -
 - Due: Febuary 5th 2020                                                       -
 - IT3047C Spring 2020                                                         -
 - HTML for the assignment03 page                                              -
 - Manages a dropdown list and two listboxes to allow user to create a car     -
 - After creation user is displayed their creation                             -
-------------------------------------------------------------------------------%>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Assignment03.aspx.cs" Inherits="Assignment03" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <main>
        <h2>Assignment03</h2>
        <h3>Dynamic Item Control</h3>
        <p>Create a page with a dropdown list to pick a car model and then allow users to pick extra options based on selected model.</p>
        <p>Once user is done adding optional details display a new page that contains car information.</p>
        <asp:DropDownList ID="ddlModels" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlModels_SelectedIndexChanged">
            <asp:ListItem Text="Select A Model"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />

        <asp:Table ID="tblOptions" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:ListBox ID="lbUnselected" runat="server" SelectionMode="Multiple" BackColor="#ff2400"></asp:ListBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="btnSelectAll" Text=">>" runat="server" OnClick="changeOptions" BackColor="#ff2400" CssClass="pure-button" />
                    <br />
                    <asp:Button ID="btnUnselectAll" Text="<<" runat="server" OnClick="changeOptions" BackColor="#ff2400" CssClass="pure-button" />
                    <br />
                    <asp:Button ID="btnSelectSelected" Text=">" runat="server" OnClick="changeOptions" BackColor="#ff2400" CssClass="pure-button" />
                    <br />
                    <asp:Button ID="btnUnselectSelected" Text="<" runat="server" OnClick="changeOptions" BackColor="#ff2400" CssClass="pure-button" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:ListBox ID="lbSelected" runat="server" SelectionMode="Multiple" BackColor="#ff2400"></asp:ListBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Button ID="btnDone" Text="Done" runat="server" OnClick="btnDone_Click" Style="float: left" />
        <asp:Label ID="lblDetails" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Button ID="btnReConfig" runat="server" Text="Reconfigure" Visible="false" OnClick="btnReConfig_Click" CssClass="pure-button" />
    </main>
</asp:Content>

