﻿/*******************************************************************************
 * Elijah Klopfstein                                                           *
 * klopfsea@mail.uc.edu                                                        *
 * Final                                                                       *
 * Due: April 30th 2020                                                        *
 * IT3047C Spring 2020                                                         *
 * Class for creating and reading the JSON files                               *
 * *****************************************************************************/
using Newtonsoft.Json;
using System.IO;

public class JSONSerializeTools
{
    /// <summary>
    /// Serialize an object to JSON. Uses Newtonsoft classes
    /// </summary>
    /// <param name="someData">The object to serialize</param>
    /// <param name="filePath">The file to write into. Will be overwritten if it already exists</param>
    public static void Serialize(object someData, string filePath)
    {
        JsonSerializer js = new JsonSerializer();   // Newtonsoft!
        if (File.Exists(filePath)) { File.Delete(filePath); }
        StreamWriter sw = new StreamWriter(filePath);
        JsonWriter jw = new JsonTextWriter(sw);
        js.Serialize(jw, someData);
        jw.Close();
        sw.Close();
    }
    /// <summary>
    /// Read a JSON string from a file and deserialize it into an object. Uses Newtonsoft classes
    /// </summary>
    /// <typeparam name="T">Data type of the object that is in the file</typeparam>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static object Deserialize<T>(string filePath)
    {
        return JsonConvert.DeserializeObject<T>(File.ReadAllText(filePath));
    }
}