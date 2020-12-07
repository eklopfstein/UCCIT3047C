/*******************************************************************************
 * Elijah Klopfstein                                                           *
 * klopfsea@mail.uc.edu                                                        *
 * Assigment 08                                                                *
 * Due: April 5th 2020                                                         *
 * IT3047C Spring 2020                                                         *
 * C# code behind the assignment08 page                                        *
 * On load it establishes the needed connections,                              *
 * And loads all manufacturers and their products into a treeview              *
 * *****************************************************************************/
using System;


public partial class Assignment08 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Decided to load the treeview everytime because it does not take too long
        loadTreeView();
    }

    /// <summary>
    /// Loads the treeview with the data from the database
    /// </summary>
    private void loadTreeView()
    {
        tvManufacturers.Nodes.Clear();
        // String used to connect to the database
        string connectionString = "user id=GroceryStoreSimulatorStoreAddLogin;" +
                                      "password=fishpaste;server=IL-SERVER-001.uccc.uc.edu\\MSSQLSERVER2012;" +
                                      "Trusted_Connection=no;" +
                                      "database=GroceryStoreSimulator; " +
                                      "connection timeout=30";
        string query = "USE GroceryStoreSimulator SELECT tManufacturer.ManufacturerID, tManufacturer.Manufacturer, [Description], [UPC-A] FROM tProduct INNER JOIN tManufacturer ON tProduct.ManufacturerID = tManufacturer.ManufacturerID ORDER BY ManufacturerID";
        Manufacturers manufacturers = new Manufacturers();
        DatabaseConnection groceryStore = new DatabaseConnection(connectionString, lblError);
        groceryStore.openAndCloseConnection(true); // Opens the connection to the database
        manufacturers.datareader(groceryStore.Query(query));
        groceryStore.openAndCloseConnection(false); // Closes the connection to the database
        manufacturers.loadTreeView(tvManufacturers);
    }
}