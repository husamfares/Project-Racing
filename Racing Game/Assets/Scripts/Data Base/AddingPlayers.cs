using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class AddingPlayers : MonoBehaviour
{
    public TMP_InputField Name;
    public TMP_Dropdown currentprofile, currentprofile2;
    public Toggle maleoption, femaleoption;
    public void AddPlayer()
    {
        Player player = new Player();
        player.Name = Name.text;
        if (maleoption.isOn)
        {
            player.gender = Gender.Male;
        }
        else if (femaleoption.isOn)
        {
            player.gender = Gender.Female;
        }
        PlayersList.players.Add(player);
        PlayersList.ChosenPlayer = player;
        //SceneManager.LoadScene("Level 1");
    }
    public void choosecurrent()
    {
        currentprofile.ClearOptions();
        List<string> profilenames = new List<string>();
        for (int i = 0; i < PlayersList.players.Count; i++)
        {
            profilenames.Add(PlayersList.players[i].Name);
        }
        currentprofile.AddOptions(profilenames);

        currentprofile2.ClearOptions();
        currentprofile2.AddOptions(profilenames);
    }
    public void play()
    {
        string playername = currentprofile.options[currentprofile.value].text;
        foreach (Player p in PlayersList.players)
        {
            if (playername == p.Name)
            {
                PlayersList.ChosenPlayer = p;
                break;
            }
        }

        string playername2 = currentprofile2.options[currentprofile2.value].text;
        foreach (Player p in PlayersList.players)
        {
            if (playername2 == p.Name)
            {
                PlayersList.ChosenPlayer2 = p;
                break;
            }
        }
        SceneManager.LoadScene("Level 1");
    }
}
