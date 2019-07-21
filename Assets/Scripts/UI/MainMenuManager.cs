using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{

    public GameObject Cutscene;
    public void StartGame() {
        Cutscene.SetActive(true);
    }

    public void QuitGame () {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void EndScene () {
        SceneManager.LoadScene(1);
    }
}
