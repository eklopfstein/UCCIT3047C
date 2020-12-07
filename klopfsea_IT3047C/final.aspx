<%------------------------------------------------------------------------------
 - Elijah Klopfstein                                                           -
 - klopfsea@mail.uc.edu                                                        -
 - Final Exam                                                                  -
 - Due: April 30th 2020                                                        -
 - IT3047C Spring 2020                                                         -
 - HTML for the Final Exam page                                                -
 - Takes in user messages an ecrypts them and decrypts messages                -
-------------------------------------------------------------------------------%>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Final.aspx.cs" Inherits="final" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <main>
        <h2>Final Exam</h2>
        <h3>Encrypt and Decrypt User Input</h3>
        <p>Using a scrambled ASCII alphabet we ecrypt and decrypt messages.</p>
        <p>A message file and mapping file is needed for decryption.</p>
        <p>To decrypt a message simply type in a 6+2 that has a message and hit decrypt.</p>
        <br />
        <asp:Table runat="server">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" HorizontalAlign="Right">
                    <asp:Label ID="lblID" runat="server" Text="Enter 6+2"></asp:Label>
                </asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
                    <asp:Label ID="lblSeed" runat="server" Text="Enter Seed"></asp:Label>
                    <asp:TextBox ID="txtSeed" runat="server"></asp:TextBox>
                    <asp:Button ID="btnSeed" runat="server" Text="New Seed" OnClick="btnSeed_Click" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" HorizontalAlign="Right">
                    <asp:Label ID="lblClearText" runat="server" Text="Enter clear text message"></asp:Label>
                </asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="txtClearText" runat="server" Height="187px" TextMode="MultiLine" Width="438px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" HorizontalAlign="Right">
                    <asp:Button ID="btnEncrypt" runat="server" Text="Encrypt and Write to File" OnClick="btnEncrypt_Click" />
                </asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="txtEncrypt" runat="server" Height="187px" TextMode="MultiLine" Width="438px" ReadOnly="True" ValidateRequestMode="Disabled"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" HorizontalAlign="Right">
                    <asp:Button ID="btnDecrypt" runat="server" Text="Read From File and Decrypt" OnClick="btnDecrypt_Click" />
                </asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="txtDecrypt" runat="server" Height="187px" TextMode="MultiLine" Width="438px" ReadOnly="True"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <h3>And Your Song</h3>
        <iframe width="560" height="315" src="https://www.youtube.com/embed/1T5NuI6Ai-o" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
    </main>
</asp:Content>

