<%------------------------------------------------------------------------------
 - Elijah Klopfstein                                                           -
 - klopfsea@mail.uc.edu                                                        -
 - Assigment 02                                                                -
 - Due: January 29th 2020                                                      -
 - IT3047C Spring 2020                                                         -
 - HTML for the Assignment02 page                                              -
 - Shows the assignment descritpion, textbox for tab amount,                   -
 - Link to css page, button to set tab amount, and multiview aspects           -
 - You are limited to 1000 views for performance reasons                       -
 - Uses Pure CSS https://purecss.io/                                           -
 - Reference to stylesheet can be found on masterpage                          -
-------------------------------------------------------------------------------%>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Assignment02.aspx.cs" Inherits="Assignment2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <main>
        <h2>Assignment02</h2>
        <p>Create a page with a text box, button, and multiview. On button press create as many tabs as specified in the textbox in the multiview. Have a dropdown menu for navigating the views and content in the views to differentiate. Lastly, use an online CSS libary to style the page and provide a link.</p>
        <p>I used Pure CSS to style this page. Link: <a href="https://purecss.io/" target="_blank">https://purecss.io/</a></p>
        <h3>MultiView Tab Control</h3>
        <p>You are limited to 1000 views</p>
        <asp:TextBox runat="server" ID="tbAmount"></asp:TextBox>
        <asp:Button runat="server" Text="Set Tab Amount" ID="btnGenerate" OnClick="btnGenerate_Click" CssClass="pure-button" />
        <table>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlView" runat="server" BorderStyle="None" BackColor="#000000" ForeColor="#DF2500" AutoPostBack="True" Font-Bold="True" Font-Size="1em" OnSelectedIndexChanged="ddlView_SelectedIndexChanged">
                        <asp:ListItem Text="Set Amount of views!"></asp:ListItem>
                    </asp:DropDownList>
                    <div id="Multiview">
                        <asp:PlaceHolder ID="phMultiView" runat="server"></asp:PlaceHolder>
                    </div>
                </td>
            </tr>
        </table>
    </main>
</asp:Content>

