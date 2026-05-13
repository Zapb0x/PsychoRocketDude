using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITrigger : MonoBehaviour
{
    private BoxCollider2D UIAppear;

    [Header("Music")]
    [SerializeField] private AudioClip Ambience;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SoundManager.instance.PlaySound(Ambience);
        }
    }
}
