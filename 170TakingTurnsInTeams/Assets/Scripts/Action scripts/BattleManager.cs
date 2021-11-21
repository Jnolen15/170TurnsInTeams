using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*   This script will be used to manage all the battle system
*       For example, we will want to update moves more than just when
*       a character switches or at the start of a battle
*/
public class BattleManager : MonoBehaviour
{
    [SerializeField]
    ActionSelector actionText;
    void Start()
    {
        
    }
    private void Update() {
        
        //have someway of storing what the last placed hero piece was
        //that goes into the parameters (has to be of type Character)
        //characterSwap(Position.charReference);
    }
    void characterSwap(Character chara){
        actionText.SetMoveNames(chara.attacks);
    }
}
