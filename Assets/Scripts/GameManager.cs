using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float timeBetweenTasks;
    public List<LevelTask> levelTasks;
    public Transform cameraClosePosition, cameraFarPosition;
    public GameObject radarPrefab;
    public Animator migAnimator;
    public bool endless;
    
    LevelTask currentTask;
    int currentTaskIndex;
    float timeToNextTask;
    public int lives;
    bool invulnerable;
    float timer = 0;
    bool gameOver;
    void Start()
    {
        instance = this;
        timeToNextTask = timeBetweenTasks;
        if (SoundManager.soundOn) SoundManager.instance.motor.volume = 0.5f;
    }

    void Update()
    {
        if (gameOver)
        {
            return;
        }
        if (endless)
        {
            UIManager.instance.txtTimer.text = ((int)timer).ToString();
            timer += Time.deltaTime;
        }

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

    public void Hit()
    {
        if (invulnerable) return;

        if (lives <= 0)
        {
            UIManager.instance.GameOver();
            if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Level2")
            {
                SoundManager.instance.PlaySound(SoundManager.instance.splash);
            }
            else
            {
                SoundManager.instance.PlaySound(SoundManager.instance.crash);
            }
            gameOver = true;
        }
        else
        {
            migAnimator.SetTrigger("Flight");
            SoundManager.instance.PlaySound(SoundManager.instance.mig, 0.27f);
        }
        lives--;
        invulnerable = true;
        Invoke("Vulnerable", 1);
    }

    void Vulnerable()
    {
        invulnerable = false;
    }

    public void NextTask()
    {

        if(currentTask != null && currentTask.type == LevelTask.Type.Dialogue)
        {
            UIManager.instance.HideUI();
        }

        if(currentTaskIndex >= levelTasks.Count)
        {
            currentTask = null;
            UIManager.instance.LevelFinished();
            timeToNextTask = Mathf.Infinity;
            return;
        }
        levelTasks[currentTaskIndex].StartTask();
        timeToNextTask = levelTasks[currentTaskIndex].taskTime + timeBetweenTasks;
        currentTask = levelTasks[currentTaskIndex];
        if(!endless) currentTaskIndex++;
    }


    public void MakeRadars(int count, int openCount)
    {
        Vector3 radarPos = Vector3.zero;
        radarPos.y = 6;
        radarPos.z = PlayerController.instance.transform.position.z + 50;
        for (int i = 0; i < count; i++)
        {
            radarPos.z += 30;
            InitRadar(radarPos, openCount, 15 + (i * 10));
        }
    }

    void InitRadar(Vector3 pos, int openCount, float destroyTime)
    {
        List<Vector3> openPositions = Tools.GetGrid(1, 5);
        for (int i = 0; i < 9 - openCount; i++)
        {
            int gridPos = Random.Range(0, openPositions.Count);
            GameObject g = Instantiate(radarPrefab, pos + openPositions[gridPos], Quaternion.identity);
            openPositions.RemoveAt(gridPos);
            Destroy(g, destroyTime);
        }
    }
}
