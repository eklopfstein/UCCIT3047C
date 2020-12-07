<%------------------------------------------------------------------------------
 - Elijah Klopfstein                                                           -
 - klopfsea@mail.uc.edu                                                        -
 - Assigment 08                                                                -
 - Due: April 5th 2020                                                         -
 - IT3047C Spring 2020                                                         -
 - HTML for the assignment08 page                                              -
 - Loads all manufacturers and products into a treeview                        -
-------------------------------------------------------------------------------%>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Assignment08.aspx.cs" Inherits="Assignment08" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <main>
        <h2>Assignment08</h2>
        <h3>Populate a TreeView With Database</h3>
        <p>Create a page that access the database to populate a treeview.</p>
        <p>The TreeView will contain nodes of manufacturers and subnodes of their products.</p>
        <br />
        <asp:Label runat="server" ID="lblError" Visible="false"></asp:Label>
        <asp:TreeView runat="server" ID="tvManufacturers" ImageSet="Arrows">
            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
            <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
            <ParentNodeStyle Font-Bold="False" />
            <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px" VerticalPadding="0px" />
        </asp:TreeView>
    </main>
</asp:Content>

