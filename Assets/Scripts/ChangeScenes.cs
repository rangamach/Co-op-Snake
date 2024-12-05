using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public void ChangeToScene(int scene_index)
    {
        SceneManager.LoadScene(scene_index);
    }
}
