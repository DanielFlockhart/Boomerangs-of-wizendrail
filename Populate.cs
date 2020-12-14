using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Populate : MonoBehaviour
{
    [SerializeField] int healthChance = 4;
    [SerializeField] int boostChance = 3;
    [SerializeField] int enemyChance = 6;
    [SerializeField] int maxEnemies = 2;
    public GameObject Enemy;
    public GameObject Enemy2;
    public GameObject HealthPack;
    public GameObject BoostPack;
    public GameObject SpeedPack;
    
    public void PopulateSquare(float xlim,float ylim)
    {
        if (Random.Range(0, 11) < enemyChance)
        {
            float xPos = xlim - Random.Range(-4, 5);
            float yPos = ylim - Random.Range(-4, 5);
            if (Random.Range(0, 2) == 0)
            {
                GameObject enemy = Instantiate(Enemy);
                enemy.transform.position = new Vector2(xPos, yPos);
            } else
            {
                GameObject enemy = Instantiate(Enemy2);
                enemy.transform.position = new Vector2(xPos, yPos);
            }
        } 
        if(Random.Range(0, 11) < healthChance)
        {
            float xPos = xlim - Random.Range(-4, 5);
            float yPos = ylim - Random.Range(-4, 5);
            GameObject pack = Instantiate(HealthPack);
            pack.transform.position = new Vector2(xPos, yPos);
        }
        if (Random.Range(0, 11) < boostChance)
        {
            float xPos = xlim - Random.Range(-4, 5);
            float yPos = ylim - Random.Range(-4, 5);
            if(Random.Range(0,2) == 0)
            {
                GameObject boost = Instantiate(BoostPack);
                boost.transform.position = new Vector2(xPos, yPos);
            } else
            {
                GameObject boost = Instantiate(SpeedPack);
                boost.transform.position = new Vector2(xPos, yPos);
            }
           
        }
    }

}
