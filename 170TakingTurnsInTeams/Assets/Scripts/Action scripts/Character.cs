using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Character : MonoBehaviour
{
    [SerializeField]
    baseCharacter _base;

    public bool hasAttacked = false;
    public int max_health = 120;
    public int health;
    public int max_mana = 60;
    public int mana;
    private GameObject playerHealthText;
    private GameObject playerManaText;
    private GameObject indicator;
    public string indicatorColor = "White";
    GameObject gameManagers;

    void Start()
    {
        indicator = this.transform.GetChild(1).gameObject;
        indicator.GetComponent<SpriteRenderer>().color = Color.white;

        health = max_health;
        mana = max_mana;
        playerHealthText = gameObject.transform.Find("Canvas").gameObject;
        playerHealthText.transform.Find("Health").GetComponent<TextMeshProUGUI>().text = "HP: " + health.ToString();
        playerManaText = gameObject.transform.Find("Canvas").gameObject;
        playerManaText.transform.Find("Mana").GetComponent<TextMeshProUGUI>().text = "MP: " + mana.ToString();
    }
    public baseCharacter baseChar{
        get{return _base; }
    }
    public List<attackSelector> attacks{get; set;}
    public void Init(){
        attacks = new List<attackSelector>();
        foreach(var move in baseChar.PotentialMoves)     //loops through each move and adds the learnable ones
        {
            attacks.Add(new attackSelector(move.Base));
            if(attacks.Count >= 4)
            {
                break;
            }
        }
    }

    public void Update()
    {
        if(hasAttacked)
            indicatorColor = "Red";

        playerManaText.transform.Find("Mana").GetComponent<TextMeshProUGUI>().text = "MP: " + mana.ToString();

        if(indicatorColor == "White")
            indicator.GetComponent<SpriteRenderer>().color = Color.white;
        if (indicatorColor == "Green")
            indicator.GetComponent<SpriteRenderer>().color = Color.green;
        if (indicatorColor == "Red")
            indicator.GetComponent<SpriteRenderer>().color = Color.red;
    }
}
