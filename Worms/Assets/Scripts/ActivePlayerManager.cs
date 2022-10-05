using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActivePlayerManager : MonoBehaviour
{
    [SerializeField] private ActivePlayer player1;
    [SerializeField] private ActivePlayer player2;
    [SerializeField] private Transform player1Cam;
    [SerializeField] private Transform player2Cam;
    [SerializeField] private Transform endCamera;
    [SerializeField] private Camera gameCamera;
    [SerializeField] private float maxTimePerTurn;
    [SerializeField] private float timeBetweenTurns;
    [SerializeField] private TextMeshProUGUI seconds;
    [SerializeField] private TextMeshProUGUI playerTurn;

    private ActivePlayer currentPlayer;
    private float currentTurnTime;
    private float currentDelay;

    private void Start()
    {
        player1.AssignManager(this);
        player2.AssignManager(this);

        currentPlayer = player1;
        gameCamera.transform.SetParent(currentPlayer.transform);
        gameCamera.transform.position = player1Cam.transform.position;
        gameCamera.transform.rotation = player1Cam.transform.rotation;
        playerTurn.text = "Player 1 turn";
    }

    private void Update()
    {
        if (currentDelay <= 0)
        {
            currentTurnTime += Time.deltaTime;
            seconds.text = Mathf.RoundToInt(maxTimePerTurn - currentTurnTime).ToString();

            if (currentTurnTime >= maxTimePerTurn)
            {
                ChangeTurn();
            }
        }
        else
        {
            seconds.text = Mathf.RoundToInt(maxTimePerTurn).ToString();
            currentDelay -= Time.deltaTime;
        }
    }

    public ActivePlayer GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public bool PlayerCanPlay()
    {
        return currentDelay <= 0;
    }

    public void ChangeTurn()
    {
        currentTurnTime = 0;
        currentDelay = timeBetweenTurns;

        if (player1 == currentPlayer)
        {
            currentPlayer = player2;
            gameCamera.transform.position = player2Cam.transform.position;
            gameCamera.transform.rotation = player2Cam.transform.rotation;
            playerTurn.text = "Player 2 turn";

        }
        else if (player2 == currentPlayer)
        {
            currentPlayer = player1;
            gameCamera.transform.position = player1Cam.transform.position;
            gameCamera.transform.rotation = player1Cam.transform.rotation;
            playerTurn.text = "Player 1 turn";
        }

        gameCamera.transform.SetParent(currentPlayer.transform);
    }
}
