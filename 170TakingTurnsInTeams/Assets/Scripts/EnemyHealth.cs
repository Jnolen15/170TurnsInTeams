using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 10;
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

    // Update is called once per frame
    

}
