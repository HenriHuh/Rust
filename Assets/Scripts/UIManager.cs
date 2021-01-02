using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public Text txtDialogue;
    public List<Button> optionButtons;
    public GameObject screenGameOver;
    public GameObject screenFinish;
    public string nextScene;
    public Text txtTimer;

    void Start()
    {
        instance = this;
        HideOptions();
    }

    void Update()
    {
        
    }

    public void Dialogue(string dialogue, List<DialogueOption> options)
    {
        txtDialogue.text = dialogue;
        for (int i = 0; i < options.Count; i++)
        {
            optionButtons[i].gameObject.SetActive(true);
            optionButtons[i].GetComponentInChildren<Text>().text = options[i].option;
            if (options[i].isCorrect)
            {
                optionButtons[i].onClick.AddListener(() => CorrectOption());
            }
            else
            {
                optionButtons[i].onClick.AddListener(() => IncorrectOption());
            }
        }
    }

    public void GameOver()
    {
        screenGameOver.SetActive(true);
    }

    public void LevelFinished()
    {
        screenFinish.SetActive(true);
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void CorrectOption()
    {
        txtDialogue.text = "Carry on then...";
        HideOptions();
        Invoke("HideDialogue", 1.5f);
        GameManager.instance.NextTask();
        SoundManager.instance.PlaySound(SoundManager.instance.click);
    }

    void IncorrectOption()
    {
        txtDialogue.text = "That is incorrect!";
        HideOptions();
        Invoke("HideDialogue", 1.5f);
        GameManager.instance.Hit();
        SoundManager.instance.PlaySound(SoundManager.instance.click);
    }

    void HideDialogue()
    {
        txtDialogue.text = "";
    }

    void HideOptions()
    {
        foreach (Button button in optionButtons)
        {
            button.gameObject.SetActive(false);
        }
    }
}
