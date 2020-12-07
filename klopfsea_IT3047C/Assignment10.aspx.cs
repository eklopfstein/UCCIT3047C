/*******************************************************************************
 * Elijah Klopfstein                                                           *
 * klopfsea@mail.uc.edu                                                        *
 * Assignment 10                                                               *
 * Due: April 19th 2020                                                        *
 * IT3047C Spring 2020                                                         *
 * C# file behind the Assignment10 page                                        *
 * Queries the api and displays the results on the page                        *
 * https://fdc.nal.usda.gov/api-guide.html                                     *
 * *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class Assignment10 : System.Web.UI.Page
{
    /// <summary>
    /// Sends the query to the api and processes the data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        // Clears any past results
        tblResults.Controls.Clear();
        // Hides any past error messages
        lblError.Visible = false;
        Dictionary<string, List<string>> results = new Dictionary<string, List<string>>();
        try // Try to send query
        {
            results = FdcApi.request(txtQuery.Text);
        }
        catch (Exception ex)
        {
            // If it fails show the error message
            lblError.Text = ex.Message;
            lblError.Visible = true;
            return;
        }

        // Placeholder row for top of table
        TableRow topRow = new TableRow();
        TableCell topID = new TableCell();
        TableCell topDescription = new TableCell();
        TableCell topOwner = new TableCell();
        TableCell topDate = new TableCell();
        TableCell topIngredients = new TableCell();

        Label lblTopID = new Label
        {
            Text = "FDC ID"
        };
        Label lblTopOwner = new Label
        {
            Text = "Owner"
        };
        Label lblTopDate = new Label
        {
            Text = "Date"
        };
        Label lblTopIngredients = new Label
        {
            Text = "Ingredients"
        };
        Label lblTopDescription = new Label
        {
            Text = "Description"
        };

        // Adds the lables to the cell
        topID.Controls.Add(lblTopID);
        topDescription.Controls.Add(lblTopDescription);
        topOwner.Controls.Add(lblTopOwner);
        topDate.Controls.Add(lblTopDate);
        topIngredients.Controls.Add(lblTopIngredients);

        // Adds the cells to the row
        topRow.Controls.Add(topID);
        topRow.Controls.Add(topDescription);
        topRow.Controls.Add(topOwner);
        topRow.Controls.Add(topDate);
        topRow.Controls.Add(topIngredients);

        // Adds the row to the table
        tblResults.Controls.Add(topRow);

        // Loops through each result from the query
        foreach (KeyValuePair<string, List<string>> result in results)
        {
            // Row for each result
            TableRow row = new TableRow();

            // Cells for each detail
            TableCell ID = new TableCell();
            TableCell description = new TableCell();
            TableCell owner = new TableCell();
            TableCell date = new TableCell();
            TableCell ingredients = new TableCell();

            // Labels for each cell
            Label lblID = new Label
            {
                Text = result.Key
            };
            Label lblDescription = new Label
            {
                Text = result.Value[0]
            };
            Label lblOwner = new Label
            {
                Text = result.Value[1]
            };
            Label lblDate = new Label
            {
                Text = result.Value[2]
            };
            Label lblIngredients = new Label
            {
                Text = result.Value[3]
            };

            // Adds the labels to the cells
            ID.Controls.Add(lblID);
            description.Controls.Add(lblDescription);
            owner.Controls.Add(lblOwner);
            date.Controls.Add(lblDate);
            ingredients.Controls.Add(lblIngredients);

            // Adds the cells to the row
            row.Controls.Add(ID);
            row.Controls.Add(description);
            row.Controls.Add(owner);
            row.Controls.Add(date);
            row.Controls.Add(ingredients);

            // Adds the row to the table
            tblResults.Controls.Add(row);
        }
    }
}