using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Slow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Start is called before the first frame update
    public GameObject slow;

    public GameObject p1;
    public GameObject p2;


    public TopDownCarControls topDownCarControl;




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
            topDownCarControl.FlashSpeedIncrease(1f, 0.5f);
        }
      
        else if (collision.CompareTag("player2"))
        {

            topDownCarControl = p2.GetComponent<TopDownCarControls>();
            topDownCarControl.FlashSpeedIncrease(1f, 0.5f);
        }


        DestroyObject(slow);

    }


}
