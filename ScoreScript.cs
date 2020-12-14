using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text score;
    public GameManager manager;
    private void Update()
    {
        score.text = "Score : " + manager.loaded_chunks;
    }
}
