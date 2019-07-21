using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDone : MonoBehaviour
{
    public AudioSource Music;
    public AudioClip NewSong;

    private void OnEnable() {
        Music.Stop();
        Music.clip = NewSong;
        Music.Play();
    }
}
