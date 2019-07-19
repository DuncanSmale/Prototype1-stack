using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffects : MonoBehaviour
{
    [Header("Reference")]
        public AudioSource main_source;
        public AudioSource sfx_source;

        public AudioSource HoverSFX;
    
    public void JumpForward () {
        main_source.Pause();
        main_source.time += 0.1f;
        sfx_source.Play();
        Invoke("ResumeSong", 0.2f);
    }

    public void JumpBackward () {
        main_source.Pause();
        main_source.time -= 0.1f;
        sfx_source.Play();
        Invoke("ResumeSong", 0.2f);
    }

    private void ResumeSong () {
        main_source.UnPause();
    }

    public void HoverSound () {
        HoverSFX.Stop();
        HoverSFX.Play();
    }
}
