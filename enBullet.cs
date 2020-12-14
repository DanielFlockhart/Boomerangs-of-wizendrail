using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enBullet : MonoBehaviour
{
    float dmg = 5;
    float timeAlive;

    void Update()
    {
        timeAlive += Time.deltaTime;
        if (timeAlive > 2)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ai")
        {
            collision.gameObject.GetComponent<PlayerScript>().takeDamage(dmg);
            Destroy(gameObject);
        }
    }
}
