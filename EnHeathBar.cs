using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnHeathBar : MonoBehaviour
{
    public RawImage green;
    public GameObject king;
    public GameObject bar;
    // Update is called once per frame
    void Update()
    {
        float percent = GetComponent<EnemyScript>().health / 250;
        green.GetComponent<RectTransform>().sizeDelta = new Vector2(104 * percent, 12);
    }
}
