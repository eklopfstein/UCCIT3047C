<%------------------------------------------------------------------------------
 - Elijah Klopfstein                                                           -
 - klopfsea@mail.uc.edu                                                        -
 - Assigment 09                                                                -
 - Due: April 12th 2020                                                        -
 - IT3047C Spring 2020                                                         -
 - HTML for the assignment09 page                                              -
 - Gives fields for users to input data and has client-side validation         -
-------------------------------------------------------------------------------%>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Assignment09.aspx.cs" Inherits="Assignment09" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <main>
        <h2>Assignment09</h2>
        <h3>Validate User Input</h3>
        <p>Using regex, validate user input on both client and server side.</p>
        <br />
        <div>
            <table border="0" title="Job Application">
                <tr>
                    <td>
                        <label>Last Name</label>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ErrorMessage="Last Name Required" ValidationGroup="vgForm" ControlToValidate="txtLastName"></asp:RequiredFieldValidator>
                        <asp:TextBox runat="server" ID="txtLastName"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>First Name</label>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ErrorMessage="First Name Required" ValidationGroup="vgForm" ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>
                        <asp:TextBox runat="server" ID="txtFirstName"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>City</label>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvCity" runat="server" ErrorMessage="City Required" ValidationGroup="vgForm" ControlToValidate="txtCity"></asp:RequiredFieldValidator>
                        <asp:TextBox runat="server" ID="txtCity"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>State</label>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvState" runat="server" ErrorMessage="State Required" ValidationGroup="vgForm" ControlToValidate="txtState"></asp:RequiredFieldValidator>
                        <asp:TextBox runat="server" ID="txtState"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Zip Code</label>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvZipCode" runat="server" ErrorMessage="Zip Code Required" ValidationGroup="vgForm" ControlToValidate="txtZipCode"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revZipCode" runat="server" ErrorMessage="Zip Code Invalid" ValidationExpression="^\d{5}$" ValidationGroup="vgForm" ControlToValidate="txtZipCode"></asp:RegularExpressionValidator>
                        <asp:TextBox runat="server" ID="txtZipCode"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>M Number</label>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvMNumber" runat="server" ErrorMessage="M Number Required" ValidationGroup="vgForm" ControlToValidate="txtMNumber"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revMNumber" runat="server" ErrorMessage="M Number Invalid" ValidationExpression="^M\d{8}$" ValidationGroup="vgForm" ControlToValidate="txtMNumber"></asp:RegularExpressionValidator>
                        <asp:TextBox runat="server" ID="txtMNumber"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Major</label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtMajor"></asp:TextBox>
                        <asp:DropDownList runat="server" ID="ddlMajor"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>DOB</label>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvDOB" runat="server" ErrorMessage="DOB Required" ValidationGroup="vgForm" ControlToValidate="txtDOB"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revDOB" runat="server" ErrorMessage="DOB Invalid" ValidationExpression="^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$" ValidationGroup="vgForm" ControlToValidate="txtDOB"></asp:RegularExpressionValidator>
                        <asp:TextBox runat="server" ID="txtDOB"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button runat="server" ID="btnOK" Text="OK" OnClick="btnOK_Click" ValidationGroup="vgForm" /></td>
                </tr>

                <tr>
                    <td>
                        <asp:Button runat="server" ID="btnCheck" Text="Check Input" ValidationGroup="vgForm" /></td>
                </tr>
            </table>
        </div>
    </main>
</asp:Content>

