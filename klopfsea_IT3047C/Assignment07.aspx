<%------------------------------------------------------------------------------
 - Elijah Klopfstein                                                           -
 - klopfsea@mail.uc.edu                                                        -
 - Assigment 07                                                                -
 - Due: March 11th 2020                                                        -
 - IT3047C Spring 2020                                                         -
 - HTML for the assignment07 page                                              -
 - Allows user to create a store and add it to the database                    -
-------------------------------------------------------------------------------%>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Assignment07.aspx.cs" Inherits="Assignment07" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <main>
        <h2>Assignment07</h2>
        <h3>Adding to Database</h3>
        <p>Create a page where a user can create a store and set it's details and have it be added to the database.</p>
        <p>All fields, except Address 2, are required. Store Name must be unique.</p>
        <br />
        <div id="storeInfo" runat="server">
            <asp:Label ID="lblName" runat="server" Text="Store Name: "></asp:Label>
            <asp:TextBox ID="txbName" runat="server" MaxLength="200"></asp:TextBox>
            <br />
            <asp:Label ID="lblAddress" runat="server" Text="Store Address 1: "></asp:Label>
            <asp:TextBox ID="txbAddress" runat="server" MaxLength="200"></asp:TextBox>
            <br />
            <asp:Label ID="lblAddress2" runat="server" Text="Store Address 2: "></asp:Label>
            <asp:TextBox ID="txbAddress2" runat="server" MaxLength="200"></asp:TextBox>
            <br />
            <asp:Label ID="lblCity" runat="server" Text="Store City: "></asp:Label>
            <asp:TextBox ID="txbCity" runat="server" MaxLength="200"></asp:TextBox>
            <br />
            <asp:Label ID="lblState" runat="server" Text="Store State: "></asp:Label>
            <asp:DropDownList ID="ddlState" runat="server">
            </asp:DropDownList>
            <br />
            <asp:Label ID="lblCountry" runat="server" Text="Store Country: "></asp:Label>
            <asp:DropDownList ID="ddlCountry" runat="server">
            </asp:DropDownList>
            <br />
            <asp:Label ID="lblRegion" runat="server" Text="Store Region: "></asp:Label>
            <asp:DropDownList ID="ddlRegion" runat="server">
            </asp:DropDownList>
            <br />
            <asp:Label ID="lblZip" runat="server" Text="Store Zip Code: "></asp:Label>
            <asp:TextBox ID="txbZip" runat="server" MaxLength="5"></asp:TextBox>
            <br />

            <asp:UpdatePanel ID="udpManagers" runat="server">
                <ContentTemplate>
                    <asp:Label ID="lblOnline" runat="server" Text="Online Store: "></asp:Label>
                    <br />
                    <asp:RadioButton GroupName="isOnline" ID="rbtOnline" Text="Yes" runat="server" AutoPostBack="true" OnCheckedChanged="isOnline_CheckedChanged" />
                    <br />
                    <asp:RadioButton GroupName="isOnline" ID="rbtNotOnline" Text="No" runat="server" Checked="true" AutoPostBack="true" OnCheckedChanged="isOnline_CheckedChanged" />
                    <br />
                    <asp:Label ID="lblManager" runat="server" Text="Store Manager: "></asp:Label>
                    <asp:DropDownList ID="ddlManagers" runat="server">
                    </asp:DropDownList>
                    <br />
                </ContentTemplate>
            </asp:UpdatePanel>

            <asp:Label runat="server" Text="Components Not Used"></asp:Label>
            <asp:Label runat="server" Text="Components Used" Style="padding-left: 200px"></asp:Label>
            <asp:UpdatePanel ID="udpContents" runat="server">
                <ContentTemplate>
                    <asp:Table ID="tblOptions" runat="server" Style="margin-left: auto; margin-right: auto;">
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
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>

        <asp:Label ID="lblError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
        <asp:Button ID="btnDone" Text="Done" runat="server" OnClick="btnDone_Click" />
        <asp:Label ID="lblDetails" runat="server" Text="Store has been made!" Visible="false"></asp:Label>
        <asp:Button ID="btnNew" runat="server" Text="Make a new store" Visible="false" OnClick="btnNew_Click" CssClass="pure-button" />


        <asp:SqlDataSource ID="components" runat="server" ConnectionString="<%$ ConnectionStrings:GroceryStoreSimulatorAdderConnectionString %>" SelectCommand="SELECT * FROM [tStoreComponent] ORDER BY [StoreComponentID]"></asp:SqlDataSource>

    </main>
</asp:Content>

