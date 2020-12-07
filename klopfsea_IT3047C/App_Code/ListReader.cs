/*******************************************************************************
 * Elijah Klopfstein                                                           *
 * klopfsea@mail.uc.edu                                                        *
 * Assigment 03                                                                *
 * Due: Febuary 5th 2020                                                       *
 * IT3047C Spring 2020                                                         *
 * Reads from file to create of list of key value pairs                        *
 * Keys are models and values are options                                      *
 * *****************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;


public class ListReader
{
    /// <summary>
    /// Reads from a file a stores the values in a list
    /// </summary>
    /// <returns>List of key value pairs. Key is the model, values are the options</returns>
    public static List<KeyValuePair<string, List<string>>> ReadCarList()
    {

        List<KeyValuePair<string, List<string>>> carList = new List<KeyValuePair<string, List<string>>>();

        StreamReader sr = null;
        try
        {   // Open the text file using a stream reader.
            string path = HttpContext.Current.Server.MapPath("~/Models/modelsAndOptions.txt");
            using (sr = new StreamReader(path))
            {
                string[] car;
                // Reads each line to get each model and splits on commas to get each option
                while ((car = sr.ReadLine().Split(',')) != null)
                {
                    List<string> options = new List<string>();
                    string model = car[0];
                    bool first = true;
                    foreach (string part in car)
                    {
                        if (first)
                        {
                            first = false; // Fisrt part was the model
                        }
                        else
                        {
                            options.Add(part);
                        }
                    }
                    KeyValuePair<string, List<string>> modelAndOptions = new KeyValuePair<string, List<string>>(model, options);
                    carList.Add(modelAndOptions);
                }
            }
        }
        catch (Exception)
        {
            // What can we do here? Who do we tell?             
        }
        finally { try { sr.Close(); } catch (Exception) { } }
        return carList;
    }
}