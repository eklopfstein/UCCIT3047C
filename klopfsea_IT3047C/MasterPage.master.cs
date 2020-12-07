/*******************************************************************************
 * Elijah Klopfstein                                                           *
 * klopfsea@mail.uc.edu                                                        *
 * Assigment 01                                                                *
 * Due: January 22nd 2020                                                      *
 * IT3047C Spring 2020                                                         *
 * C# code behind the master page for all pages                                *
 * *****************************************************************************/
using System;

public partial class MasterPage : System.Web.UI.MasterPage
{
    /// <summary>
    /// When ane item is selected on the Assignments dropdown list
    /// It will change to the assignment page selected
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlAssignment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlAssignment.SelectedIndex != 0) // If selected index is not the placeholder
        {
            Response.Redirect(ddlAssignment.SelectedValue); // Redirect to the selected assignment
        }
    }
}
