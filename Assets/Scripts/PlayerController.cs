using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform player;
    public float moveSpeed;
    public int horizontalLimit;

    float targetRotation;

    public static PlayerController instance;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        player.Translate(Vector3.forward * Time.deltaTime * 14);
        GetInput();
    }

    void GetInput()
    {
        //Position
        Vector3 pos = transform.position;
        pos.x += Time.deltaTime * Input.GetAxis("Horizontal") * moveSpeed;
        pos.x = Mathf.Abs(pos.x) > horizontalLimit ? Mathf.Sign(pos.x) * horizontalLimit : pos.x;
        transform.position = pos;


        //Rotation
        Quaternion rot = Quaternion.identity;
        float prevRotation = targetRotation;
        targetRotation = Mathf.MoveTowards(prevRotation, (Input.GetAxisRaw("Horizontal") * -0.15f), Time.deltaTime / 2);
        targetRotation = Mathf.MoveTowards(prevRotation, (Mathf.Abs(pos.x) >= horizontalLimit ? 0 : targetRotation), Time.deltaTime / 2);
        rot.z = targetRotation;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, Time.deltaTime * 50);

    }
}
