using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public GameObject MusicControl;
    public GameObject MenuScreen;

    public GameObject Scene1;
    public GameObject Scene2;


    private void OnEnable() {
        MusicControl.SetActive(false);
        MenuScreen.SetActive(false);
        Scene1.SetActive(true);
    }
}
