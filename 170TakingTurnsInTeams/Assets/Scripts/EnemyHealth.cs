using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 10;
    GameObject gameManagers;
    ScrollingHealth damage;
    void Start()
    {
        gameManagers = GameObject.Find("Game managers");
        damage = gameManagers.GetComponent<ScrollingHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        this.health = damage.enemyHealth;
        Debug.Log("Enemy = " + gameObject + " Health = " + this.health);
        if(this.health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
