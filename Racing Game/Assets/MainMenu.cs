using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using TMPro;
public class MainMenu : MonoBehaviour
{
     private string input;
    public void playGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ReadStringInput(string s)
    {
        input = s;
        Debug.Log(input);
    }

  /*  public TextMeshProUGUI output="";

    public void HandleInputData(int val)
    {
        if (val == 0)
        {
            output.text = "hosam";
        }
        if(val == 1)
        {
            output.text = "Abdallh";
        }
        if (val == 2)
        {
            output.text = "omer";
        }
    }*/
}

