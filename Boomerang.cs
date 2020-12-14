using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    public GameObject boomerang;
    public Vector3 targPos;
    

    private bool moving = false;
    float speed = 350f;
    float acceleration = 1.05f;
    float power;
    private bool isHeld;
    Vector2 mousePos;
    bool canFire = true;
    private float timeToFire = 0.5f;
    private float reloadTime = 0;
    private void Start()
    {
    }
    void Update()
    {
        reloadTime += Time.deltaTime;
        if(canFire == true)
        {
            get_event();
        }
        
        addRot();
        if (isHeld)
        {
            power += Time.deltaTime*3;
        }
        if (reloadTime >= timeToFire)
        {
            canFire = true;
        } else
        {
            canFire = false;
        }

    }
    

void get_event()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isHeld = true;
            
            //targetLine.SetActive(true);
            
        }

        if (Input.GetMouseButtonUp(0))
        {
            //targetLine.SetActive(false);
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            reloadTime = 0;
            if (power >= 2.5)
            {
                power = 2.5f;
            }
            if(power <= 0)
            {
                power = 1f;
            }
            isHeld = false;
            GameObject bullet = Instantiate(boomerang, transform.position, Quaternion.identity);
            bullet.transform.parent = transform;
            //bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * (power) * speed);

            Vector2 bulletdir = mousePos - bullet.GetComponent<Rigidbody2D>().position;
            float angle = Mathf.Atan2(bulletdir.y, bulletdir.x) * Mathf.Rad2Deg - 90f;
            bullet.GetComponent<Rigidbody2D>().rotation = angle;
            bulletdir = bulletdir.normalized;
            bullet.GetComponent<Rigidbody2D>().AddForce(bulletdir * (power) * speed);


            power = 0;
        }
    }
    





    void addRot()
    {
        //GameObject[] booms = GameObject.FindGameObjectsWithTag("Boomerang");
        //foreach (GameObject boom in booms)
        //{

        //    if (boom.GetComponent<stats>().isRight == true)
        //    {
        //        boom.GetComponent<Rigidbody2D>().AddForce((transform.right * 5).normalized);
        //    }
        //    else
        //    {
        //        boom.GetComponent<Rigidbody2D>().AddForce((-transform.right * 5).normalized);

        //    }
        //}
    }


}
