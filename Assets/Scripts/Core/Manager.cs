using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using Debug = UnityEngine.Debug;

// Core methods manager
public class Manager : MonoBehaviour
{
    private const string
        CRYPT_KEY = "1984", // must be int number written in string, just for fun ;)
        SAVEGAME_PATH = "",
        SAVEGAME_NAME = "somedata.dtb";

    private const int
        SAVEGAME_INTERVAL = 5;

    public static Values VALS;


    public void Start()
    {
        Values v = GAME_LOAD();
        if (v != null) VALS = v; else VALS = new Values();     

        StartCoroutine(SaveGame());
    }

    IEnumerator SaveGame()
    {
        yield return new WaitForSeconds(SAVEGAME_INTERVAL);
        GAME_SAVE();
        StartCoroutine(SaveGame());
    }

    /// <summary>
    /// Save game to file with path:SAVEGAME_PATH and name:SAVEGAME_NAME
    /// </summary>
    public static bool GAME_SAVE()
    {
        // Saving game
        try
        {
            Storage.Save(Path.Combine(SAVEGAME_PATH, SAVEGAME_NAME), VALS);
            //Crypter.CodeFile(CRYPT_KEY, Path.Combine(SAVEGAME_PATH, SAVEGAME_NAME));

            Debug.Log("> Game saved");
            return true;
        }
        catch (Exception e)
        {
            Debug.Log("> Error in GAME_SAVE method\n"+e.Message);   
            return false;
        }
    }

    /// <summary>
    /// Load game from file with path:SAVEGAME_PATH and name:SAVEGAME_NAME
    /// </summary>
    public static Values GAME_LOAD()
    {
        // Saving game
        try
        {
            //Debug.Log(Crypter.DecodeFile(CRYPT_KEY, Path.Combine(SAVEGAME_PATH, SAVEGAME_NAME)));
            //Debug.Log("decrypted");
            Values v = (Values)Storage.Load(Path.Combine(SAVEGAME_PATH, SAVEGAME_NAME));
            //Debug.Log("loaded");
            //Crypter.CodeFile(CRYPT_KEY, Path.Combine(SAVEGAME_PATH, SAVEGAME_NAME));
            //Debug.Log("coded");

            Debug.Log("> Game loaded");
            Debug.Log("> Loaded values: \nPoz: "+v.PLAYER_X+"x"+v.PLAYER_Y);
            return v;
        }
        catch (Exception e)
        {
            Debug.Log("> Error in GAME_LOAD method\n" + e.Message);
            return null;
        }
    }
}
