using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingPadCollision : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject IngameScore;

    private void OnTriggerEnter(Collider trigg)
    {
        if(trigg.gameObject.tag == "Player")
        {
            canvas.SetActive(true);
            IngameScore.SetActive(false);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
