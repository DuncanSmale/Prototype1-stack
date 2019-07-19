using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{

    public void StartGame() {
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame () {
        Application.Quit();
        Debug.Log("Quit");
    }
}
