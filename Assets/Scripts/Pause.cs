using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{

    [SerializeField] private GameObject pop_up_objs;
    [SerializeField] private Button resume_button;
    [SerializeField] private Button exit_button;
    [SerializeField] private Button restart_button;

    private void Awake()
    {
        resume_button.onClick.AddListener(Resume);
        exit_button.onClick.AddListener(Exit);
        restart_button.onClick.AddListener(Restart);
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AudioManager.Instance.PlayAudioEffect(AudioTypes.Pause);
            pop_up_objs.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void Exit()
    {
        AudioManager.Instance.PlayAudioEffect(AudioTypes.ButtonClick);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void Resume()
    {
        AudioManager.Instance.PlayAudioEffect(AudioTypes.ButtonClick);
        AudioManager.Instance.PlayAudioEffect(AudioTypes.Resume);
        pop_up_objs.SetActive(false);
        Time.timeScale = 1;
    }

    private void Restart()
    {
        AudioManager.Instance.PlayAudioEffect(AudioTypes.ButtonClick);
        Time.timeScale = 1;
        if (PlayerPrefs.GetInt("Mode") == 1)
        {
            SceneManager.LoadScene(2);
        }
        else  if (PlayerPrefs.GetInt("Mode") == 2)
        {
            SceneManager.LoadScene(3);
        }
    }
}
