/*******************************************************************************
 * Elijah Klopfstein                                                           *
 * klopfsea@mail.uc.edu                                                        *
 * Assigment 01                                                                *
 * Due: January 22nd 2020                                                      *
 * IT3047C Spring 2020                                                         *
 * C# code behind the Assingment01 page                                        *
 * Displays project Euler problem 686 and answer                               *
 * *****************************************************************************/
using System;
public partial class Assignment01 : System.Web.UI.Page
{
    /// <summary>
    /// On page load, calculate answer and show on screen
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        Problem686 solver = new Problem686(); // Problem686 object to solve the problem
        lblAnsrew.Text = "<b>ANSWER: <i>p</i>(123, 678910) = " + solver.Solve().ToString() + "</b>"; // Solves the problem and puts it on the screen
    }
}