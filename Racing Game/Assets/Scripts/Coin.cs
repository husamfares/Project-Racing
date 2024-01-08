using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


public class Coin : MonoBehaviour
{
    //[SerializeField] private int value;
    //private bool hasTriggered;

    public static int score_count_p1 = 0;
    public Text score_p1;

    public static int score_count_p2 = 0;
    public Text score_p2;
    int done = 8;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (score_count_p1 + score_count_p2 == done)
        {
            score_count_p1 = 0;
            score_count_p2 = 0;
            //done = next lvl coins
        }
        if (collision.CompareTag("player1"))
        {

            
            score_count_p1++;
            score_p1.text = "Palyer1  Score: " + score_count_p1;
            Destroy(gameObject);
        }
        else if (collision.CompareTag("player2"))
        {

            score_count_p2++;
            score_p2.text = "Palyer1  Score: " + score_count_p2;
            Destroy(gameObject);
        }
    }


}
