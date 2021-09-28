using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] PlayerMovement PM;
    [SerializeField] ParticleSystem PlayerShipExplosion;
    [SerializeField] MeshRenderer PMR;
    [SerializeField] BoxCollider PBC;

    private void OnTriggerEnter(Collider trigg)
    {
        if(trigg.gameObject.tag != "LandingPad")
        {
            DisablePlayerMovement();
            PlayerShipExplosionEffect();
        }
        
    }

    private void DisablePlayerMovement()
    {
        PM.enabled = false;
        Invoke("ReloadScene", 1f);
    }

    private void ReloadScene()
    {
        int CurrentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentScene);
    }

    private void PlayerShipExplosionEffect()
    {
        PlayerShipExplosion.Play();
        PMR.enabled = false;
        PBC.enabled = false;
    }
    
}
