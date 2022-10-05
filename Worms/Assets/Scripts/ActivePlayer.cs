using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActivePlayer : MonoBehaviour
{

    //Attached to each player, used to control who is going to be executing whatever action
    [SerializeField] private TextMeshProUGUI pointsUI;

    private ActivePlayerManager manager;
    private Vector3 playerStartPosition;
    private int playerPoints;
    


    private void Start()
    {
        playerPoints = 0;
        pointsUI.text = "Deaths: " + playerPoints;
        playerStartPosition = transform.position;
    }

    public void AssignManager(ActivePlayerManager theManager)
    {
        manager = theManager;
    }

    public bool IsGrounded()
    {
        RaycastHit result;
        return Physics.SphereCast(transform.position, 0.05f, -transform.up, out result, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.position = playerStartPosition;
    }

    public void ResetCharacter()
    { 
        transform.position = playerStartPosition;
        playerPoints++;
        pointsUI.text = "Deaths: " + playerPoints;
    }
}
