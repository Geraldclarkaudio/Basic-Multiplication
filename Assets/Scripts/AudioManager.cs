using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("AudioManager is null");
            }

            return _instance;
        }
    }

    public AudioSource _audioSource;
    public AudioSource buttonAudioSource;
    public AudioClip dialogSound;
    public AudioClip endDialogSound;
    public AudioClip buttonHover;
    public AudioClip buttonClick;
    public AudioClip correctAnswer;
    public AudioClip wrongAnswer;
    public AudioClip addPoint;

    private void Awake()
    {
   
            _instance = this;
    
    }

    public void DialogSound()
    {
        _audioSource.clip = dialogSound;
        _audioSource.Play();
    }
    public void EndDialogSound()
    {
        _audioSource.clip = endDialogSound;
        _audioSource.Play();
    }
    public void ButtonHover()
    {
        buttonAudioSource.clip = buttonHover;
        buttonAudioSource.Play();
    }
    public void ButtonClicked()
    {
        buttonAudioSource.clip = buttonClick;
        buttonAudioSource.Play();
    }

    public void CorrectAnswer()
    {
        _audioSource.PlayOneShot(correctAnswer, 1);
    }
    public void WrongAnswer()
    {
        _audioSource.clip = wrongAnswer;
        _audioSource.Play();
    }
    public void AddPointSound()
    {
        _audioSource.clip = addPoint;
        _audioSource.Play();
    }
}
