/*******************************************************************************
 * Elijah Klopfstein                                                           *
 * klopfsea@mail.uc.edu                                                        *
 * Assigment 08                                                                *
 * Due: April 5th 2020                                                         *
 * IT3047C Spring 2020                                                         *
 * Class for connecting to a database                                          *
 * And running queries against it                                              *
 * *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public class DatabaseConnection
{
    private SqlConnection myConnection;

    /// <summary>
    /// Constructor for DatabaseConnection objects
    /// </summary>
    /// <param name="connectionString">Connection String for database</param>
    /// <param name="lblError">Label to store error messages in</param>
    public DatabaseConnection(string connectionString, Label lblError)
    {
        // Uses the connection string to connect to the database
        myConnection = new SqlConnection(connectionString);
        this.lblError = lblError;
    }

    /// <summary>
    /// Runs a given parameterized query against the database
    /// </summary>
    /// <param name="query">Query text</param>
    /// <param name="Parameters">Dictionary of parameter names and values</param>
    /// <returns>SqlDataReader object containg results of the query</returns>
    public SqlDataReader Query(string query, Dictionary<string, string> Parameters)
    {
        try
        {
            SqlCommand sqlCommand;
            sqlCommand = myConnection.CreateCommand();

            // Loops through the parameters and adds them to the query
            foreach (KeyValuePair<string, string> parameter in Parameters)
            {
                sqlCommand.Parameters.AddWithValue(parameter.Key, parameter.Value.Trim());
            }
            sqlCommand.CommandText = query;
            SqlDataReader results = sqlCommand.ExecuteReader();
            return results;
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            lblError.Visible = true;
            return null;
        }
    }

    /// <summary>
    /// Runs a given unparameterized query against the database
    /// </summary>
    /// <param name="query">Query text</param>
    /// <returns>SqlDataReader object containg results of the query</returns>
    public SqlDataReader Query(string query)
    {
        try
        {
            SqlCommand sqlCommand;
            sqlCommand = myConnection.CreateCommand();
            sqlCommand.CommandText = query;
            SqlDataReader results = sqlCommand.ExecuteReader();
            return results;
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            lblError.Visible = true;
            return null;
        }
    }

    /// <summary>
    /// Opens and closes the connection to the database
    /// </summary>
    /// <param name="open">If true it opens the connection, If false it Closes it.</param>
    public void openAndCloseConnection(bool open)
    {
        try
        {
            if (open)
            {
                myConnection.Open();
            }
            else
            {
                myConnection.Close();
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            lblError.Visible = true;
        }
    }

    /// <summary>
    /// Just storing the label as a reference because it is being used to display errors
    /// </summary>
    public Label lblError { get; set; }
}