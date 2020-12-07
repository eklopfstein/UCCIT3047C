/*******************************************************************************
 * Elijah Klopfstein                                                           *
 * klopfsea@mail.uc.edu                                                        *
 * Assigment 07                                                                *
 * Due: March 11th 2020                                                        *
 * IT3047C Spring 2020                                                         *
 * C# code behind the assignment07 page                                        *
 * On load it establishes the needed connections,                              *
 * loads the possible store components and managers                            * 
 * And adds store to database once finished                                    *
 * *****************************************************************************/
using StoreComponentsTableAdapters;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Assignment07 : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Visible = false;
        if (!IsPostBack) // Only loads store components on first load and loads in managers
        {
            tStoreComponentTableAdapter components = new tStoreComponentTableAdapter();
            try // In case connection fails
            {
                StoreComponents.tStoreComponentDataTable myTable = components.GetData();

                for (int i = 0; i < myTable.Count; i++) // For each store component
                {
                    ListItem component = new ListItem
                    {
                        Text = myTable[i][1].ToString(), // Text is the component name
                        Value = myTable[i][0].ToString() // Value is component ID
                    };
                    lbUnselected.Items.Add(component); // Add it to the list of unselected components
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }

            SqlConnection myConnection;

            string connectionString = "user id=GroceryStoreSimulatorStoreAddLogin;" +
                                      "password=fishpaste;server=IL-SERVER-001.uccc.uc.edu\\MSSQLSERVER2012;" +
                                      "Trusted_Connection=no;" +
                                      "database=GroceryStoreSimulator; " +
                                      "connection timeout=30";

            myConnection = new System.Data.SqlClient.SqlConnection(connectionString);
            string getManagers = "SELECT EmplID, FirstName, LastName, EmplTitleID FROM tEmpl WHERE EmplTitleID = 3 OR EmplTitleID = 7 ORDER BY FirstName";
            // Selectes all employees that can manage a non-vritual store
            SqlCommand getManagersCommand;
            getManagersCommand = myConnection.CreateCommand();
            getManagersCommand.CommandText = getManagers;
            try // In case connection fails
            {
                myConnection.Open();
                SqlDataReader managersLister = getManagersCommand.ExecuteReader();
                while (managersLister.Read()) // Gets each manager
                {
                    ListItem manager = new ListItem(managersLister.GetString(1) + " " + managersLister.GetString(2), managersLister.GetInt32(0).ToString());
                    ddlManagers.Items.Add(manager); // Adds to drop down list
                }
                myConnection.Close();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }

            myConnection = new System.Data.SqlClient.SqlConnection(connectionString);
            string getStates = "SELECT stateAbbreviation, stateName FROM tState WHERE stateAbbreviation != 'ET'";
            // Selectes all states except East Texas. Reason: not a state
            SqlCommand getStatesCommand;
            getStatesCommand = myConnection.CreateCommand();
            getStatesCommand.CommandText = getStates;
            try // In case connection fails
            {
                myConnection.Open();
                SqlDataReader statesLister = getStatesCommand.ExecuteReader();
                while (statesLister.Read()) // Gets each state
                {
                    ListItem state = new ListItem(statesLister.GetString(1), statesLister.GetString(0));
                    ddlState.Items.Add(state); // Adds to drop down list
                }
                myConnection.Close();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }

            string getCountry = "SELECT * FROM tCountry";
            // Selectes all countries
            SqlCommand getCountriesCommand;
            getCountriesCommand = myConnection.CreateCommand();
            getCountriesCommand.CommandText = getCountry;
            try // In case connection fails
            {
                myConnection.Open();
                SqlDataReader countriesLister = getCountriesCommand.ExecuteReader();
                while (countriesLister.Read()) // Gets each country
                {
                    ListItem country = new ListItem(countriesLister.GetString(1), countriesLister.GetInt32(0).ToString());
                    ddlCountry.Items.Add(country); // Adds to drop down list
                }
                myConnection.Close();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }
            string getRegion = "SELECT RegionID, Region FROM tRegion";
            // Selectes all regions
            SqlCommand getRegionsCommand;
            getRegionsCommand = myConnection.CreateCommand();
            getRegionsCommand.CommandText = getRegion;
            try // In case connection fails
            {
                myConnection.Open();
                SqlDataReader regionsLister = getRegionsCommand.ExecuteReader();
                while (regionsLister.Read()) // Gets each region
                {
                    ListItem region = new ListItem(regionsLister.GetString(1), regionsLister.GetInt32(0).ToString());
                    ddlRegion.Items.Add(region); // Adds to drop down list
                }
                myConnection.Close();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
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
                if (lbUnselected.SelectedItem != null && lbUnselected.GetSelectedIndices().Length == 1)
                {
                    lbSelected.Items.Add(lbUnselected.SelectedItem);
                    lbUnselected.Items.Remove(lbUnselected.SelectedItem);
                }
                else
                {
                    int[] selectedIndexes = lbUnselected.GetSelectedIndices();
                    List<ListItem> itemsToRemove = new List<ListItem>();

                    foreach (int index in selectedIndexes)
                    {
                        lbSelected.Items.Add(lbUnselected.Items[index]);
                        itemsToRemove.Add(lbUnselected.Items[index]);
                    }

                    foreach (ListItem added in itemsToRemove)
                    {
                        lbUnselected.Items.Remove(added);
                    }
                }
                return;
            case "btnUnselectSelected":
                if (lbSelected.SelectedItem != null && lbSelected.GetSelectedIndices().Length == 1)
                {
                    lbUnselected.Items.Add(lbSelected.SelectedItem);
                    lbSelected.Items.Remove(lbSelected.SelectedItem);
                }
                else
                {
                    int[] selectedIndexes = lbSelected.GetSelectedIndices();
                    List<ListItem> itemsToRemove = new List<ListItem>();

                    foreach (int index in selectedIndexes)
                    {
                        lbUnselected.Items.Add(lbSelected.Items[index]);
                        itemsToRemove.Add(lbSelected.Items[index]);
                    }

                    foreach (ListItem added in itemsToRemove)
                    {
                        lbSelected.Items.Remove(added);
                    }
                }
                return;
        }

    }

    /// <summary>
    /// Once the done button is pressed we hide the items related to setting the store details
    /// And inform user the store has been added. Show button to make another.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDone_Click(object sender, EventArgs e)
    {
        lblError.Visible = false;
        // Make sure required fields are filled out
        if (txbName.Text.Trim() != "" && txbAddress.Text.Trim() != "" && txbCity.Text.Trim() != "" && txbZip.Text.Trim() != "")
        {

            SqlConnection myConnection;

            string connectionString = "user id=GroceryStoreSimulatorStoreAddLogin;" +
                                      "password=fishpaste;server=IL-SERVER-001.uccc.uc.edu\\MSSQLSERVER2012;" +
                                      "Trusted_Connection=no;" +
                                      "database=GroceryStoreSimulator; " +
                                      "connection timeout=30";

            myConnection = new System.Data.SqlClient.SqlConnection(connectionString);

            string getStoreName = "SELECT COUNT(store) FROM tStore WHERE store = @name";
            // Count of stores with same name
            SqlCommand getStoreNameCommand;
            getStoreNameCommand = myConnection.CreateCommand();
            getStoreNameCommand.Parameters.AddWithValue("@name", txbName.Text.Trim());
            getStoreNameCommand.CommandText = getStoreName;
            try // In case connection fails
            {
                myConnection.Open();
                SqlDataReader storeNameLister = getStoreNameCommand.ExecuteReader();
                while (storeNameLister.Read())
                {
                    if (storeNameLister.GetInt32(0) != 0) // If a store already has this name
                    {
                        // Inform user that the name is taken
                        lblError.Text = "Store was not made because Store Name provided is already taken.";
                        lblError.Visible = true;
                        return;
                    }
                }
                myConnection.Close();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }


            string getStoreNumber = "SELECT StoreNumber FROM tStore ORDER BY StoreNumber DESC";
            // Get all store numbers
            SqlCommand getStoreNumberCommand;
            getStoreNumberCommand = myConnection.CreateCommand();
            getStoreNumberCommand.CommandText = getStoreNumber;
            List<string> storeNumbers = new List<string>(); // List for holding store numbers to minimize time connected
            try // In case connection fails
            {
                myConnection.Open();
                SqlDataReader storeNumberLister = getStoreNumberCommand.ExecuteReader();
                while (storeNumberLister.Read()) // Read all store numbers
                {
                    storeNumbers.Add(storeNumberLister.GetString(0)); // Add to list of store numbers
                }
                myConnection.Close();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }

            Random rand = new Random(); // For making store number
            string storeNumber = "123456789"; // Default number
            restart: // goto point incase number is taken
            foreach (string takenNumber in storeNumbers) // Loops through taken store numbers
            {
                if (storeNumber == takenNumber.Trim()) // If number is taken
                {
                    storeNumber = rand.Next(0, 1000000000).ToString("D10"); // Make a new one, 10 digits right justified
                    goto restart; // Go back and ensrue new number is not taken
                }
            }
            string createStore = "INSERT INTO tStore VALUES(@name, @address, @address2, @city, @state, @zip, @managerID, @storeNumber, @isOnline, @country, @region)";
            // Command to add store to database
            SqlCommand createStoreCommand;
            createStoreCommand = myConnection.CreateCommand();
            createStoreCommand.Parameters.AddWithValue("@name", txbName.Text.Trim());
            createStoreCommand.Parameters.AddWithValue("@address", txbAddress.Text.Trim());
            if (txbAddress2.Text.Trim() == "")
            {
                // If store does not have an address2 value insert a NULL value
                createStoreCommand.Parameters.AddWithValue("@address2", DBNull.Value);
            }
            else
            {
                createStoreCommand.Parameters.AddWithValue("@address2", txbAddress2.Text.Trim());
            }
            createStoreCommand.Parameters.AddWithValue("@city", txbCity.Text.Trim());
            createStoreCommand.Parameters.AddWithValue("@state", ddlState.SelectedValue.Trim());
            createStoreCommand.Parameters.AddWithValue("@zip", txbZip.Text.Trim());
            createStoreCommand.Parameters.AddWithValue("@managerID", ddlManagers.SelectedValue.Trim());
            createStoreCommand.Parameters.AddWithValue("@storeNumber", storeNumber);
            if (rbtOnline.Checked == true)
            {
                // If store is online insert 1
                createStoreCommand.Parameters.AddWithValue("@isOnline", "1");
            }
            else
            {
                // If offline insert 0
                createStoreCommand.Parameters.AddWithValue("@isOnline", "0");
            }
            createStoreCommand.Parameters.AddWithValue("@country", ddlCountry.SelectedValue.Trim());
            createStoreCommand.Parameters.AddWithValue("@region", ddlRegion.SelectedValue.Trim());
            createStoreCommand.CommandText = createStore;
            try // In case connection fails
            {
                myConnection.Open();
                createStoreCommand.ExecuteReader(); // Try to add store
                myConnection.Close();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }

            string getID = "SELECT StoreID FROM tStore WHERE store = @name";
            // Get storeID of store just added
            SqlCommand getIDCommand;
            getIDCommand = myConnection.CreateCommand();
            getIDCommand.Parameters.AddWithValue("@name", txbName.Text.Trim());
            getIDCommand.CommandText = getID;
            try // In case connection fails
            {
                myConnection.Open();
                SqlDataReader IDReader = getIDCommand.ExecuteReader();
                string StoreID = "";
                while (IDReader.Read())
                {
                    StoreID = IDReader.GetInt32(0).ToString(); // StoreID of store just added
                }
                myConnection.Close();
                foreach (ListItem item in lbSelected.Items) // For each selected store component
                {
                    string addCompontent = "INSERT INTO tStore_StoreComponent VALUES(@storeID, @CompontentID)";
                    // command to add store component
                    SqlCommand addCompontentCommand;
                    addCompontentCommand = myConnection.CreateCommand();
                    addCompontentCommand.Parameters.AddWithValue("@storeID", StoreID.Trim());
                    addCompontentCommand.Parameters.AddWithValue("@CompontentID", item.Value.Trim());
                    addCompontentCommand.CommandText = addCompontent;
                    myConnection.Open();
                    addCompontentCommand.ExecuteReader(); // Adds component
                    myConnection.Close();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }

            // If we get here, everything was done successfully
            // Hides area to set store details and informs user the store was made
            // Allow them to make another store
            storeInfo.Visible = false;
            lblDetails.Visible = true;
            btnNew.Visible = true;
            btnDone.Visible = false;
        }
    }

    /// <summary>
    /// Empties the store details to be added
    /// Allow user to insert another new store 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNew_Click(object sender, EventArgs e)
    {
        lblError.Visible = false;
        txbAddress.Text = "";
        txbAddress2.Text = "";
        txbCity.Text = "";
        txbName.Text = "";
        txbZip.Text = "";
        ddlState.SelectedIndex = 0;
        ddlCountry.SelectedIndex = 0;
        ddlRegion.SelectedIndex = 0;
        ddlManagers.SelectedIndex = 0;
        rbtNotOnline.Checked = true;
        foreach (ListItem option in lbSelected.Items) // Moves selected components back to unselected
        {
            lbUnselected.Items.Add(option);
        }
        lbSelected.Items.Clear();

        lblDetails.Visible = false;
        btnNew.Visible = false;
        btnDone.Visible = true;
        storeInfo.Visible = true;
    }

    /// <summary>
    /// If the isOnline radioButton are clicked
    /// Need to change list of managers
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void isOnline_CheckedChanged(object sender, EventArgs e)
    {
        ddlManagers.Items.Clear(); // Clear old list of managers
        RadioButton pressed = (RadioButton)sender;
        SqlConnection myConnection;

        string connectionString = "user id=GroceryStoreSimulatorStoreAddLogin;" +
                                  "password=fishpaste;server=IL-SERVER-001.uccc.uc.edu\\MSSQLSERVER2012;" +
                                  "Trusted_Connection=no;" +
                                  "database=GroceryStoreSimulator; " +
                                  "connection timeout=30";

        myConnection = new System.Data.SqlClient.SqlConnection(connectionString);

        if (pressed.Text == "Yes") // If store is online
        {
            string getManagers = "SELECT EmplID, FirstName, LastName, EmplTitleID FROM tEmpl WHERE EmplTitleID = 9 ORDER BY FirstName";
            // Selecte online store managers
            SqlCommand getManagersCommand;
            getManagersCommand = myConnection.CreateCommand();
            getManagersCommand.CommandText = getManagers;
            try // In case connection fails
            {
                myConnection.Open();
                SqlDataReader managersLister = getManagersCommand.ExecuteReader();
                while (managersLister.Read()) // Add online store managers to drop down list
                {
                    ListItem manager = new ListItem(managersLister.GetString(1) + " " + managersLister.GetString(2), managersLister.GetInt32(0).ToString());
                    ddlManagers.Items.Add(manager);
                }
                myConnection.Close();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }

        }
        else // If store is not online
        {
            string getManagers = "SELECT EmplID, FirstName, LastName, EmplTitleID FROM tEmpl WHERE EmplTitleID = 3 OR EmplTitleID = 7 ORDER BY FirstName";
            // Select normal store managers
            SqlCommand getManagersCommand;
            getManagersCommand = myConnection.CreateCommand();
            getManagersCommand.CommandText = getManagers;
            try // In case connection fails
            {
                myConnection.Open();
                SqlDataReader managersLister = getManagersCommand.ExecuteReader();
                while (managersLister.Read()) // Add normal store managers to drop down list
                {
                    ListItem manager = new ListItem(managersLister.GetString(1) + " " + managersLister.GetString(2), managersLister.GetInt32(0).ToString());
                    ddlManagers.Items.Add(manager);
                }
                myConnection.Close();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }

        }
    }
}