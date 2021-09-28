using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    void Update()
    {
        ProcessShooting();
    }

    private void ProcessShooting()
    {
        if (Input.GetButton("Fire1"))
        {
            SetLaserActive(true);
        }
        else
        {
            SetLaserActive(false);
        }
    }

    private void SetLaserActive(bool isActive)
    {
        foreach (GameObject laser in lasers)
        {
            var Emission = laser.GetComponent<ParticleSystem>().emission;
            Emission.enabled = isActive;
        }
    }
}
