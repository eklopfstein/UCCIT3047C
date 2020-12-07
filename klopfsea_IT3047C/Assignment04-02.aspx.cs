/*******************************************************************************
 * Elijah Klopfstein                                                           *
 * klopfsea@mail.uc.edu                                                        *
 * Assigment 04                                                                *
 * Due: Febuary 19th 2020                                                      *
 * IT3047C Spring 2020                                                         *
 * C# code behind the assignment04-02 page                                     *
 * Stores the information from the last page on load                           *
 * If information is given in all spots then it will save the info             *
 * and move onto the next page                                                 *
 * *****************************************************************************/
using System;

public partial class Assignment04_02 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Fills in info from previous page on load
        BillingInfo billingInfo = Session["billingInfo"] as BillingInfo;
        tbName.Text = billingInfo.name;
        tbAddress.Text = billingInfo.address;
        tbPhone.Text = billingInfo.phone;
        tbCity.Text = billingInfo.city;
        tbState.Text = billingInfo.state;
        tbZip.Text = billingInfo.zip;
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        // If the new fields have been filled out
        if (tbCard != null && tbExpire != null && tbSecurity != null)
        {
            // Create a BillingInfo object and store it in the Session object
            BillingInfo billingInfo = Session["billingInfo"] as BillingInfo;
            billingInfo.cardNumber = tbCard.Text;
            billingInfo.expirationDate = tbExpire.Text;
            billingInfo.securityCode = tbSecurity.Text;
            Session["billingInfo"] = billingInfo;
            Response.Redirect("Assignment04-03.aspx");
        }
    }
}