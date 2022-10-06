using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ActivePlayerInput : MonoBehaviour
{
    [SerializeField] private ActivePlayerManager manager;
    [SerializeField] private float walkingSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float jumpForce;

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
}
