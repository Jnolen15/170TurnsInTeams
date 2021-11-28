using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingHealth : MonoBehaviour
{
    public int playerHealth = 150;
    public int enemyHealth = 10;
    public int max_health = 150;
    public int healthdamage;
    public int heal;
    public bool healing = false;
    public bool takingDamage = false;
    public bool reachMaxHealth = false;
    public BattleManager damage;
    private bool attackHasHappen = false;
    public GameObject[] listOfPlayers;
    public GameObject[] listOfEnemies;
    GameObject newCurrentCharacter;

    // Start is called before the first frame update
    void Start()
    {
        //damage = GetComponent<BattleManager>();
        listOfPlayers = GameObject.FindGameObjectsWithTag("PlayerCharacter");
        listOfEnemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        listOfEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        BattleManager currentCharacter = GetComponent<BattleManager>();
        
        /*
        int i = 0;
        foreach(var e in listOfEnemies){
            print("I: " + i + " " + e.transform.position.y);
            i++;
        }
        */

        //healthdamage = currentCharacter.damageNum;
        if (currentCharacter.currActor != null)
        {
            //Debug.Log("Health Damage = " + currentCharacter.currActor);
            newCurrentCharacter = currentCharacter.currActor;


        }
        //Debug.Log("Current Character" + newCurrentCharacter);
        if (newCurrentCharacter != null)
        {
            if (newCurrentCharacter.GetComponent<Character>().hasAttacked && !attackHasHappen)
            {
                //damage = Random.Range(10, 50);
                healthdamage = currentCharacter.damageNum;
                //Debug.Log("Damage: " + healthdamage);
                healing = false;
                attackHasHappen = true;
                StartCoroutine(healthScrollingDown());
            }
            if (!newCurrentCharacter.GetComponent<Character>().hasAttacked)
            {
                attackHasHappen = false;
            }


        }
        //enemiesGettingDamage(listOfEnemies);

    }
    /*
    public void enemiesGettingDamage(GameObject[] enemies)
    {
        //Debug.Log("are we entering the functrion");
        GameObject tempEnemy = null;
        foreach(GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyHealth>().health = enemyHealth;
            //Debug.Log("Health: " + enemy.GetComponent<EnemyHealth>().health);
            if(enemy.GetComponent<EnemyHealth>().health <= 0)
            {
                
            }

        }
        
    }
    */
    public void enemiesGettingDamage(GameObject target)
    {
        print(target.transform.position.y);
        //Debug.Log("are we entering the functrion");
        target.GetComponent<EnemyHealth>().health = enemyHealth;
            //Debug.Log("Health: " + enemy.GetComponent<EnemyHealth>().health);
        if(target.GetComponent<EnemyHealth>().health <= 0)
        {
            Destroy(target);
        }
    }
    IEnumerator healthScrollingDown()
    {
        if (enemyHealth > 0)
        {
            int i = 0;
            while(i < healthdamage && !healing)
            {
                
                yield return new WaitForSeconds(0.7f);
                enemyHealth -= 1;
                if (healing || heal > healthdamage)
                {
                    healthdamage = 0;
                    break;
                }
                i++;
                
            }
            healthdamage = 0;
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
                if (playerHealth >= max_health || healthdamage > heal)
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
