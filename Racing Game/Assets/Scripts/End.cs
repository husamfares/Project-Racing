using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class End : MonoBehaviour
{



    bool one = false, two = false , one_out = false , two_out = false;
    static int lvl = 0;

    public Text gameOver;
    public Text one_win;
    public Text two_win;

    public GameObject p1;
    public GameObject p2;

    string lvl_name;
    
    // Start is called before the first frame update
    void Start()
    {
        gameOver.enabled = false;
        one_win.enabled = false;
        two_win.enabled = false;

        //lvl_name = SceneManager.GetActiveScene().name;
        //if (lvl == 1 && lvl_name == "Level 1")
        //{
        //    p2.GetComponent<PathFollowCar>().speed = 8;
        //    p2.GetComponent<PathFollowCar>().rotationSpeed = 8;
        //}

        //else if (lvl == 2 && lvl_name == "Level 1.1")
        //{
        //    p2.GetComponent<PathFollowCar>().speed = 8;
        //    p2.GetComponent<PathFollowCar>().rotationSpeed = 8;
        //}


        //else if (lvl == 1 && lvl_name == "Level 2")
        //{

        //}

        //else if (lvl == 2 && lvl_name == "Level 2.1")
        //{
        //}

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    /// <summary>
    ///
    /// lvl = 1
    /// lvl = 2  bomb a
    /// lvl = 3 bomb and lights
    /// </summary>


    bool done = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {


        

        if (one && two && done)
        {



            if (collision.CompareTag("player1"))
            {
                one_out = true;

            }
            else if (collision.CompareTag("player2"))
            {
                two_out = true;
            }




            StartCoroutine(NextLvl());



          



        }

        if (collision.CompareTag("player1"))
        {
            one = true;

        }
        else if (collision.CompareTag("player2"))
        {
            two = true;
        }




    }

    IEnumerator NextLvl()
    {


        gameOver.enabled = true;

        if (one_out)
            one_win.enabled = true;
        else if (two_out)
            two_win.enabled = true;

        done = false;
            yield return new WaitForSeconds(3f);


        if (SceneManager.GetActiveScene().name == "Level 1")
        {

            if (lvl == 1)
            {



                // computer

                
                // speed and rotation = 8
            }
            else if (lvl == 2)
            {

                //speed and rotation = 8 
            }

            else
            {

            }
            // ...        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
        else
        {

        }

        
        lvl++;
        
        lvl_name = SceneManager.GetActiveScene().name;
        if (lvl == 1 && lvl_name == "Level 1")
            SceneManager.LoadScene("Level 1.1");
        else if (lvl == 1 && lvl_name == "Level 2")
            SceneManager.LoadScene("Level 2.1");
        else if (lvl == 2 && lvl_name == "Level 1.1")
            SceneManager.LoadScene("Level 1.2");
        else if (lvl == 2 && lvl_name == "Level 2.1")
            SceneManager.LoadScene("Level 2.2");

    }


}
