using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float timeBetweenTasks;
    public List<LevelTask> levelTasks;

    int currentTaskIndex;
    float timeToNextTask;

    void Start()
    {
        instance = this;
        levelTasks[currentTaskIndex].StartTask();
        timeToNextTask = levelTasks[currentTaskIndex].taskTime + timeBetweenTasks;
    }

    void Update()
    {
        timeToNextTask -= Time.deltaTime;
        if(timeToNextTask< 0)
        {
            NextTask();
        }
    }

    public void NextTask()
    {
        currentTaskIndex++;
        if(currentTaskIndex >= levelTasks.Count)
        {
            //Level finished
            return;
        }
        levelTasks[currentTaskIndex].StartTask();
        timeToNextTask = levelTasks[currentTaskIndex].taskTime + timeBetweenTasks;
    }
}
