using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlightMove : MonoBehaviour
{
    Light light;
    public float _energy = 100;
    public float _disChargeSpeed = 3;
    
    
    void Start()
    {
        light = GetComponentInChildren<Light>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            light.enabled = !light.enabled;
        }

        if (light.enabled)
        {
            _energy -= Time.deltaTime * _disChargeSpeed;
            _energy = Mathf.Clamp(_energy, 0, 100);
        }

        if (_energy < 20f)
        {
            light.intensity = Random.Range(0.3f, 1f);
        }
        
        if (_energy <= 0f)
        {
            enabled = false;
            
        }
        
    }
}
