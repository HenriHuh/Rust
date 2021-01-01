using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform player;
    public float moveSpeed;
    public int horizontalLimit;

    float targetRotation;
    float verticalVelocity;

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

        //Height

        if(transform.position.y > 2f)
        {
            verticalVelocity -= Time.deltaTime * 15;
        }
        else if (verticalVelocity < 0 && transform.position.y <= 0.5f)
        {
            verticalVelocity = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space) && verticalVelocity < 5f)
        {
            verticalVelocity = 10f;
        }
        float newPos = verticalVelocity * Time.deltaTime + transform.position.y;
        if (newPos < 10 && newPos > 2)
        {
            transform.Translate(Vector3.up * verticalVelocity * Time.deltaTime);
        }

        //Rotation
        Quaternion rot = Quaternion.identity;
        float prevRotation = targetRotation;
        targetRotation = Mathf.MoveTowards(prevRotation, (Input.GetAxisRaw("Horizontal") * -0.15f), Time.deltaTime / 2);
        targetRotation = Mathf.MoveTowards(prevRotation, (Mathf.Abs(pos.x) >= horizontalLimit ? 0 : targetRotation), Time.deltaTime / 2);
        rot.z = targetRotation;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, Time.deltaTime * 50);

    }
}
