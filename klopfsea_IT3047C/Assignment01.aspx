<%------------------------------------------------------------------------------
 - Elijah Klopfstein                                                           -
 - klopfsea@mail.uc.edu                                                        -
 - Assigment 01                                                                -
 - Due: January 22nd 2020                                                      -
 - IT3047C Spring 2020                                                         -
 - HTML for the Assignment01 page                                              -
 - Shows the assignment descritpion, Project Euler Problem,                    -
 - Link to problem page, and the calculated answer                             -
-------------------------------------------------------------------------------%>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Assignment01.aspx.cs" Inherits="Assignment01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <main>
        <h2>Assignment01</h2>
        <p>Create main page and create a second page that solves a Project Euler problem.</p>
        <!-- Link is set to open the problem in a new tab -->
        <a href="https://projecteuler.net/problem=686" target="_blank">
            <h3>Project Euler Problem 686</h3>
        </a>

        <p>
            <b>2<sup>7</sup>=128</b> is the first power of two whose leading digits are "12".<br />
            The next power of two whose leading digits are "12" is <b>2<sup>80</sup></b>.
        </p>

        <p>
            Define <b><i>p</i>(L, <i>n</i>)</b> to be the <i>n</i>th-smallest value of <i><b>j</b></i> such that the base 10 representation of <b>2<sup><i>j</i></sup></b> begins with the digits of <b>L</b>.<br />
            So <b><i>p</i>(12, 1) = 7</b> and <b><i>p</i>(12, 2) = 80</b>.
        </p>

        <p>You are also given that <b><i>p</i>(123, 45) = 12710</b>.</p>

        <p>Find <b><i>p</i>(123, 678910)</b>.</p>
        <!-- On load this label is populated with the calculated answer -->
        <asp:Label ID="lblAnsrew" runat="server"></asp:Label>
    </main>
</asp:Content>

