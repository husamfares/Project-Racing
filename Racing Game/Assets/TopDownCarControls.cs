using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCarControls : MonoBehaviour
{
    [Header("car settings")]
    public float accelerationFactor = 30.0f;
    public float turnFactor;

        //local variables 

    float accelerationInput=0;
    float steeringInput = 0;
    float rotationAngle = 0;

    //Components

    Rigidbody2D carRigidbody2d;//to have access the rigidbody component in unity


     void Awake()
    //awake is called when the script instance is being loaded
    //awake function atach code to unity's rigidbody
    {
        carRigidbody2d=GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //a function that is used to  use unity's built in physics 
     void FixedUpdate()
    {
        ApplyEnginForce();
        ApplySteering();

    }

    void ApplyEnginForce()
    {
        //Create a force for the engine(the vector will be pplying as the force)
        Vector2 engineForceVector = transform.up * accelerationInput * accelerationFactor;

                                                                                                 //engineForceVector: this is the variable inwhich the force aplyed oon the car object will be stord in 

        //apply force that will be pushing the car forward
        carRigidbody2d.AddForce(engineForceVector,ForceMode2D.Force);
                                                                                                  //carRigidbody2d:add this varible to the rigidbody's component to apply the force onn the car object
                                                                                                 //ForceMode2D.Force indicates that the force is applied continuously and scaled by the Rigidbody's mass.
    
    }

    void ApplySteering()
    {
        //update the rotation angle based  on input
        rotationAngle -= steeringInput * turnFactor;
        //apply steering the rotating the car object
        carRigidbody2d.MoveRotation(rotationAngle);

    }

    //s function to set the input for the vectors which determines the force affevting the car
    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput=inputVector.x;
        steeringInput = inputVector.y;

    }


}
