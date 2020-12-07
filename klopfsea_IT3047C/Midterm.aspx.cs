/*******************************************************************************
 * Elijah Klopfstein                                                           *
 * klopfsea@mail.uc.edu                                                        *
 * Midterm                                                                     *
 * Due: Febuary 26th 2020                                                      *
 * IT3047C Spring 2020                                                         *
 * C# code behind the midterm page                                             *
 * Moves the user between questions and the calculates                         *
 * What OS is better for them at the end                                       *
 * *****************************************************************************/
using System;
using System.Web.UI.WebControls;

public partial class Midterm : System.Web.UI.Page
{

    /// <summary>
    /// When the button on the last question is clicked
    /// Will calculate their score and show the OS they should use
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        question5.Visible = false; // Hides the last question
        int score = 0; // Each ansrew has a value that will be used to score them
        score += int.Parse(ddlUser.SelectedValue);
        score += int.Parse(ddlKnowledge.SelectedValue);
        score += int.Parse(ddlMicrosoft.SelectedValue);
        score += int.Parse(ddlSoftware.SelectedValue);
        score += int.Parse(ddlCost.SelectedValue);
        // If the score is more than 0 then we recconmend Linux
        // If it is less than zero we recconmend Windows
        if (score > 0)
        {
            divLinux.Visible = true;
        }
        else
        {
            divWindows.Visible = true;
        }

    }

    /// <summary>
    /// Will hide the current question and show the next one
    /// </summary>
    /// <param name="sender">A button with one of the first 4 questions</param>
    /// <param name="e"></param>
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Button clicked = (Button)sender;
        // At the end of the ID is the question number
        string questionNumber = clicked.ID.Substring(clicked.ID.Length - 1);
        // Use the question number to know what question to hide and what question to show
        switch (questionNumber)
        {
            case "1":
                question1.Visible = false;
                question2.Visible = true;
                break;
            case "2":
                question2.Visible = false;
                question3.Visible = true;
                break;
            case "3":
                question3.Visible = false;
                question4.Visible = true;
                break;
            case "4":
                question4.Visible = false;
                question5.Visible = true;
                break;
        }
    }
}