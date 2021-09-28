using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("General Settings")]
    [SerializeField] float Speed = 20f;
    [SerializeField] float Xrange = 15f;
    [SerializeField] float Yrange = 7f;

    [Header("Screen postion based tuning")]
    [SerializeField] float PositionPitchFactor = -2f;
    [SerializeField] float PositionYawFactor = 2f;

    [Header("Player input based tuning")]
    [SerializeField] float ControlPitchFactor = -10f;
    [SerializeField] float ControlRollFactor = -20f;

    float x;
    float y;

    void Update()
    {
        PlayerShipMovement();
        PlayerShipRotation();
    }

    private void PlayerShipMovement()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        float xoffset = x * Time.deltaTime * Speed;
        float newXPos = transform.localPosition.x + xoffset;
        float XClampPos = Mathf.Clamp(newXPos, -Xrange, Xrange);

        float yoffset = y * Time.deltaTime * Speed;
        float newYPos = transform.localPosition.y + yoffset;
        float YClampPos = Mathf.Clamp(newYPos, -Yrange, Yrange);

        transform.localPosition = new Vector3(XClampPos, YClampPos, transform.localPosition.z);
    }

    void PlayerShipRotation()
    {
        float PitchDueToPosition = transform.localPosition.y * PositionPitchFactor;
        float PitchDueToControlThrow = y * ControlPitchFactor;

        float pitch = PitchDueToPosition + PitchDueToControlThrow;
        float yaw = transform.localPosition.x * PositionYawFactor;
        float roll = x * ControlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}