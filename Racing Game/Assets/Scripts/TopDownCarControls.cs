using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCarControls : MonoBehaviour
{
     
    [Header("car settings")]
    public float driftFactor = 0.95f;
    public float accelerationFactor = 25.0f;
    public float turnFactor = 3.5f;
    public float maxSpeed = 12;

    //local variables 

    float accelerationInput =0;
    float steeringInput = 0;
    public float rotationAngle = 0;
    float velocityUp = 0;
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
        KillOrthogonalVelocity();
        ApplySteering();

    }

    void ApplyEnginForce()
    {
        velocityUp = Vector2.Dot(transform.up , carRigidbody2d.velocity);

        if (velocityUp > maxSpeed && accelerationInput > 0)
        {
            return;
        }
        //When you "reverse", the speed will slow down
        if (velocityUp < -maxSpeed * 0.5f && accelerationInput < 0) 
        {
            return;
        }

        if(carRigidbody2d.velocity.sqrMagnitude > maxSpeed * maxSpeed && accelerationInput > 0)
        {
            return;
        }
        //It slows down the car if the condition is true
        if (accelerationInput == 0)
            carRigidbody2d.drag = Mathf.Lerp(carRigidbody2d.drag, 3.0f, Time.fixedDeltaTime * 3);
        else
            carRigidbody2d.drag = 0;
       
        //Create a force for the engine(the vector will be pplying as the force)
        Vector2 engineForceVector = transform.up * accelerationInput * accelerationFactor;

                       //engineForceVector: this is the variable inwhich the force aplyed oon the car object will be stord in 

        //apply force that will be pushing the car forward
        carRigidbody2d.AddForce(engineForceVector,ForceMode2D.Force);
                                                                                             
    
    }

    void ApplySteering()
    {
        //Preventing the car from moving before it moves
        float minSpeedBeforeAllowTurningFactor = (carRigidbody2d.velocity.magnitude/8);

        //Clamp01(minSpeedBeforeAllowTurningFactor) : A period from 0 to 1. If the value is 0, it is multiplied by the values,
        //so it does not move to the right or to the left because the car is parked.
        minSpeedBeforeAllowTurningFactor = Mathf.Clamp01(minSpeedBeforeAllowTurningFactor);

        rotationAngle -= steeringInput * turnFactor * minSpeedBeforeAllowTurningFactor;
        
        carRigidbody2d.MoveRotation(rotationAngle);
    }
    void KillOrthogonalVelocity()//a function to reduce the drifting of the car
    {   // Here I want to calculate the forwardVelocity of the car
        Vector2 forwardVelocity = transform.up * Vector2.Dot(carRigidbody2d.velocity, transform.up);

       
        Vector2 rightVelocity = transform.right * Vector2.Dot(carRigidbody2d.velocity, transform.right);

        //  We fixed the driftFactor to a constant value and multiplied it by the forwardVelocity to reduce the drift
        carRigidbody2d.velocity = forwardVelocity + rightVelocity * driftFactor;
    }
     public float GetlateralVelocity()
    {
        return Vector2.Dot(transform.right, carRigidbody2d.velocity);
    }
    public bool IsTireScreeching(out float lateralVelocity , out bool isBraking)
    {
        lateralVelocity = GetlateralVelocity();
        isBraking = false;

        //check if we are moving forward and the player hitting the brakes
        if(accelerationInput < 0 && velocityUp > 0)
        {
            isBraking = true;
            return true;
        }
        //if we have a lot of side movement
        if (Mathf.Abs(GetlateralVelocity()) > 4.0f)
            return true;
        return false;

    }
   
    //s function to set the input for the vectors which determines the force affevting the car
    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput=inputVector.x;
        accelerationInput = inputVector.y;

    }
    public float GetVelocityMagnitude() {
        return carRigidbody2d.velocity.magnitude;
    }

    


}
