using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTask : ScriptableObject
{
    public enum Type
    {
        Radar,
        Dialogue
    }
    public Type type;

    public int taskTime;

    public virtual void StartTask()
    {

    }
}
