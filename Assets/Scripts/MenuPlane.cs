using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlane : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 v = transform.position;
        v.y = Mathf.Sin(Time.time);
        transform.position = v;
        Quaternion rot = transform.rotation;
        rot.x = Mathf.Sin(Time.time * 0.7f) * 0.1f;
        transform.rotation = rot;
    }
}
