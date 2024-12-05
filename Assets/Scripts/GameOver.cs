using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Button restart;

    private void Awake()
    {
        restart.onClick.AddListener(Restart);
    }

    private void Restart()
    {
        GetComponent<ChangeScenes>().ChangeToScene(0);
    }
}
