using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITrigger : MonoBehaviour
{
    public GameObject uiToDisable;
    public GameObject uiToEnable;

    public AudioSource musicSource;
    public AudioClip Ambience;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (uiToDisable != null) uiToDisable.SetActive(false);
            if (uiToEnable != null) uiToEnable.SetActive(true);

            if (musicSource != null && Ambience != null)
            {
                musicSource.Stop();
                musicSource.clip = Ambience;
                musicSource.Play();
            }
        }
    }
}
