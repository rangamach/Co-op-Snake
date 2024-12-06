using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreCheck : MonoBehaviour
{
    [SerializeField] private SnakeMovement player1;
    [SerializeField] private SnakeMovement player2;
    public void WhoWon()
    {
        if (player1.GetSnakeSize() < player2.GetSnakeSize())
        {
            PlayerPrefs.SetString("Winner", "Player 2");
            PlayerPrefs.SetInt("Size", player2.GetSnakeSize());
        }
        else if (player1.GetSnakeSize() > player2.GetSnakeSize())
        {
            PlayerPrefs.SetString("Winner", "Player 1");
            PlayerPrefs.SetInt("Size", player1.GetSnakeSize());
        }
        else
        {
            PlayerPrefs.SetString("Winner", "Player 1 and Player 2");
            PlayerPrefs.SetInt("Size", player1.GetSnakeSize());
        }
        SceneManager.LoadScene(3);
    }
}
