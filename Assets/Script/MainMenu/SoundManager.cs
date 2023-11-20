using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public GameObject ON;
    public GameObject OFF;
    public AudioSource sumberSuara;

    public void Slider(float nilaiSlider)
    {
        sumberSuara.volume = nilaiSlider;
    }

    public void On()
    {
        AudioListener.volume = 0;
        ON.SetActive(false);
        OFF.SetActive(true);
    }

    public void Off()
    {
        AudioListener.volume = 1;
        ON.SetActive(true);
        OFF.SetActive(false);
    }
}
