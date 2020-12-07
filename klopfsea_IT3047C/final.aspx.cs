/*******************************************************************************
 * Elijah Klopfstein                                                           *
 * klopfsea@mail.uc.edu                                                        *
 * Final Exam                                                                  *
 * Due: April 30th 2020                                                        *
 * IT3047C Spring 2020                                                         *
 * C# file behind the final page                                               *
 * Encrypts and decrypts messages and generates a seed                         *
 * *****************************************************************************/
using System;

public partial class final : System.Web.UI.Page
{
    /// <summary>
    /// Encrypts the message and puts the ecrpyted text into the textbox
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEncrypt_Click(object sender, EventArgs e)
    {
        txtEncrypt.Text = Encryption.encrypt(txtClearText.Text, txtID.Text.Trim(), txtSeed.Text.Trim());
    }

    /// <summary>
    /// Decrypts the message and puts the decrypted text into the tectbox
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDecrypt_Click(object sender, EventArgs e)
    {
        txtDecrypt.Text = Encryption.decrypt(txtID.Text.Trim());
    }

    /// <summary>
    /// Generates a random seed for the ecryption
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSeed_Click(object sender, EventArgs e)
    {
        txtSeed.Text = Encryption.seedGenerator();
    }
}