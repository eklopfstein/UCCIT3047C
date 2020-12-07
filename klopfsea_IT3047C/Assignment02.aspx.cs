/*******************************************************************************
 * Elijah Klopfstein                                                           *
 * klopfsea@mail.uc.edu                                                        *
 * Assigment 02                                                                *
 * Due: January 29th 2020                                                      *
 * IT3047C Spring 2020                                                         *
 * C# code behind the Assignment02 page                                        *
 * Manages a multiview with the specified number of views                      *
 * You are limited to 1000 views for performance reasons                       *
 * *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class Assignment2 : System.Web.UI.Page
{
    private static int tabs = 0; // int for storing amount of tabs needed
    private MultiView multiView = new MultiView(); // Multiview for holding the views and managing selected index
    // Something needs to bring the views from the PreInit to the load so I decided to build a new multiview each time
    // And use it to bring the veiws between parts of the page's lifecycle and change the selected view

    /// <summary>
    /// Makes the needed amount of tabs and stores them in the list
    /// </summary>
    protected void Page_PreInit()
    {
        List<View> views = makeViews(tabs);
        foreach (View page in views)
        {
            multiView.Views.Add(page);
        }

    }

    /// <summary>
    /// On load it removes the old multiview and loads the new one
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        phMultiView.Controls.Clear();
        phMultiView.Controls.Add(multiView);
    }

    /// <summary>
    /// On button click it takes the amount of tabs specified and sets the tabs int to that value for later reference
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        if (tbAmount != null) // If the text box exists
        {
            try
            {
                if (int.Parse(tbAmount.Text) != tabs && int.Parse(tbAmount.Text) <= 1000) // If the amount in the texbox is different than the last postback and less than 1000
                {
                    tabs = int.Parse(tbAmount.Text);
                    makeTabs(tabs);
                }
            }
            catch (FormatException) // Will be caught when input is not a number
            {
                Console.WriteLine("Given input was not a number.");
            }
        }
    }

    /// <summary>
    /// On selected index change it sets the active view to the selected one
    /// If the placeholder is selected it displays no view
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlView_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlView.SelectedValue == "Select A View") // If selected value is the placeholder
        {
            multiView.ActiveViewIndex = -1; // Have no index selected
        }
        else
        {
            int index = int.Parse(ddlView.SelectedValue.Substring(4)) - 1;
            // Get the index from the name by taking the view number and subtracing 1
            // ex. "View 34" would be reduced to 34 and taking away 1 to get 33 since the list is 0 based
            multiView.ActiveViewIndex = index;
        }


    }

    /// <summary>
    /// Creates views with pregenerated contents to the specified amount
    /// </summary>
    /// <param name="tabAmount">Amount of views wanted</param>
    /// <returns>List containg the views</returns>
    private List<View> makeViews(int tabAmount)
    {
        List<View> views = new List<View>();
        for (int i = 0; i < tabAmount; i++)
        {
            View page = new View
            {
                ID = "View" + (i + 1)
            };
            Label tabContents = new Label
            {
                Text = "You are indubitably looking at the absurdly insignificant contents of view " + (i + 1) + ". These meager contents are merely here to substantiate the fact that you have clicked on view " + (i + 1) + " and are now gazing upon the absurdly insignificant contents of view " + (i + 1) + "."
            };
            page.Controls.Add(tabContents);
            views.Add(page);

        }
        return views;
    }

    /// <summary>
    /// Creates the dropdownlist items to refer to each view
    /// </summary>
    /// <param name="tabAmount">Amount of dropdownlist items needed</param>
    private void makeTabs(int tabAmount)
    {
        ddlView.Items.Clear();
        ddlView.Items.Add(new ListItem("Select A View", "Select A View")); // Starts with a placeholder
        for (int i = 0; i < tabAmount; i++)
        {
            ddlView.Items.Add(new ListItem("View " + (i + 1), "View " + (i + 1)));
        }
        multiView.ActiveViewIndex = -1;
    }
}
