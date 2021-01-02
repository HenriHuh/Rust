using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    public Renderer rend;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag ==  "Player")
        {
            GameManager.instance.Hit();
            Color clr = Color.red;
            clr.a = rend.material.color.a;
            rend.material.color = clr;
        }
    }
}
