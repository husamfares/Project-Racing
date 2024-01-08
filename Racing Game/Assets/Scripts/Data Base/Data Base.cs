using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    void Awake()
    {
        int count = PlayerPrefs.GetInt("players count");
        for (int i = 0; i < count; i++)
        {
            Player p = new Player();
            p.Name = PlayerPrefs.GetString("player " + i + " name");
            PlayersList.players.Add(p);
        }

    }

    private void OnApplicationQuit()
    {
        SaveData();
    }
    public static void SaveData()
    {
        PlayerPrefs.SetInt("players count", PlayersList.players.Count);
        for (int i = 0; i < PlayersList.players.Count; i++)
        {
            PlayerPrefs.SetString("player " + i + " name", PlayersList.players[i].Name);
        }
    }
}
