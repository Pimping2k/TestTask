using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] AudioSource audioSource;

    private void Start()
    {
        slider.value = 0.05f;
    }
    void Update()
    {
        audioSource.volume = slider.value;
    }
}
