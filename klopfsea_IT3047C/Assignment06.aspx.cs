/*******************************************************************************
 * Elijah Klopfstein                                                           *
 * klopfsea@mail.uc.edu                                                        *
 * Assigment 06                                                                *
 * Due: March 4th 2020                                                         *
 * IT3047C Spring 2020                                                         *
 * C# code behind the assignment06 page                                        *
 * On load it establishes the needed connections,                              *
 * loads the stores in the dropdown list and shows the status of the           * 
 * selected store                                                              *
 * *****************************************************************************/
using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;

public partial class Assignment06 : System.Web.UI.Page
{
    private static SqlConnection connStores;
    private static SqlConnection connStatus;
    private static SqlCommand commStores;
    private static SqlCommand commStatus;
    private static SqlDataReader reader;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            OpenStoresConnection();
            OpenStatusConnection();
            LoadDropDownList();
        }
    }

    /// <summary>
    /// Established the connection to the database for geting the stores
    /// </summary>
    private void OpenStoresConnection()
    {
        System.Configuration.ConnectionStringSettings strConn;
        strConn = ReadConnectionString();

        connStores = new SqlConnection(strConn.ConnectionString);

        // This could go wrong in so many ways...
        try
        {
            connStores.Open();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    /// <summary>
    /// Established the connection to the database for geting the store status
    /// </summary>
    private void OpenStatusConnection()
    {
        System.Configuration.ConnectionStringSettings strConn;
        strConn = ReadConnectionString();

        connStatus = new SqlConnection(strConn.ConnectionString);

        // This could go wrong in so many ways...
        try
        {
            connStatus.Open();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    /** Read the connection string from the web.config file. 
      * This is a much more secure way to store sensitive information. Don't hard-code connection information in the source code.
      * Adapted from http://msdn.microsoft.com/en-us/library/ms178411.aspx
      */
    private System.Configuration.ConnectionStringSettings ReadConnectionString()
    {
        string strPath;
        strPath = HttpContext.Current.Request.ApplicationPath + "/web.config";
        System.Configuration.Configuration rootWebConfig =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(strPath);

        System.Configuration.ConnectionStringSettings connString = null;
        if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
        {
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["GroceryStoreSimulatorConnectionString"];
        }
        return connString;
    }

    /// <summary>
    /// Loads all store names into the dropdown list
    /// </summary>
    private void LoadDropDownList()
    {
        string tmp;
        ListItem myListItem;

        // Clear the dropdown list, in case we've already loaded something into it.
        ddlStores.Items.Clear();
        commStores = new SqlCommand("SELECT Store FROM tStore ORDER BY Store", connStores);
        try { reader.Close(); } catch (Exception) { }
        reader = commStores.ExecuteReader();

        while (reader.Read())
        {
            tmp = reader.GetString(0); // Store name
            myListItem = new ListItem(tmp);
            ddlStores.Items.Add(myListItem);
        }
    }

    protected void ddlStores_SelectedIndexChanged(object sender, EventArgs e)
    {
        string Store = ddlStores.SelectedValue.ToString().Trim();
        commStatus = new SqlCommand("SELECT TOP 1 Store, StoreStatus, MAX(StartDate) AS 'Date Started' FROM tStoreHistory JOIN tStore ON tStoreHistory.StoreID = tStore.StoreID JOIN tStoreStatus  ON tStoreStatus.StoreStatusID = tStoreHistory.StoreStatusID WHERE StartDate <= GETDATE() GROUP BY Store, StoreStatus HAVING Store = '" + Store + "' ORDER BY[Date Started] DESC", connStatus);
        string Status;
        string StartDate;
        try { reader.Close(); } catch (Exception) { }
        reader = commStatus.ExecuteReader();

        while (reader.Read())
        {
            Status = reader.GetString(1).Trim(); // Store status string
            StartDate = reader.GetDateTime(2).ToString(); // Status start date
            lblSelectedStatus.Text = "The store at " + Store + " currently has status, " + Status + ", as of " + StartDate + ".";

        }
    }
}