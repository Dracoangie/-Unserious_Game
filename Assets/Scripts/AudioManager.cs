using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip audioSelect;
    public AudioSource musicSource;
    public AudioSource audioSource;
    public float fadeDuration = 1.0f;
    public float maxVolume = 1.0f;
    public float minVolume = 0.0f;

    private void Start()
    {
        if (musicSource != null)
        {
            musicSource.volume = 0;
            StartCoroutine(FadeInMusic());
        }
    }

    private IEnumerator FadeInMusic()
    {
        float currentTime = 0;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            musicSource.volume = Mathf.Lerp(minVolume, maxVolume, currentTime / fadeDuration);
            yield return null;
        }

        musicSource.volume = maxVolume;
    }

    public void LowerMusic()
    {
        StartCoroutine(FadeOutMusic());
    }

    private IEnumerator FadeOutMusic()
    {
        float currentTime = 0;
        audioSource.PlayOneShot(audioSelect, 0.5f);
        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            musicSource.volume = Mathf.Lerp(maxVolume, minVolume, currentTime / fadeDuration);
            yield return null;
        }

        musicSource.volume = minVolume;
    }
}
