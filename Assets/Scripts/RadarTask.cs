using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Task", menuName = "Tasks/Radar")]
public class RadarTask : LevelTask
{
    public int radarCount;
    public int openCount;
    public override void StartTask()
    {
        GameManager.instance.MakeRadars(radarCount, openCount);
    }
}