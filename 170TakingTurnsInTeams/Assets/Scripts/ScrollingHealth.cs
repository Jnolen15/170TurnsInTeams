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
    GameObject oldTarget;

    GameObject targetText;
    GameObject playertargetText;

    private GameObject targetToAttack;
    private GameObject playerToAttack;
    private Dictionary<GameObject, int> EnemiesHealth = new Dictionary<GameObject, int>();
    private Dictionary<GameObject, int> playersHealth = new Dictionary<GameObject, int>();
    private int damageAmount;
    public bool checker = false;
    IEnumerator inst = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Once we find the target enemy change their health text to go with their scrolling health
        /*
        if (EnemiesHealth != null)
        {
            foreach (KeyValuePair<GameObject, int> attachStat in EnemiesHealth)
            {
                //Now you can access the key and value both separately from this attachStat as:
                targetText = attachStat.Key.transform.Find("Canvas").gameObject;
                targetText.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "HP: " + attachStat.Key.GetComponent<EnemyHealth>().health.ToString();
                //print(targetToAttack.GetComponent<EnemyHealth>().health);


                if (attachStat.Key.GetComponent<EnemyHealth>().health <= 0)
                {
                    Destroy(attachStat.Key);
                }
                
            }
            
        }
        

        if (playersHealth != null)
        {

            //print("Player health" + playerToAttack.GetComponent<Character>().health.ToString());
            foreach (KeyValuePair<GameObject, int> player in playersHealth)
            {
                playertargetText = player.Key.transform.Find("Canvas").gameObject;
                playertargetText.transform.Find("Health").GetComponent<TextMeshProUGUI>().text = "HP: " + player.Key.GetComponent<Character>().health.ToString();


                if (player.Key.GetComponent<Character>().health <= 0)
                {
                    Destroy(player.Key);
                }
            }
            
        }
        */
    }
    public void enemiesGettingDamage(GameObject target, int damage)
    {
        checker = true;
        //targetToAttack = target;
        target.GetComponent<EnemyHealth>().takingTheDamage(damage);

        
    }

    public void playersGettingDamage(GameObject target, int damage)
    {
        //playerToAttack = target;
        target.GetComponent<Character>().playerTakingTheDamage(damage);
        //playerHealthdamage = damage;
        /*
        playersHealth.Add(target, damage);
        foreach (KeyValuePair<GameObject, int> player in playersHealth)
        {
            //Now you can access the key and value both separately from this attachStat as:
            
            StartCoroutine(playerHealthScrollingDown(player.Key, player.Value));
            
        }
        */

        
    }

    public void playersGettingHealing(GameObject target, int healing)
    {
        //playerToAttack = target;

        //heal = healing;
        target.GetComponent<Character>().playerHealingTheDamage(healing);
        //StartCoroutine(healthScrollingUp());
    }

    public IEnumerator healthScrollingDown(GameObject target, int damage)
    {
        
        if (target.GetComponent<EnemyHealth>().health > 0)
        {

            int i = 0;

            while (i < damage)
            {
                
                yield return new WaitForSeconds(healthScrollTimer);

                target.GetComponent<EnemyHealth>().health -= 1;
                i++;
                

            }
            
            damage = 0;
            
            
        }
    }

    public IEnumerator playerHealthScrollingDown(GameObject target, int damage)
    {

        if (target.GetComponent<Character>().health > 0)
        {

            int i = 0;
            while (i < damage && !healing)
            {

                yield return new WaitForSeconds(healthScrollTimer);

                target.GetComponent<Character>().health -= 1;
                //Debug.Log(enemyHealth);
                if (healing)
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
        if (playerToAttack.GetComponent<Character>().health > 0)
        {
            int i = 0;
            while (i < heal && playerToAttack.GetComponent<Character>().health < playerToAttack.GetComponent<Character>().max_health)
            {
                yield return new WaitForSeconds(healthScrollTimer);
                playerToAttack.GetComponent<Character>().health += 1;
                if (playerToAttack.GetComponent<Character>().health >= playerToAttack.GetComponent<Character>().max_health)
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
