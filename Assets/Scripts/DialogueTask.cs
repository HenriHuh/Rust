using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Task", menuName = "Tasks/Dialogue")]
public class DialogueTask : LevelTask
{
    public string dialogue;
    public List<DialogueOption> options;


    public override void StartTask()
    {
        //Start UIManager thing
    }
}

[System.Serializable]
public class DialogueOption
{
    public bool isCorrect;
    public string option;
}
