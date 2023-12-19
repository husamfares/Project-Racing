using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject coin;
    int coinNumber = 0;
    public Text score_Text;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        coinNumber++;
        coin.SetActive(false);
        score_Text.text = "score : " +coinNumber.ToString();


    }
}
