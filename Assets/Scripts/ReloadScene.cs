using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ReloadScene : MonoBehaviour
{
   
    public KeyCode reloadKey = KeyCode.R; // Key to trigger scene reload

    private void Update()
    {
        if (Input.GetKeyDown(reloadKey))
        {
            ReloadCurrentScene();
        }
    }

    private void ReloadCurrentScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
