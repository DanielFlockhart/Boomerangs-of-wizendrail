using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float health = 100f;
    public float speed = 2f;
    public float BulletSpeed = 350f;
    private float stoppingDistance = 0.5f;
    private float sightDistance = 10f;
    public float timeToFire = 1.5f;
    public Transform target;
    private float reloadTime=0;
    public GameObject fireball;
    public GameObject manager;
    public Rigidbody2D rb;

    void Start()
    {
        stoppingDistance += Random.Range(0.0f, 2.0f);
        target = GameObject.FindGameObjectWithTag("Ai").GetComponent<Transform>();
        manager = GameObject.FindGameObjectWithTag("GManger");
    }
    

    void Update()
    {
        //Vector2 lookdir = new Vector2(target.position.x,target.position.y) - rb.position;
        //float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg - 90f;
        //rb.rotation = angle;

        reloadTime += Time.deltaTime;
        move();
        if(reloadTime >= timeToFire)
        {
            reloadTime = 0;
            fire();
        }
        if (isDead())
        {
            Destroy(gameObject);
        }

    }
    void move()
    {
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance && Vector2.Distance(transform.position, target.position) < sightDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
    public void takeDamage(float damage)
    {
        health -= damage;
    }
    void fire()
    {
        manager.GetComponent<SoundScript>().fireballz();
        GameObject bullet = Instantiate(fireball, transform.position, Quaternion.identity);
        bullet.transform.parent = transform;

        Vector2 bulletdir = new Vector2(target.position.x,target.position.y) - rb.position;
        float angle = Mathf.Atan2(bulletdir.y, bulletdir.x) * Mathf.Rad2Deg - 90f;
        bullet.GetComponent<Rigidbody2D>().rotation = angle;
        bulletdir=bulletdir.normalized;
        bullet.GetComponent<Rigidbody2D>().AddForce(bulletdir * BulletSpeed);

    }
    bool isDead()
    {
        if(health <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
