/*******************************************************************************
 * Elijah Klopfstein                                                           *
 * klopfsea@mail.uc.edu                                                        *
 * Assigment 04                                                                *
 * Due: Febuary 19th 2020                                                      *
 * IT3047C Spring 2020                                                         *
 * C# code behind the assignment04-03 page                                     *
 * Displays all given information from the stored                              *
 * BillingInfo object in the Session object                                    *
 * *****************************************************************************/
using System;

public partial class Assignment04_03 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Display info stored in the Billing Info object
        BillingInfo billingInfo = Session["billingInfo"] as BillingInfo;
        tbName.Text = billingInfo.name;
        tbAddress.Text = billingInfo.address;
        tbPhone.Text = billingInfo.phone;
        tbCity.Text = billingInfo.city;
        tbState.Text = billingInfo.state;
        tbZip.Text = billingInfo.zip;
        tbCard.Text = billingInfo.cardNumber;
        tbExpire.Text = billingInfo.expirationDate;
        tbSecurity.Text = billingInfo.securityCode;
    }
}