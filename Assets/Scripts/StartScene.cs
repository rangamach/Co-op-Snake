using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    [SerializeField] private Button play_single_player_button;
    [SerializeField] private Button play_two_player_button;
    [SerializeField] private Button control_button;
    [SerializeField] private Button exit_button;
    [SerializeField] private Button help_button;

    private void Awake()
    {
        AudioManager.Instance.PlayAudioMusic(AudioTypes.Background);
        play_single_player_button.onClick.AddListener(() => GoToScene(2));
        play_two_player_button.onClick.AddListener(() => GoToScene(3));
        control_button.onClick.AddListener(() => GoToScene(1));
        help_button.onClick.AddListener(() => GoToScene(5));
        exit_button.onClick.AddListener(ExitGame);
    }

    private void GoToScene(int index)
    {
        AudioManager.Instance.PlayAudioEffect(AudioTypes.ButtonClick);
        if (index == 2)
        {
            AudioManager.Instance.PlayAudioEffect(AudioTypes.Resume);
            PlayerPrefs.SetInt("Mode", 1);
        }
        else if (index == 3)
        {
            AudioManager.Instance.PlayAudioEffect(AudioTypes.Resume);
            PlayerPrefs.SetInt("Mode", 2);
        }
        SceneManager.LoadScene(index);
    }

    private void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
