using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvTiling : MonoBehaviour
{
    List<GameObject> children = new List<GameObject>();
    public float tileSize;

    void Start()
    {
        foreach (Transform t in transform)
        {
            children.Add(t.gameObject);
        }
    }

    void Update()
    {
        if (children[0].transform.position.z < PlayerController.instance.transform.position.z - tileSize)
        {
            children[0].transform.Translate(Vector3.forward * tileSize * children.Count);
            GameObject child = children[0];
            children.RemoveAt(0);
            children.Add(child);
        }
    }
}
