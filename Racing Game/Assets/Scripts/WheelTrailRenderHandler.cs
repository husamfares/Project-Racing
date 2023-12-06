using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelTrailRenderHandler : MonoBehaviour
{
    TopDownCarControls topDownCarController;
    TrailRenderer trailRenderer;


    private void Awake()
    {
        topDownCarController = GetComponentInParent<TopDownCarControls>();

        trailRenderer= GetComponent<TrailRenderer>();

        trailRenderer.emitting = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(topDownCarController.IsTireScreeching(out float lateralVelocity , out bool isBraking))
        {
            trailRenderer.emitting = true;
        }
        else
            trailRenderer.emitting = false;
    }
}
