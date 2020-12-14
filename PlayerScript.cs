using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float health = 100f;
    public bool doubled = false;
    public bool speedy = false;
    float dubTime = 20f;
    float speedTime = 10f;
    public GameObject dubIndicator;
    public GameObject speedIndicator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead(health))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Menu");
        }
        dubTime -= Time.deltaTime;
        speedTime -= Time.deltaTime;
        if(dubTime <= 0)
        {
            doubled = false;
            dubTime = 60;
            dubIndicator.SetActive(false);
        }
        if (speedTime <= 0)
        {
            speedy = false;
            speedTime = 10;
            speedIndicator.SetActive(false);
        }
    }
    public void takeDamage(float damage)
    {
        health -= damage;
    }
    bool isDead(float Hlth)
    {
        if(Hlth <= 0)
        {
            return true;
        } else {
            return false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Health")
        {
            health += 50;
            if(health >= 100)
            {
                health = 100;
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "DoubleDamage")
        {
            doubled = true;
            dubIndicator.SetActive(true);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Speed")
        {
            speedy = true;
            speedIndicator.SetActive(true);
            Destroy(collision.gameObject);
        }
    }
}
