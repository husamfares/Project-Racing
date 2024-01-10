using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
     private string input;
     //public Toggle toggle;

    //public Toggle toggle;


    
    //private void Awake()
    //{
    //    //toggle.onValueChanged.AddListener(OnToggleValueChanged);
    //    toggle.onValueChanged.AddListener(OnToggleValueChanged);
    //}
    
    //string lvl = "Level 2";
    //public ToggleController toggleController;
    //public void OnToggleValueChanged(bool isOn)
    //{
    //    if (isOn)
    //    {
    //        lvl = "Level 1";
            
    //    }
    //    else
    //    {
    //        lvl = "Level 2";

            
    //    }
    //}


    
        
    


    public void playGame()
    {



        

        //SceneManager.LoadSceneAsync(4);
        //SceneManager.LoadScene(toggleController.getLvl());

        SceneManager.LoadScene(ToggleController.lvl);

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

