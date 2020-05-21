using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickSound : MonoBehaviour
{
    public AudioSource clickSound;
    public AudioSource overSound;

    public void PlayClickSound()
    {
        clickSound.Play();
    }

    public void PlayOverSound()
    {
        overSound.Play();
    }
}
