using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public int horizontalLimit;


    void Start()
    {
        
    }

    void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        Quaternion rot = Quaternion.identity;
        rot.z = Input.GetAxis("Horizontal") * -0.15f;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, Time.deltaTime * 50);

        Vector3 pos = transform.position;
        pos.x += Time.deltaTime * Input.GetAxis("Horizontal") * moveSpeed;
        pos.x = Mathf.Abs(pos.x) > horizontalLimit ? Mathf.Sign(pos.x) * horizontalLimit : pos.x;
        transform.position = pos;
    }
}
