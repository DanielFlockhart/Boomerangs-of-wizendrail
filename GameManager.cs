using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float loaded_chunks = 5;
    int goal = 25;
    public RawImage green;
    public GameObject bar;
    // Start is called before the first frame update
    void Start()
    {
        loaded_chunks = 5;
    }
    void Update() {
    
        if(loaded_chunks >= goal+5)
        {
            SceneManager.LoadScene("Boss");
        }
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene("GamePlay");
        }
    }
    void FixedUpdate()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Ai");
        float percent = loaded_chunks / goal;
        green.GetComponent<RectTransform>().sizeDelta = new Vector2(104 * percent * (104/goal), 12);
    }
}
