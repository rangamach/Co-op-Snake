using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    [SerializeField] private Button play__button;
    [SerializeField] private Button control_button;
    [SerializeField] private Button exit_button;

    private void Awake()
    {
        AudioManager.Instance.PlayAudioMusic(AudioTypes.Background);
        play__button.onClick.AddListener(() => GoToScene(2));
        control_button.onClick.AddListener(() => GoToScene(1));
        exit_button.onClick.AddListener(ExitGame);
    }

    private void GoToScene(int index)
    {
        AudioManager.Instance.PlayAudioEffect(AudioTypes.ButtonClick);
        if(index == 2) AudioManager.Instance.PlayAudioEffect(AudioTypes.Resume);
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
