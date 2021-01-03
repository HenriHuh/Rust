using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public static bool soundOn = true;
    AudioSource source;
    public AudioSource motor;


    public AudioClip startMusic, crash, splash, failMusic, mig, win, click;


    private void Start()
    {
        if (instance ==  null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            source = gameObject.GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void PlaySound(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }

    public void SetSound(ref string onString)
    {
        soundOn = !soundOn;
        source.volume = soundOn ? 1 : 0;
        onString = soundOn ? "ON" : "OFF";
    }
}
