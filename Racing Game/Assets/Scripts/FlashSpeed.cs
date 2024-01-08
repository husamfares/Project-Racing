using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;


public class flashSpeed : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject flash;

    public GameObject p1;
    public GameObject p2;


    public TopDownCarControls topDownCarControl;

    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //public IEnumerator speed(float duration)
    //{

    //    //yield return new WaitForSeconds(duration);
    //    //p2.GetComponent<PathFollowCar>().speed = 5;
    //    //p2.GetComponent<PathFollowCar>().rotationSpeed = 5;

    //}


    private void OnTriggerEnter2D(Collider2D collision)
    {


        //topDownCarControl.FlashSpeedIncrease(1f, 20f);



        if (collision.CompareTag("player1"))
        {

            topDownCarControl = p1.GetComponent<TopDownCarControls>();
            topDownCarControl.FlashSpeedIncrease(1f, 20f);
        }
        else if (collision.CompareTag("player2") && ((SceneManager.GetActiveScene().name == "Level 1" || SceneManager.GetActiveScene().name == "Level 1.1") || SceneManager.GetActiveScene().name == "Level 1.2"))
        {

            p2.GetComponent<PathFollowCar>().speed += 1;
            p2.GetComponent<PathFollowCar>().rotationSpeed += 1;



        }



        else if (collision.CompareTag("player2"))
        {

            topDownCarControl = p2.GetComponent<TopDownCarControls>();
            topDownCarControl.FlashSpeedIncrease(1f, 20f);
        }


        DestroyObject(flash);

    }

}
