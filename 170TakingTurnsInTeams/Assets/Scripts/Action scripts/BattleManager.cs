using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
*   This script will be used to manage all the battle system
*       For example, we will want to update moves more than just when
*       a character switches or at the start of a battle
*/
public class BattleManager : MonoBehaviour
{
    [SerializeField]
    ActionSelector actionText;
    [SerializeField]
    Character test;
    
    [SerializeField]
    Text nameText;
    public static bool swap = false;
    void Start()
    {
        test.Init();
        nameText.enabled = false;
    }
    private void Update() {
        
        //have someway of storing what the last placed hero piece was
        //that goes into the parameters (has to be of type Character)
        if(Position.charReference != null && swap){
            test = Position.charReference.GetComponent<Character>();   
            test.Init();
            nameText.enabled = true;    //change where we do this later
            nameText.text = Position.charReference.name;
            characterSwap(Position.charReference.GetComponent<Character>());
            swap = false;
        }
        
    }
    void characterSwap(Character chara){
        //print(chara);
        //print(chara.baseChar.PotentialMoves);
        actionText.SetMoveNames(chara.attacks);
    }
}
