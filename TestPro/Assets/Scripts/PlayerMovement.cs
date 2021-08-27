using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;
    public float movementSpeed = 5f;
    public Rigidbody2D rbody;
    public float boundPosY;
    public float boundNegY;
    Vector2 movement;

    void Update()
    {
        movement.y = Input.GetAxisRaw("Vertical");
        movement.x = Input.GetAxisRaw("Horizontal");

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);

        var pos = transform.position;
        if (pos.y > boundPosY)
        {
            pos.y = boundPosY;
        }
        else if (pos.y < boundNegY)
        {
            pos.y = boundNegY;
        }
        transform.position = pos;
    }

    void FixedUpdate()
    {
        rbody.MovePosition(rbody.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}