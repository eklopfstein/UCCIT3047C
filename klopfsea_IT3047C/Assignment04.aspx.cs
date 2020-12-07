/*******************************************************************************
 * Elijah Klopfstein                                                           *
 * klopfsea@mail.uc.edu                                                        *
 * Assigment 04                                                                *
 * Due: Febuary 19th 2020                                                      *
 * IT3047C Spring 2020                                                         *
 * C# code behind the assignment04 page                                        *
 * If information is given in all spots then it will save the info             *
 * and move onto the next page                                                 *
 * *****************************************************************************/
using System;

public partial class Assignment04_01 : System.Web.UI.Page
{
    protected void btnNext_Click(object sender, EventArgs e)
    {
        // If the fields have been filled out
        if (tbAddress != null && tbCity != null && tbName != null && tbPhone != null && tbState != null && tbZip != null)
        {
            Session["billingInfo"] = new BillingInfo(tbName.Text, tbAddress.Text, tbPhone.Text, tbCity.Text, tbState.Text, tbZip.Text, "", "", "");
            Response.Redirect("Assignment04-02.aspx");
        }
    }
}