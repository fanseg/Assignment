using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class ActivePlayerInput : MonoBehaviour
{
    [SerializeField] private ActivePlayerManager manager;
    [SerializeField] private float walkingSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float jumpForce;

    //[SerializeField] private float speedH = 2.0f;
    //[SerializeField] private float speedV = 2.0f;
    //[SerializeField] private Camera characterCam;

    //private float yaw = 0.0f;
    //private float pitch = 0.0f;

    //[SerializeField] private float pitchClamp = 90;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (manager.PlayerCanPlay())
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                ActivePlayer currentPlayer = manager.GetCurrentPlayer();
                currentPlayer.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
            }

            if (Input.GetAxis("Vertical") != 0)
            {
                ActivePlayer currentPlayer = manager.GetCurrentPlayer();
                currentPlayer.transform.Translate(transform.forward * walkingSpeed * Time.deltaTime * Input.GetAxis("Vertical"));
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                ActivePlayer currentPlayer = manager.GetCurrentPlayer();
                currentPlayer.GetComponentInChildren<SniperWeapon>().Shoot();
                manager.ChangeTurn();
            }

            if (Input.GetKeyDown(KeyCode.Mouse1)) 
            {
                ActivePlayer currentPlayer = manager.GetCurrentPlayer();
                currentPlayer.GetComponentInChildren<CloseWeapon>().Shoot();
                manager.ChangeTurn();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

            //ReadRotationInput(manager.GetCurrentPlayer());
        }
    }

    private void Jump() 
    {
        ActivePlayer currentPlayer = manager.GetCurrentPlayer();
        if (currentPlayer.IsGrounded()) 
        {
            manager.GetCurrentPlayer().GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
        }
    }

    //private void ReadRotationInput(ActivePlayer currentPlayer) 
    //{
    //    yaw += speedH * Input.GetAxis("Mouse X");
    //    pitch -= speedV * Input.GetAxis("Mouse Y");
    //    pitch = Mathf.Clamp(pitch, -pitchClamp, pitchClamp);

    //    characterCam.transform.localEulerAngles = new Vector3(pitch, 0.0f, 0.0f);
    //    currentPlayer.transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
    //}
}
