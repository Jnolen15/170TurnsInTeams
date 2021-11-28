using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScrollingHealth : MonoBehaviour
{
    public int playerHealth = 150;
    private int enemyHealth = 10;
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
    GameObject targetText;

    private GameObject targetToAttack;
    private int damageAmount;
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

        //Once we find the target enemy change their health text to go with their scrolling health
        if (targetToAttack != null)
        {
            
            targetText = targetToAttack.transform.Find("Canvas").gameObject;
            targetText.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "HP: " + targetToAttack.GetComponent<EnemyHealth>().health.ToString();
            print(targetToAttack.GetComponent<EnemyHealth>().health);
            

            if (targetToAttack.GetComponent<EnemyHealth>().health <= 0)
            {
                Destroy(targetToAttack);
            }
        }
    }
    public void enemiesGettingDamage(GameObject target, int damage)
    {
        targetToAttack = target;

        healthdamage = damage;

        StartCoroutine(healthScrollingDown());
    }
    public IEnumerator healthScrollingDown()
    {

        if (enemyHealth > 0)
        {

            int i = 0;
            while (i < healthdamage && !healing)
            {

                yield return new WaitForSeconds(0.7f);

                targetToAttack.GetComponent<EnemyHealth>().health -= 1;
                //Debug.Log(enemyHealth);
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
            while (i < heal && playerHealth < max_health)
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
