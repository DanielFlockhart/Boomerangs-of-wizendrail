using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void infGame()
    {
        SceneManager.LoadScene("Infinite");
    }
}
