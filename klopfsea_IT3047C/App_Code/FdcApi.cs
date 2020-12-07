/*******************************************************************************
 * Elijah Klopfstein                                                           *
 * klopfsea@mail.uc.edu                                                        *
 * Assignment 10                                                               *
 * Due: April 19th 2020                                                        *
 * IT3047C Spring 2020                                                         *
 * C# file for quering the FDC API                                             *
 * https://fdc.nal.usda.gov/api-guide.html                                     *
 * *****************************************************************************/
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;

public class FdcApi
{

    /// <summary>
    /// Sends the given query to the api
    /// </summary>
    /// <param name="query">Query to run on the api</param>
    /// <returns>Details about FDC regulated products</returns>
    public static Dictionary<string, List<string>> request(string query)
    {
        Dictionary<string, List<string>> results = new Dictionary<string, List<string>>();
        string URL = "https://api.nal.usda.gov/fdc/v1/foods/search?api_key=jWZyVDegNay78Wtog8SgBf1wgTgXoKS3Sul1QZo5&query=" + query;
        WebClient client = new WebClient();

        try // Try to run the query
        {
            string jsonString = client.DownloadString(URL);

            Dictionary<string, object> values = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);
            JArray foods = (JArray)values["foods"];

            foreach (JObject jObject in foods)
            {
                List<string> details = new List<string>();

                details.Add(jObject["description"].ToString());

                // Some items will not have owner or ingredients listed
                if (jObject["brandOwner"] is null)
                {
                    details.Add("No Owner");
                }
                else
                {
                    details.Add(jObject["brandOwner"].ToString());
                }

                details.Add(jObject["publishedDate"].ToString());

                if (jObject["ingredients"] is null)
                {
                    details.Add("No Ingredients");
                }
                else
                {
                    details.Add(jObject["ingredients"].ToString());
                }

                results.Add(jObject["fdcId"].ToString(), details);
            }
        }
        catch // Will fail due to bad queries or lack of internet connection
        {
            throw new Exception("Invalid query or poor internet connection");
        }

        return results;
    }
}