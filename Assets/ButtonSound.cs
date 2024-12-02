using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(PlaySound);
        }
    }

    public void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogError("AudioSource не знайдено на об'єкті: " + gameObject.name);
        }
    }
}
