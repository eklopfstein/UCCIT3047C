/*******************************************************************************
 * Elijah Klopfstein                                                           *
 * klopfsea@mail.uc.edu                                                        *
 * Assigment 09                                                                *
 * Due: April 12th 2020                                                        *
 * IT3047C Spring 2020                                                         *
 * C# code behind the assignment09 page                                        *
 * On load it reads the majors from the XML file                               *
 * On submit it sees if user gave a new Major and if they did                  *
 * It adds it to the XML file and relaods the drop down list                   *
 * *****************************************************************************/
/* Bill Nicholson
 * nicholdw@ucmail.uc.edu
 * XML and user input validation
 */
using System;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;

public partial class Assignment09 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ReadMajorsFromXMLFile(ddlMajor);
            SortDropDown(ddlMajor);
            InitControls();
        }
    }
    private void InitControls()
    {
        ddlMajor.SelectedIndex = -1;
    }
    /// <summary>
    /// Read majors into drop-down control
    /// </summary>
    private void ReadMajorsFromXMLFile(DropDownList ddl)
    {
        ddl.Items.Clear();

        // See http://support.microsoft.com/kb/307548 for reading from XML file

        // We might want to add the physical file name to Web.config rather than hardcoding it here.
        string fileName = Path.Combine(HttpContext.Current.ApplicationInstance.Server.MapPath("~/App_Data"), "majors.xml");
        XmlTextReader reader = new XmlTextReader(fileName);
        while (reader.Read())
        {
            switch (reader.NodeType)
            {
                case XmlNodeType.Element: // The node is an element.
                    break;
                case XmlNodeType.Text: //add the text in the element to the drop-down control.
                    ddl.Items.Add(reader.Value);
                    break;
                case XmlNodeType.EndElement: //Display the end of the element.
                    break;
            }
        }
        reader.Close();
    }
    /// <summary>
    /// Rewrite the Departments XML file and add the new department to it
    /// </summary>
    /// <param name="department">The new department name</param>
    private void ReWriteDepartmentXMLFile(string department)
    {
        // http://www.c-sharpcorner.com/uploadfile/a72401/create-xml-file-using-Asp-Net/
        // Try/Catch?
        string fileName = Path.Combine(HttpContext.Current.ApplicationInstance.Server.MapPath("~/App_Data"), "majors.xml");
        XmlTextWriter writer = new XmlTextWriter(fileName, null);
        writer.WriteStartDocument(true);
        writer.Formatting = Formatting.Indented;
        writer.Indentation = 2;
        //Root Element
        writer.WriteStartElement("departments");
        // Write all the existing department names from the Drop-Down list
        foreach (System.Web.UI.WebControls.ListItem myItem in ddlMajor.Items)
        {
            //parent node start
            writer.WriteStartElement("department");
            //Department name
            writer.WriteStartElement("name");
            writer.WriteString(myItem.Text);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
        //parent node start
        writer.WriteStartElement("department");
        //Save the new department name
        writer.WriteStartElement("name");
        writer.WriteString(department);
        writer.WriteEndElement();
        writer.WriteEndElement();

        writer.WriteEndDocument();  //End XML Document 

        writer.Close();  //Close writer (Try/Catch?)
    }
    /// <summary>
    /// Click event handler for btnOK
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (txtMajor.Text.Trim().Length > 0)
        { // There is something in the Major text box.

            // Check to see if it's already in the DropDownList...
            if (!ScanDropDown(ddlMajor, txtMajor.Text.Trim()))
            {
                ReWriteDepartmentXMLFile(txtMajor.Text.Trim()); // Add the new item to the department list

                ReadMajorsFromXMLFile(ddlMajor);       // Reread the XML file and reload the Drop Down List

                SortDropDown(ddlMajor);
            }

            // Set the drop down list current index to the newly added major
            ResetDropDownIndex(ddlMajor, txtMajor.Text.Trim());

            // Clear the txtMajor text box 
            txtMajor.Text = "";
        }
    }
    /// <summary>
    /// Scan the items in a DropDownList for a particular value
    /// </summary>
    /// <param name="ddl">The DropDownList to be processed</param> 
    /// <param name="myValue">The string to be searched for</param> 
    /// <returns>true if the string is found in the list</returns> 
    public bool ScanDropDown(DropDownList ddl, string myValue)
    {
        // TODO: finish this method. a foreach loop would be nice.
        foreach (ListItem item in ddl.Items)
        {
            if (item.Text.ToLower() == myValue.ToLower()) // ToLower in case you left caps lock on
            {
                return true;
            }
        }

        return false;
    }
    /// <summary>
    /// Set the index of the currently selected value to a specific string in the DropDownList control
    /// </summary>
    /// <param name="ddl">The DropDownList to be processed</param>  
    /// <param name="myValue">The string to be selected. It should already be in the ddl</param> 
    private void ResetDropDownIndex(DropDownList ddl, string myValue)
    {
        try
        {
            ddl.SelectedValue = myValue;
        }
        catch (Exception)
        {
            ddl.SelectedIndex = -1; // Given value does not exists so we go to the default value
        }
    }
    /// <summary>
    /// Sort the items in a DropDownList
    /// </summary>
    /// <param name="ddl">The DropDownList to be sorted</param> 
    private void SortDropDown(DropDownList ddl)
    {

        // We need to put the Items into a data structure that has a sort method, else write our own.
        string[] myStrings = new string[ddl.Items.Count];

        int index = 0;
        foreach (ListItem item in ddl.Items)
        {
            myStrings[index] = item.Text;
            index++;
        }
        // Sort the array of strings with the built-in sort method
        Array.Sort(myStrings);

        // Clear the items in the ddl
        ddl.Items.Clear();

        foreach (string myString in myStrings)
        {
            ListItem item = new ListItem(myString);
            ddl.Items.Add(item);
        }
    }
}