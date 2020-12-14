using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float moveSpeed = 4f;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    public GameObject manager;
    Vector2 mousePos;
    void Start()
    {

    }

    void Update()
    {
        ProcessInputs();
        //mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {

        Move();
        //Vector2 lookdir = mousePos - rb.position;
        //float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg - 90f;
        //rb.rotation = angle;
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        if(Input.GetAxisRaw("Vertical") != 0|| Input.GetAxisRaw("Horizontal")!=0)
        {
            manager.GetComponent<SoundScript>().Walking();
        }
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        if (GetComponent<PlayerScript>().speedy)
        {
            moveSpeed = 8f;
        } else
        {
            moveSpeed = 4f;
        }
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
