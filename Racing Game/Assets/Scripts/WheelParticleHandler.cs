using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelParticleHandler : MonoBehaviour
{
    float particalEmissionRate = 0;

    TopDownCarControls topDownCarController;

    ParticleSystem particlaeSystemSmoke;
    ParticleSystem.EmissionModule particleSystemEmissionModule;
    private void Awake()
    {
        topDownCarController = GetComponentInParent<TopDownCarControls>();
        
        particlaeSystemSmoke = GetComponent<ParticleSystem>();

        particleSystemEmissionModule = particlaeSystemSmoke.emission;

        particleSystemEmissionModule.rateOverTime = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        particalEmissionRate = Mathf.Lerp(particalEmissionRate , 0 , Time.deltaTime * 5);

        particleSystemEmissionModule.rateOverTime = particalEmissionRate;

        if(topDownCarController.IsTireScreeching(out float lateralVelocity , out bool isBraking))
        {
            if (isBraking)
                particalEmissionRate = 30;
            else
                particalEmissionRate = Mathf.Abs(lateralVelocity) * 2;

        }
  
    }
    
}
