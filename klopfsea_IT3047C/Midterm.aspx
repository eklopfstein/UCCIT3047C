<%------------------------------------------------------------------------------
 - Elijah Klopfstein                                                           -
 - klopfsea@mail.uc.edu                                                        -
 - Midterm                                                                     -
 - Due: Febuary 26th 2020                                                      -
 - IT3047C Spring 2020                                                         -
 - HTML for the Midterm page                                                   -
 - Takes user through a series of questions to determine                       -
 - If Windows or Linux is a better OS for them                                 -
 - Reference: https://www.computerhope.com/issues/ch000575.htm                 -
-------------------------------------------------------------------------------%>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Midterm.aspx.cs" Inherits="Midterm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <main>
        <h2>Midterm</h2>
        <h3>Windows vs Linux</h3>
        <p>Windows is very popular but it has it's drawbacks. For people that find those drawbacks too much there is Linux.</p>
        <p>By ansrewing just a few questions we can help you decide wether Linux or Windows is better for you.</p>
        <p>If you want to read up on it and make your own decision you can look at <a href="https://www.computerhope.com/issues/ch000575.htm" target="_blank">this article by ComputerHope</a>.</p>
        <div runat="server" id="question1">
            <asp:Label ID="lblUser" runat="server" Text="What best describes who will be using the computer."></asp:Label>
            <br />
            <asp:DropDownList ID="ddlUser" runat="server">
                <asp:ListItem Text="Corporate" Value="1"></asp:ListItem>
                <asp:ListItem Text="Scientific" Value="1"></asp:ListItem>
                <asp:ListItem Text="Personal" Value="-1"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button ID="btnNext1" runat="server" Text="Next" OnClick="btnNext_Click" />
        </div>
        <div runat="server" id="question2" visible="false">
            <asp:Label ID="lblKnowledge" runat="server" Text="What best describes the level of knowldege on IT systems of the users'."></asp:Label>
            <br />
            <asp:DropDownList ID="ddlKnowledge" runat="server">
                <asp:ListItem Text="Low Level" Value="-1"></asp:ListItem>
                <asp:ListItem Text="Moderate" Value="0"></asp:ListItem>
                <asp:ListItem Text="Advandaced" Value="1"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button ID="btnNext2" runat="server" Text="Next" OnClick="btnNext_Click" />
        </div>
        <div runat="server" id="question3" visible="false">
            <asp:Label ID="lblMicrosoft" runat="server" Text="Will the users need access to Microsoft software?"></asp:Label>
            <br />
            <asp:DropDownList ID="ddlMicrosoft" runat="server">
                <asp:ListItem Text="Yes" Value="-6"></asp:ListItem>
                <asp:ListItem Text="Would like but can do without" Value="-1"></asp:ListItem>
                <asp:ListItem Text="No" Value="1"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button ID="btnNext3" runat="server" Text="Next" OnClick="btnNext_Click" />
        </div>
        <div runat="server" id="question4" visible="false">
            <asp:Label ID="lblCost" runat="server" Text="Will the users be willing to pay for the OS?"></asp:Label>
            <br />
            <asp:DropDownList ID="ddlCost" runat="server">
                <asp:ListItem Text="Yes" Value="-1"></asp:ListItem>
                <asp:ListItem Text="No" Value="1"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button ID="btnNext4" runat="server" Text="Next" OnClick="btnNext_Click" />
        </div>
        <div runat="server" id="question5" visible="false">
            <asp:Label ID="lblSoftware" runat="server" Text="Which statement describes the kind of software that will be used the best?"></asp:Label>
            <br />
            <asp:DropDownList ID="ddlSoftware" runat="server">
                <asp:ListItem Text="In house software" Value="1"></asp:ListItem>
                <asp:ListItem Text="Large variety" Value="0"></asp:ListItem>
                <asp:ListItem Text="Mainstream software" Value="-1"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        </div>
        <div runat="server" id="divWindows" visible="false">
            <p>Given your answers we believe that you should use Windows. Windows cost money but is what most people use so people will most likely know how to use it and has a large range of support.</p>
        </div>
        <div runat="server" id="divLinux" visible="false">
            <p>Given your answers we believe that you should use Linux. Linux is something most people do not know how to use so you might need to train people on it but it is free to use and gives you much more control over the device.</p>
        </div>
    </main>
</asp:Content>

