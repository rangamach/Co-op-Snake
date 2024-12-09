using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private string winner;
    private int score;
    [SerializeField] private Button restart;
    [SerializeField] private TextMeshProUGUI player_text;
    [SerializeField] private TextMeshProUGUI score_text;
    [SerializeField] private Button main_menu;

    private void Awake()
    {
        AudioManager.Instance.PlayAudioEffect(AudioTypes.GameOver);
        restart.onClick.AddListener(Restart);
        main_menu.onClick.AddListener(MainMenu);
        winner = PlayerPrefs.GetString("Winner");
        score = PlayerPrefs.GetInt("Size");
        SetText();
    }

    private void SetText()
    {
        if (PlayerPrefs.GetInt("Mode") == 1)
        {
            player_text.text = PlayerPrefs.GetString("Winner");
            score_text.text = "Player has " + score + " points!!!";
        }
        else if (PlayerPrefs.GetInt("Mode") == 2)
        {
            if (winner == "Player 1 and Player 2")
            {
                player_text.text = winner + " tied with same points!!!";
                score_text.text = "Player 1 and Player tied with " + score.ToString() + " points!!!";
            }
            else
            {
                player_text.text = winner + " has won!!!";
                score_text.text = winner + " won with " + score.ToString() + " points!!!";
            }
        }
    }

    private void Restart()
    {
        AudioManager.Instance.PlayAudioEffect(AudioTypes.ButtonClick);
        AudioManager.Instance.PlayAudioEffect(AudioTypes.Resume);
        if (PlayerPrefs.GetInt("Mode") == 1)
        {
            SceneManager.LoadScene(2);
        }
        else if (PlayerPrefs.GetInt("Mode") == 2)
        {
            SceneManager.LoadScene(3);
        }
    }


    private void MainMenu()
    {
        AudioManager.Instance.PlayAudioEffect(AudioTypes.ButtonClick);
        SceneManager.LoadScene(0);
    }
}
