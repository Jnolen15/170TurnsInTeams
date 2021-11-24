using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ActionSelector : MonoBehaviour
{
    [SerializeField]
    List<Text> actionTexts;

    [SerializeField]
    BattleManager battleManager;
    
    private void Start() {
        foreach(var val in actionTexts){
            val.enabled = false;
        }
    }
    public void SetMoveNames(List<attackSelector> attacks)
    {
        for(int i = 0; i < actionTexts.Count; ++i)
        {
            actionTexts[i].enabled = true;
            if (i < attacks.Count)
            {
                actionTexts[i].text = attacks[i].Base.NameOfAttack;
            }
            else
            {
                actionTexts[i].text = "-";
            }
        }
    }

    public void SelectAction(int idx)
    {
        Attack attack = Resources.Load("Attacks/" + actionTexts[idx].text) as Attack;
        battleManager.AddActionToQueue(attack);
        //Debug.Log(attack);
    }
}
