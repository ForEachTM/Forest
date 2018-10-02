using System;
using System.IO;
using UnityEngine;

using Random = System.Random;

// Data crypter
public static class Crypter
{
    private const int MIN = 10, MAX = 1000;

    /// <summary>
    /// Code some string data using int key from text
    /// </summary>
    public static string Code(string key, string text)
    {
        try
        {
            Random r = new Random(int.Parse(key));
            string output = "";

            foreach (char c in text)
            {
                int charCode = c;
                charCode += r.Next(MIN, MAX);
                char outChar = (char)charCode;
                output += outChar;
            }

            return output;

        }
        catch (Exception e)
        {
            Debug.Log("Error in Code.text method\n" + e.Message);
            return null;
        }
    }
    /// <summary>
    /// Decode some string data using int key from source text
    /// </summary>
    public static string Decode(string key, string text)
    {
        try
        {
            Random r = new Random(int.Parse(key));
            string output = "";

            foreach (char c in text)
            {
                int charCode = c;
                charCode -= r.Next(MIN, MAX);
                char outChar = (char)charCode;
                output += outChar;
            }

            return output;

        }
        catch (Exception e)
        {
            Debug.Log("Error in Decode.text method\n" + e.Message);
            return null;
        }
    }

    /// <summary>
    /// Rewrite file with coded file`s data 
    /// </summary>
    public static bool CodeFile(string key, string path)
    {
        try
        {
            string output = "";

            StreamReader sr = new StreamReader(path);
            string text = sr.ReadToEnd();
            sr.Close();

            output = Code(key, text);

            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(output);
            sw.Close();

            return true;

        }
        catch (Exception e)
        {
            Debug.Log("Error in Code.file method\n" + e.Message);
            return false;
        }
    }
    /// <summary>
    /// Decode string data from file;
    /// </summary>
    public static string DecodeFromFile(string key, string path)
    {
        try
        {
            string output = "";

            StreamReader sr = new StreamReader(path);
            string text = sr.ReadToEnd();
            sr.Close();

            output = Decode(key, text);

            return output;

        }
        catch (Exception e)
        {
            Debug.Log("Error in Decode.fromFile method\n" + e.Message);
            return null;
        }
    }
    /// <summary>
    /// Rewrite file with decoded file`s data 
    /// </summary>
    public static string DecodeFile(string key, string path)
    {
        try
        {
            string output = "";

            StreamReader sr = new StreamReader(path);
            string text = sr.ReadToEnd();
            sr.Close();

            output = Decode(key, text);

            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(output);
            sw.Close();

            return text;

        }
        catch (Exception e)
        {
            Debug.Log("Error in Decode.fromFile method\n" + e.Message);
            return null;
        }
    }

}
