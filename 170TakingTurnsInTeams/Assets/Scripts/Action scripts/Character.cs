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
    public int health = 120;
    private GameObject playerHealthText;
    GameObject gameManagers;

    void Start()
    {
        playerHealthText = gameObject.transform.Find("Canvas").gameObject;
        playerHealthText.transform.Find("Health").GetComponent<TextMeshProUGUI>().text = "HP: " + health.ToString();
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
}
