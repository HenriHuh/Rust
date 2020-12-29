using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float timeBetweenTasks;
    public List<LevelTask> levelTasks;
    public Transform cameraClosePosition, cameraFarPosition;

    LevelTask currentTask;
    int currentTaskIndex;
    float timeToNextTask;

    void Start()
    {
        instance = this;
        timeToNextTask = timeBetweenTasks;
    }

    void Update()
    {
        timeToNextTask -= Time.deltaTime;
        if(timeToNextTask < 0)
        {
            NextTask();
        }

        PlayTask();
    }

    void PlayTask()
    {
        if (currentTask == null) return;

        switch (currentTask.type)
        {
            case LevelTask.Type.Radar:
                Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, cameraFarPosition.position, Time.deltaTime * 2.5f);
                Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, cameraFarPosition.rotation, Time.deltaTime * 2.5f);
                break;
            case LevelTask.Type.Dialogue:
                Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, cameraClosePosition.position, Time.deltaTime * 2.5f);
                Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, cameraClosePosition.rotation, Time.deltaTime * 2.5f);
                break;
            default:
                break;
        }
    }

    public void NextTask()
    {
        if(currentTaskIndex >= levelTasks.Count)
        {
            //Level finished
            return;
        }
        levelTasks[currentTaskIndex].StartTask();
        timeToNextTask = levelTasks[currentTaskIndex].taskTime + timeBetweenTasks;
        currentTask = levelTasks[currentTaskIndex];
        currentTaskIndex++;
    }
}
