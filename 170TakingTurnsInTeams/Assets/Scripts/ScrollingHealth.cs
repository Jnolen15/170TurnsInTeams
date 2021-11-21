using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingHealth : MonoBehaviour
{
    public int playerHealth = 150;
    public int max_health = 150;
    public int damage;
    public int heal;
    public bool healing = false;
    public bool takingDamage = false;
    public bool reachMaxHealth = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = Mathf.Clamp(playerHealth, 0, max_health);        
        if (Input.GetKeyDown(KeyCode.D))
        {
            damage = Random.Range(10, 50);
            Debug.Log("Damage: " + damage);
            healing = false;
            StartCoroutine(healthScrollingDown());
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            heal = Random.Range(10, 50);
            Debug.Log("Healing: " + heal);
            healing = true;
            //healing = true;
            StartCoroutine(healthScrollingUp());
        }
        Debug.Log("Player's Health: " + playerHealth);

    }

    IEnumerator healthScrollingDown()
    {
        if (playerHealth > 0)
        {
            int i = 0;
            while(i < damage && !healing)
            {
                
                yield return new WaitForSeconds(0.7f);
                playerHealth -= 1;
                if (healing || heal > damage)
                {
                    damage = 0;
                    break;
                }
                i++;
                
            }
            damage = 0;
        }
    }

    IEnumerator healthScrollingUp()
    {
        if (playerHealth > 0)
        {
            int i = 0;
            while(i < heal && playerHealth < max_health)
            {
                yield return new WaitForSeconds(0.7f);
                playerHealth += 1;
                if (playerHealth >= max_health || damage > heal)
                {
                    heal = 0;
                    break;

                }
                i++;

            }
            heal = 0;
        }
    }
}
