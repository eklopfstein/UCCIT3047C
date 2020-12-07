/*******************************************************************************
 * Elijah Klopfstein                                                           *
 * klopfsea@mail.uc.edu                                                        *
 * Assigment 03                                                                *
 * Due: Febuary 5th 2020                                                       *
 * IT3047C Spring 2020                                                         *
 * C# code behind the assignment03 page                                        *
 * Manages a dropdown list and two listboxes to allow user to create a car     *
 * After creation user is displayed their creation                             *
 * *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class Assignment03 : System.Web.UI.Page
{
    private static List<KeyValuePair<string, List<string>>> modelsAndOptions = new List<KeyValuePair<string, List<string>>>();

    /// <summary>
    /// Reads the file on first load and stores the data in the list
    /// Also fill in the drop down list with the models
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) // Only reads file on first load
        {
            modelsAndOptions = ListReader.ReadCarList();
            // Loops through the list to get the model names
            foreach (KeyValuePair<string, List<string>> pair in modelsAndOptions)
            {
                ListItem model = new ListItem
                {
                    Text = pair.Key
                };
                ddlModels.Items.Add(model);
            }
        }
    }

    /// <summary>
    /// Clears the listboxes and put the options
    /// for the new model in them
    /// Ignores the placeholder
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlModels_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbUnselected.Items.Clear();
        lbSelected.Items.Clear();
        if (ddlModels.SelectedIndex != 0) // If not the placeholder
        {
            foreach (KeyValuePair<string, List<string>> pair in modelsAndOptions)
            {
                if (pair.Key.ToString() == ddlModels.SelectedItem.Text.ToString()) // Finds the selected model
                {
                    foreach (string current in pair.Value) // And fills in the options
                    {
                        ListItem option = new ListItem
                        {
                            Text = current
                        };
                        lbUnselected.Items.Add(option);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Moves the options based on what's selected and which button is pressed
    /// </summary>
    /// <param name="sender">Will be one of the four buttons for moving options</param>
    /// <param name="e">Will be a button press event</param>
    protected void changeOptions(object sender, EventArgs e)
    {
        // We can assume the sender is a button
        Button pressed = (Button)sender;
        switch (pressed.ID) // Switch to find out which button was pressed
        {
            case "btnSelectAll":
                foreach (ListItem option in lbUnselected.Items)
                {
                    lbSelected.Items.Add(option);
                }
                lbUnselected.Items.Clear();
                return;
            case "btnUnselectAll":
                foreach (ListItem option in lbSelected.Items)
                {
                    lbUnselected.Items.Add(option);
                }
                lbSelected.Items.Clear();
                return;
            case "btnSelectSelected":
                if (lbUnselected.SelectedItem != null)
                {
                    lbSelected.Items.Add(lbUnselected.SelectedItem);
                    lbUnselected.Items.Remove(lbUnselected.SelectedItem);
                }
                return;
            case "btnUnselectSelected":
                if (lbSelected.SelectedItem != null)
                {
                    lbUnselected.Items.Add(lbSelected.SelectedItem);
                    lbSelected.Items.Remove(lbSelected.SelectedItem);
                }
                return;
        }

    }

    /// <summary>
    /// Once the done button is pressed we hide the items related to picking the car and display the
    /// car information. Also displays a button the reconfigure car.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDone_Click(object sender, EventArgs e)
    {
        tblOptions.Visible = false;
        ddlModels.Visible = false;
        btnDone.Visible = false;
        string model = "Your car is the " + ddlModels.SelectedItem.Text.ToString();
        if (lbSelected.Items.Count > 2) // Finds out the amount of selected options for grammar
        {
            string options = " with the ";
            for (int i = 0; i < lbSelected.Items.Count - 1; i++)
            {
                options += lbSelected.Items[i] + ", ";
            }
            lblDetails.Text = model + options + "and " + lbSelected.Items[lbSelected.Items.Count - 1] + ".";
            lblDetails.Visible = true;
            btnReConfig.Visible = true;
            return;
        }
        else if (lbSelected.Items.Count == 2)
        {
            string options = " with the " + lbSelected.Items[0] + " and " + lbSelected.Items[1] + ".";
            lblDetails.Text = model + options;
            lblDetails.Visible = true;
            btnReConfig.Visible = true;
            return;
        }
        else if (lbSelected.Items.Count == 1)
        {
            string options = " with the " + lbSelected.Items[0] + ".";
            lblDetails.Text = model + options;
            lblDetails.Visible = true;
            btnReConfig.Visible = true;
            return;
        }
        lblDetails.Text = model + " with no additional add-ons.";
        lblDetails.Visible = true;
        btnReConfig.Visible = true;
    }

    /// <summary>
    /// Empties and hides the car details and brings back the items
    /// to change car configurations 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnReConfig_Click(object sender, EventArgs e)
    {
        lblDetails.Text = "";
        lblDetails.Visible = false;
        btnReConfig.Visible = false;
        tblOptions.Visible = true;
        ddlModels.Visible = true;
        btnDone.Visible = true;
    }
}