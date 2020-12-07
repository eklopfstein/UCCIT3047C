/*******************************************************************************
 * Elijah Klopfstein                                                           *
 * klopfsea@mail.uc.edu                                                        *
 * Assigment 01                                                                *
 * Due: January 22nd 2020                                                      *
 * IT3047C Spring 2020                                                         *
 * C# code behind the home page                                                *
 * *****************************************************************************/
using System;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    /// <summary>
    /// Trigger when any assignment link is clicked to go to the assignment page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LbtnAssignment_Click(object sender, EventArgs e)
    {
        LinkButton clicked = (LinkButton)sender;
        string assignmentNumber = clicked.ID.Substring(clicked.ID.Length - 2);
        Response.Redirect("Assignment" + assignmentNumber + ".aspx"); // Redirects to the assignment page
    }

    /// <summary>
    /// Trigger when the midterm link is clicked to go to the midterm page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtnMidterm_Click(object sender, EventArgs e)
    {
        Response.Redirect("Midterm.aspx");
    }

    /// <summary>
    /// Trigger when the final link is clicked to go to the final page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtnFinal_Click(object sender, EventArgs e)
    {
        Response.Redirect("Final.aspx");
    }
}