using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlScene : MonoBehaviour
{
    [SerializeField] private Button back_button;

    private void Awake()
    {
        back_button.onClick.AddListener(GoToScene);
    }

    private void GoToScene()
    {
        AudioManager.Instance.PlayAudioEffect(AudioTypes.ButtonClick);
        SceneManager.LoadScene(0);
    }
}
