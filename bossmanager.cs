using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bossmanager : MonoBehaviour
{
    private Animation anim;
    public GameObject King;
    private void Start()
    {
        GetComponent<Populate>().PopulateSquare(0, 0);
        anim = gameObject.GetComponent<Animation>();
        anim.Play("fade");
        
    }
    private void Update()
    {
        if(King.GetComponent<EnemyScript>().health <= 0)
        {
            SceneManager.LoadScene("End");
        }
    }
}
