using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats : MonoBehaviour
{
    public bool isRight;
    public float alive = 0;
    public float rotSpeed = 40;
    public float dmg;
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Ai");
    }

    // Update is called once per frame
    void Update()
    {
        dmg = GetComponent<Rigidbody2D>().velocity.magnitude + 5;
        alive += Time.deltaTime;
        if(alive > 1)
        {
            Destroy(gameObject);
        }
        if(Player.GetComponent<PlayerScript>().doubled == true)
        {
            dmg = dmg * 2;
        }
        transform.Rotate(0, rotSpeed * Time.deltaTime, 0, Space.Self); //rotate
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyScript>().takeDamage(dmg);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
