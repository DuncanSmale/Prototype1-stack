﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cutscene : MonoBehaviour
{
    public GameObject MusicControl;
    public GameObject MenuScreen;

    public GameObject Scene1;
    public GameObject Scene2;

    public TMP_Text Counter;
    public Image FillSprite;

    public Image Scene2_Img;
    public Sprite[] graphics;

    private bool Counting = false;

    private void OnEnable() {
        MusicControl.SetActive(false);
        MenuScreen.SetActive(false);
        Scene1.SetActive(true);
        StartCoroutine(Count());
    }

    private void Update() {
        if (Counting)
            FillSprite.fillAmount += Time.deltaTime;
    }

    IEnumerator Count () {
        Counting = true;
        for (int i = 7; i > 0; i--) {
            Counter.text = i.ToString();
            FillSprite.fillAmount = 0;
            yield return new WaitForSecondsRealtime(1);
        }
        Counting = false;
        Scene2.SetActive(true);
        StartCoroutine(FlipBook());
        Scene1.SetActive(false);
    }

    IEnumerator FlipBook() {
        for (int i = 0; i < graphics.Length; i++) {
            Scene2_Img.sprite = graphics[i];
            yield return new WaitForSecondsRealtime(3);
        }
    }
}
