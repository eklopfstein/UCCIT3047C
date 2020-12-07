/*******************************************************************************
 * Elijah Klopfstein                                                           *
 * klopfsea@mail.uc.edu                                                        *
 * Final Exam                                                                  *
 * Due: April 30th 2020                                                        *
 * IT3047C Spring 2020                                                         *
 * Encrypts and decrypts messages in JSON files                                *
 * *****************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;

public class Encryption
{

    /// <summary>
    /// Just generates a random number for the seed
    /// </summary>
    /// <returns>Random seed as a string</returns>
    public static string seedGenerator()
    {
        Random rand = new Random();
        int seed = 0;
        seed = rand.Next();
        return seed.ToString();
    }

    /// <summary>
    /// Encrypts a message for the given ID with given seed
    /// </summary>
    /// <param name="message">Message to be encrypted</param>
    /// <param name="ID">ID for message</param>
    /// <param name="seed">Seed for encryption</param>
    /// <returns>The encrypted message or an error message if there is an error</returns>
    public static string encrypt(string message, string ID, string seed)
    {
        // Start by making sure the ID and seed aren't blank
        if (ID.Trim() == "")
        {
            return "Please provide an ID.";
        }
        if (seed.Trim() == "")
        {
            return "Please provide a seed.";
        }
        // Now make sure the seed is a number
        int intSeed = 0;
        try
        {
            intSeed = Convert.ToInt32(seed);
        }
        catch
        {
            return "Given seed was not a number.";
        }
        Random rand = new Random(intSeed);
        string result = "";
        // List for mapping file
        List<string> map = new List<string>();

        // Creates a code for each ASCII character
        for (int code = 0; code < 256; code++)
        {
            string path = "";
            path += Convert.ToChar(rand.Next(0, 256));
            // In case this character was already used
            while (map.Contains(path))
            {
                // Use a different one
                path = "";
                path += Convert.ToChar(rand.Next(0, 256));
            }
            map.Add(path);
            result += path;
        }

        // Once the map is made add it to the file
        JSONSerializeTools.Serialize(map, HttpContext.Current.Server.MapPath("~/App_Data/") + ID + " mapping.json");

        // Takes the message and turns the characters into ASCII code numbers
        byte[] numbers = Encoding.ASCII.GetBytes(message);
        // List for the encrytped message
        List<string> characters = new List<string>();
        // Loops through each character and replaces it with the encrypted character
        foreach (byte number in numbers)
        {
            characters.Add(map[number]);
        }

        // Writes the encrypted message to a JSON file and the token to a txt file
        JSONSerializeTools.Serialize(characters, HttpContext.Current.Server.MapPath("~/App_Data/") + ID + " message.json");
        File.WriteAllText(HttpContext.Current.Server.MapPath("~/App_Data/") + ID + " seed.txt", seed);
        // Returns ecrypted message
        return result;
    }

    /// <summary>
    /// Decrypts message for given ID
    /// There needs to be a message file and mapping file with this ID
    /// </summary>
    /// <param name="ID">ID used for message</param>
    /// <returns>The fully decrypted message</returns>
    public static string decrypt(string ID)
    {
        // Creates paths for both files
        string messagePath = HttpContext.Current.Server.MapPath("~/App_Data/" + ID + " message.json");
        string mapPath = HttpContext.Current.Server.MapPath("~/App_Data/" + ID + " mapping.json");
        // Make sure the files exists
        if (!File.Exists(messagePath))
        {
            return "Error with finding message for given ID.";
        }
        if (!File.Exists(mapPath))
        {
            return "Map for given message is missing!";
        }
        string result = "";
        // Gets lists from the JSON files
        List<string> map = (List<string>)JSONSerializeTools.Deserialize<List<string>>(mapPath);
        List<string> message = (List<string>)JSONSerializeTools.Deserialize<List<string>>(messagePath);
        // Loops through each character in the message list
        foreach (string item in message)
        {
            // Loops through each code in the mape
            foreach (string code in map)
            {
                // Once the correct code is found
                if (item == code)
                {
                    // Add the decrypted character to the result string
                    result += Convert.ToChar(map.IndexOf(code));
                    // And move on the mext character
                    break;
                }
            }
        }
        // Once the message is fully decrypted send it to the user
        return result;
    }
}