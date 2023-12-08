using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSfxHandler : MonoBehaviour

{
    [Header("Audio sources")]
    public AudioSource TierScreechinAudioSource;
    public AudioSource EngineAudioSource;
    public AudioSource CarHitAudioSource;

    //local variables
    float desiredEnginePitch = 0.5f;
    float tierScreechPith = 0.5f;

    TopDownCarControls topDownCarControls;
    private void Awake()
    {
        topDownCarControls = GetComponent<TopDownCarControls>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateEngineSfx();
        UpdateTierScreechingSfx();
    }

    void UpdateEngineSfx() 
    {
        //handle engine SFX
        float velocityMagnitude = topDownCarControls.GetVelocityMagnitude();
        //encrease the engine volume as the car goes faster
        float desiredEngineVolume=velocityMagnitude*0.05f;
        //but keep a minimum level so it playes even if the car is idle
        desiredEngineVolume = Mathf.Clamp(desiredEngineVolume, 0.2f, 1.0f);

        EngineAudioSource.volume = Mathf.Lerp(EngineAudioSource.volume, desiredEngineVolume, Time.deltaTime * 10);

        //to add more variations to the engine sound we also change the pitch 
        desiredEnginePitch = velocityMagnitude * 0.2f;
        desiredEnginePitch = Mathf.Clamp(desiredEnginePitch, 0.5f, 2f);
        EngineAudioSource.pitch = Mathf.Lerp(EngineAudioSource.pitch, desiredEnginePitch, Time.deltaTime * 1.5f);
    }
    void UpdateTierScreechingSfx() 
    { 

    //    //handle tier screechin SFX
        if(topDownCarControls.IsTireScreeching(out float lateralVelocity,out bool isBreaking))
        {
            //if the car is braking we wnt the tier to screech to be louder and also to  change the pitch
            if (isBreaking)
            {
                TierScreechinAudioSource.volume = Mathf.Lerp(TierScreechinAudioSource.volume, 1.0f, Time.deltaTime * 10);
                tierScreechPith = Mathf.Lerp(tierScreechPith, 0.5f, Time.deltaTime * 10);
            }
            else
            {
                //if we arn`t braking we still want to play this screech sound if  the player is drifting
                TierScreechinAudioSource.volume = Mathf.Abs(lateralVelocity) * 0.05f;
                tierScreechPith = Mathf.Abs(lateralVelocity) * 0.1f;
            }
           
        }
        //fade out the tire screech SFX  if we are not  screeching
        else { TierScreechinAudioSource.volume = Mathf.Lerp(TierScreechinAudioSource.volume, 0, Time.deltaTime * 10); }
    }
    //void UpdateTierScreechingSfx()
    //{
    //    if (topDownCarControls.IsTireScreeching(out float lateralVelocity, out bool isBreaking))
    //    {
    //        if (isBreaking)
    //        {
    //            // If the car is braking, increase volume and change pitch
    //            TierScreechinAudioSource.volume = Mathf.Lerp(TierScreechinAudioSource.volume, 1.0f, Time.deltaTime * 10);
    //            tierScreechPith = Mathf.Lerp(tierScreechPith, 0.5f, Time.deltaTime * 10);
    //        }
    //        else
    //        {
    //            // If not braking, play screech sound based on lateral velocity
    //            TierScreechinAudioSource.volume = Mathf.Abs(lateralVelocity) * 0.05f;
    //            tierScreechPith = Mathf.Abs(lateralVelocity) * 0.1f;
    //        }
    //    }
    //    else
    //    {
    //        // If tire screeching is not detected, decrease volume gradually
    //        TierScreechinAudioSource.volume = Mathf.Lerp(TierScreechinAudioSource.volume, 0, Time.deltaTime * 10);
    //    }
    //}


}

