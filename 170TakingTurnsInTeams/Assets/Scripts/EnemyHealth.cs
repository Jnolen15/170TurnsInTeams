using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 10;
    public float healthScrollTimer = 1;
    private GameObject enemyHealthText;
    GameObject gameManagers;
    ScrollingHealth damage;
    void Start()
    {
        gameManagers = GameObject.Find("Game managers");
        //damage = gameManagers.GetComponent<ScrollingHealth>();
        enemyHealthText = gameObject.transform.Find("Canvas").gameObject;
        enemyHealthText.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "HP: " + health.ToString();
    }
    private void Update()
    {
        //enemyHealthText = gameObject.transform.Find("Canvas").gameObject;
        enemyHealthText.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "HP: " + health.ToString();
        //print(targetToAttack.GetComponent<EnemyHealth>().health);


        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void takingTheDamage(int damage)
    {
        StartCoroutine(healthScrollingDown(damage));
        
    }

    IEnumerator healthScrollingDown(int damage) {
        if (health > 0)
        {

            int i = 0;

            while (i < damage)
            {

                yield return new WaitForSeconds(healthScrollTimer);

                health -= 1;
                i++;


            }

            damage = 0;


        }
    }
    // Update is called once per frame


}
