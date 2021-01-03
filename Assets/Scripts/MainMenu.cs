using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Text soundOn;

    private void Start()
    {
        StartCoroutine(LateStart());
        SoundManager.instance.PlaySound(SoundManager.instance.startMusic);
        SoundManager.instance.motor.volume = 0;
    }

    IEnumerator LateStart()
    {
        yield return new WaitForEndOfFrame();
        ToggleSound();
        ToggleSound();
        yield return null;
    }

    public void StartGame()
    {
        SoundManager.instance.source.Stop();
        SoundManager.instance.PlaySound(SoundManager.instance.click);
        SceneManager.LoadScene("Level1");

    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Endless()
    {
        SceneManager.LoadScene("Endless");
    }

    public void ToggleSound()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.click);
        string ison = "";
        SoundManager.instance.SetSound(ref ison);
        soundOn.text = "Sound " + ison; 
    }
}
