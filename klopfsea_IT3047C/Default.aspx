<%------------------------------------------------------------------------------
 - Elijah Klopfstein                                                           -
 - klopfsea@mail.uc.edu                                                        -
 - Assigment 01                                                                -
 - Due: January 22nd 2020                                                      -
 - IT3047C Spring 2020                                                         -
 - HTML for the home page                                                      -
 - Will have a div for each assignment                                         -
 - Contains information about assignment and a link to the page(s)             -
-------------------------------------------------------------------------------%>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <main>
        <div id="assignment01">
            <h2>Assignment01</h2>
            <h3>Project Euler Problem 686</h3>
            <p>Create main page, current page, and create a second page that solves a Project Euler problem.</p>
            <asp:LinkButton ID="LbtnAssignment01" runat="server" OnClick="LbtnAssignment_Click">See Assignment Page</asp:LinkButton>
        </div>
        <div id="assignment02">
            <h2>Assignment02</h2>
            <h3>MultiView Tab Control</h3>
            <p>Create a page with a text box, button, and multiview. On button press create as many tabs as specified in the textbox in the multiview. Have a dropdown menu for navigating the views and content in the views to differentiate. Lastly, use an online CSS libary to style the page and provide a link.</p>
            <p>I used Pure CSS to style this page. Link: <a href="https://purecss.io/" target="_blank">https://purecss.io/</a></p>
            <asp:LinkButton ID="LbtnAssignment02" runat="server" OnClick="LbtnAssignment_Click">See Assignment Page</asp:LinkButton>
        </div>
        <div id="assignment03">
            <h2>Assignment03</h2>
            <h3>Dynamic Item Control</h3>
            <p>Create a page with a dropdown list to pick a car model and then allow users to pick extra options based on selected model.</p>
            <p>Once user is done adding optional details display a new page that contains car information.</p>
            <asp:LinkButton ID="LbtnAssignment03" runat="server" OnClick="LbtnAssignment_Click">See Assignment Page</asp:LinkButton>
        </div>
        <div id="assignment04">
            <h2>Assignment04</h2>
            <h3>Session Variables</h3>
            <p>Create pages that take user information and stores them with the session object.</p>
            <p>By the end of the form have a C# object that encapsulates all the information given and store that in the session object.</p>
            <asp:LinkButton ID="LbtnAssignment04" runat="server" OnClick="LbtnAssignment_Click">See Assignment Page</asp:LinkButton>
        </div>
        <div id="midterm">
            <h2>Midterm</h2>
            <h3>Windows vs Linux</h3>
            <p>Windows is very popular but it has it's drawbacks. For people that find those drawbacks too much there is Linux.</p>
            <p>By ansrewing just a few questions we can help you decide wether Linux or Windows is better for you.</p>
            <p>If you want to read up on it and make your own decision you can look at <a href="https://www.computerhope.com/issues/ch000575.htm" target="_blank">this article by ComputerHope</a>.</p>
            <asp:LinkButton ID="lbtnMidterm" runat="server" OnClick="lbtnMidterm_Click">See Midterm Page</asp:LinkButton>
        </div>
        <div id="assignment06">
            <h2>Assignment06</h2>
            <h3>Database Variables & AJAX</h3>
            <p>Connect to the database and use the data in some creative way and use AJAX to keep it up to date.</p>
            <p>I will be allowing the user to select a store drom a dropdown list and see it's status.</p>
            <asp:LinkButton ID="LbtnAssignment06" runat="server" OnClick="LbtnAssignment_Click">See Assignment Page</asp:LinkButton>
        </div>
        <div id="assignment07">
            <h2>Assignment07</h2>
            <h3>Adding to Database</h3>
            <p>Create a page where a user can create a store and set it's details and have it be added to the database.</p>
            <p>All fields, except Address 2, are required. Store Name must be unique.</p>
            <br />
            <asp:LinkButton ID="LbtnAssignment07" runat="server" OnClick="LbtnAssignment_Click">See Assignment Page</asp:LinkButton>
        </div>
        <div id="assignment08">
            <h2>Assignment08</h2>
            <h3>Populate a TreeView With Database</h3>
            <p>Create a page that access the database to populate a treeview.</p>
            <p>The TreeView will contain nodes of manufacturers and subnodes of their products.</p>
            <br />
            <asp:LinkButton ID="LbtnAssignment08" runat="server" OnClick="LbtnAssignment_Click">See Assignment Page</asp:LinkButton>
        </div>
        <div id="assignment09">
            <h2>Assignment09</h2>
            <h3>Validate User Input</h3>
            <p>Using regex, validate user input on both client and server side.</p>
            <br />
            <asp:LinkButton ID="LbtnAssignment09" runat="server" OnClick="LbtnAssignment_Click">See Assignment Page</asp:LinkButton>
        </div>
        <div id="assignment10">
            <h2>Assignment10</h2>
            <h3>Query an API</h3>
            <p>Queries the FDC API to display food details. <a href="https://fdc.nal.usda.gov/api-guide.html" target="_blank">API link</a> </p>
            <p>Type in a food item, manufacturer, or retailer to get results.</p>
            <br />
            <asp:LinkButton ID="lbtnAssignment10" runat="server" OnClick="LbtnAssignment_Click">See Assignment Page</asp:LinkButton>
        </div>
        <div id="final">
            <h2>Final Exam</h2>
            <h3>Encrypt and Decrypt User Input</h3>
            <p>Using a scrambled ASCII alphabet we ecrypt and decrypt messages.</p>
            <p>A message file and mapping file is needed for decryption.</p>
            <p>To decrypt a message simply type in a 6+2 that has a message and hit decrypt.</p>
            <br />
            <asp:LinkButton ID="lbtnFinal" runat="server" OnClick="lbtnFinal_Click">See Assignment Page</asp:LinkButton>
        </div>
    </main>
</asp:Content>

