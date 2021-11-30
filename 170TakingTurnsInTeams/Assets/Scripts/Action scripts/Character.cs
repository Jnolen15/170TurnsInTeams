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
    GameObject gameManagers;

    void Start()
    {
        health = max_health;
        mana = max_mana;
        playerHealthText = gameObject.transform.Find("Canvas").gameObject;
        playerHealthText.transform.Find("Health").GetComponent<TextMeshProUGUI>().text = "HP: " + health.ToString();
        playerManaText = gameObject.transform.Find("Canvas").gameObject;
        playerManaText.transform.Find("Mana").GetComponent<TextMeshProUGUI>().text = "HP: " + mana.ToString();
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
            this.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f);

        playerManaText.transform.Find("Mana").GetComponent<TextMeshProUGUI>().text = "HP: " + mana.ToString();
    }
}
