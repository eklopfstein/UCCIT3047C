/*******************************************************************************
 * Elijah Klopfstein                                                           *
 * klopfsea@mail.uc.edu                                                        *
 * Assigment 08                                                                *
 * Due: April 5th 2020                                                         *
 * IT3047C Spring 2020                                                         *
 * Class for reading the data from the database                                *
 * And loading it into the treeview                                            *
 * *****************************************************************************/
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public class Manufacturers
{
    private Dictionary<KeyValuePair<string, string>, List<string>> mManufacturers;

    /// <summary>
    /// Reads the data from the database and stores it in a Dictionary
    /// </summary>
    /// <param name="manufacturerList">SQLDataReader that contains the data from the table. Should be from DatabaseConnection.Query()</param>
    public void datareader(SqlDataReader manufacturerList)
    {
        // Dictoionary to temporarily hold results
        Dictionary<KeyValuePair<string, string>, List<string>> manufacturers = new Dictionary<KeyValuePair<string, string>, List<string>>();
        // int to track the ID of the last manufacturer
        int ID = 0;
        // List to hold products of each manufacturer
        List<string> products = new List<string>();
        // Boolean to know to ignore the ID on the first run through of the loop
        bool first = true;
        while (manufacturerList.Read())
        {
            // If the ID is not the same as the last and it is not the first run through
            if (ID != manufacturerList.GetInt32(0) && !first)
            {
                // Add the last one with it's products to the Treeview
                manufacturers.Add(new KeyValuePair<string, string>(manufacturerList.GetInt32(0).ToString().Trim(), manufacturerList.GetString(1).Trim()), new List<string>(products));
                // Clear the list so we can start storing this one's products
                products.Clear();
                // Set the ID to the new store's ID
                ID = manufacturerList.GetInt32(0);
            }
            // Set it to false after the first run through
            first = false;
            // If the product description is not blank, use it
            if (manufacturerList.GetString(2).Trim() != "")
            {
                products.Add(manufacturerList.GetString(2).Trim());
            }
            // If the description is blank but the UPC isn't, use the UPC
            else if (manufacturerList.GetString(3).Trim() != "")
            {
                products.Add(manufacturerList.GetString(3).Trim());
            }
            // If they are both blank, use a default phrase
            else
            {
                products.Add("Product with no details or UPC");
            }
        }
        // Once we have gone through all the manufacturers, set the temp dictionary to the real one
        this.manufacturers = manufacturers;
    }

    /// <summary>
    /// Loads the given TreeView with the data from datareader()
    /// Make sure you run datareader() before this one
    /// </summary>
    /// <param name="treeView">Treeview object for the data to be stored in</param>
    public void loadTreeView(TreeView treeView)
    {
        // Clears the treeview in case of any left over data
        treeView.Nodes.Clear();
        // Loops through all the manufacturers
        foreach (KeyValuePair<KeyValuePair<string, string>, List<string>> manufacturerDetails in manufacturers)
        {
            // Creates a node for each one
            TreeNode manufacturer = new TreeNode(manufacturerDetails.Key.Value, manufacturerDetails.Key.Key);
            // Loops through each manufacturers' products
            foreach (string product in manufacturerDetails.Value)
            {
                // Creates a node for each one and adds it to the manufacturer's node
                TreeNode productNode = new TreeNode(product);
                manufacturer.ChildNodes.Add(productNode);
            }
            // Adds the manufacturer's node to the treeview
            treeView.Nodes.Add(manufacturer);
        }
    }

    /// <summary>
    /// Getter and setter for the Dictionary of manufacturers
    /// </summary>
    public Dictionary<KeyValuePair<string, string>, List<string>> manufacturers
    {
        // Creates copies of the dictionary to avoiding passing by reference
        get => new Dictionary<KeyValuePair<string, string>, List<string>>(mManufacturers);
        set => mManufacturers = new Dictionary<KeyValuePair<string, string>, List<string>>(value);
    }
}