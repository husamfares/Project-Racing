using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //reference to the previous component (script)
    TopDownCarControls topDownCarControler;

    //and then we use the awake function to get that compnent

    private void Awake()
    {
        topDownCarControler=GetComponent<TopDownCarControls>();
    }


    //in the update fun we will collect inputs from the user   using unity's built in features
    // Update is called once per frame
    void Update()
    {

        Vector2 inputVector = Vector2.zero;//creat a vector2 input
        inputVector.x = Input.GetAxis("Horizontal");
        //??24 & 26 
        inputVector.y = Input.GetAxis("Vertical");
        topDownCarControler.SetInputVector(inputVector);//here we're using setinputVector() fun from the previous script to  update the  input vector 
    
    
    }

}