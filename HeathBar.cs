using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathBar : MonoBehaviour
{
    public RawImage green;
    public GameObject bar;
    // Update is called once per frame
    void FixedUpdate()
    {
        //bar.transform.position = transform.position + new Vector3(0,1f,0);
        GameObject player = GameObject.FindGameObjectWithTag("Ai");
        float percent = player.GetComponent<PlayerScript>().health / 100;
        green.GetComponent<RectTransform>().sizeDelta = new Vector2(104*percent, 12);
    }
}
