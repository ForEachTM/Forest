using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using UnityEngine;

public class Storage
{
    //public static string _path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

    /// <summary>
    /// Save some object data to file
    /// </summary>
    public static void Save(string _path, object o)
    {
        BinaryFormatter bf = new BinaryFormatter();

        using (Stream fStream = new FileStream(_path,
            FileMode.Create, FileAccess.Write, FileShare.None))
        {
            bf.Serialize(fStream, o);
        }
    }

    /// <summary>
    /// Load some object data from file
    /// </summary>
    public static object Load(string _path)
    {
        BinaryFormatter bf = new BinaryFormatter();
        object i;

        using (FileStream s = File.OpenRead(_path))
        {
            i = bf.Deserialize(s);

        }
        return i;
    }

    public static object LoadCrypted(string _key, string _path)
    {
        BinaryFormatter bf = new BinaryFormatter();
        object i;

        using (FileStream s = File.OpenRead(_path))
        {        
            byte[] array = new byte[s.Length];

            s.Read(array, 0, array.Length);
            string text = Encoding.Default.GetString(array);
            text = Crypter.Decode(_key, text);

            byte[] outArray = Encoding.Default.GetBytes(text);

            Stream stream = new MemoryStream(outArray);

            i = bf.Deserialize(stream);

        }
        return i;
    }
}
