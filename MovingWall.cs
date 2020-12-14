using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    float topMost;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {

        //if (player.position.y > topMost)
        //{
            //topMost = player.position.y;
        //}  
        //transform.position = new Vector3(0, topMost + offset.y, 1);
    }
}
