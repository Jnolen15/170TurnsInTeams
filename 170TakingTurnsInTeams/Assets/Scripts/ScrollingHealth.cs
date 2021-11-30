using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScrollingHealth : MonoBehaviour
{
    public int playerHealth = 150;
    private int enemyHealth = 10;
    public int max_health = 150;
    public float healthScrollTimer = 0.7f;
    public int healthdamage = 0;
    public int playerHealthdamage = 0;
    public int heal;
    public bool healing = false;
    public bool takingDamage = false;
    public bool reachMaxHealth = false;
    public BattleManager damage;
    
    GameObject targetText;
    GameObject playertargetText;

    private GameObject targetToAttack;
    private GameObject playerToAttack;
    private int damageAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Once we find the target enemy change their health text to go with their scrolling health
        if (targetToAttack != null)
        {
            
            targetText = targetToAttack.transform.Find("Canvas").gameObject;
            targetText.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "HP: " + targetToAttack.GetComponent<EnemyHealth>().health.ToString();
            //print(targetToAttack.GetComponent<EnemyHealth>().health);
            

            if (targetToAttack.GetComponent<EnemyHealth>().health <= 0)
            {
                Destroy(targetToAttack);
            }
        }
        if (playerToAttack != null)
        {

            //print("Player health" + playerToAttack.GetComponent<Character>().health.ToString());
            playertargetText = playerToAttack.transform.Find("Canvas").gameObject;
            playertargetText.transform.Find("Health").GetComponent<TextMeshProUGUI>().text = "HP: " + playerToAttack.GetComponent<Character>().health.ToString();


            if (playerToAttack.GetComponent<Character>().health <= 0)
            {
                Destroy(playerToAttack);
            }
        }
    }
    public void enemiesGettingDamage(GameObject target, int damage)
    {
        targetToAttack = target;

        healthdamage = damage;

        StartCoroutine(healthScrollingDown());
    }

    public void playersGettingDamage(GameObject target, int damage)
    {
        playerToAttack = target;

        playerHealthdamage = damage;

        StartCoroutine(playerHealthScrollingDown());
    }

    public void playersGettingHealing(GameObject target, int healing)
    {
        playerToAttack = target;

        heal = healing;

        StartCoroutine(healthScrollingUp());
    }

    public IEnumerator healthScrollingDown()
    {

        if (enemyHealth > 0)
        {

            int i = 0;
            while (i < healthdamage)
            {

                yield return new WaitForSeconds(healthScrollTimer);

                targetToAttack.GetComponent<EnemyHealth>().health -= 1;
                i++;

            }
            healthdamage = 0;
        }
    }

    public IEnumerator playerHealthScrollingDown()
    {

        if (playerToAttack.GetComponent<Character>().health > 0)
        {

            int i = 0;
            while (i < playerHealthdamage && !healing)
            {

                yield return new WaitForSeconds(healthScrollTimer);

                playerToAttack.GetComponent<Character>().health -= 1;
                //Debug.Log(enemyHealth);
                if (healing || heal > playerHealthdamage)
                {
                    playerHealthdamage = 0;
                    break;
                }
                i++;

            }
            playerHealthdamage = 0;
        }
    }

    IEnumerator healthScrollingUp()
    {
        if (playerToAttack.GetComponent<Character>().health > 0)
        {
            int i = 0;
            while (i < heal && playerToAttack.GetComponent<Character>().health < playerToAttack.GetComponent<Character>().max_health)
            {
                yield return new WaitForSeconds(healthScrollTimer);
                playerToAttack.GetComponent<Character>().health += 1;
                if (playerToAttack.GetComponent<Character>().health >= playerToAttack.GetComponent<Character>().max_health || playerHealthdamage > heal)
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
