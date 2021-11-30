using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ActionSelector : MonoBehaviour
{
    [SerializeField]
    List<Text> actionTexts;

    [SerializeField]
    List<Text> descText;

    [SerializeField]
    BattleManager battleManager;
    
    private void Start() {
        foreach(var val in actionTexts){
            val.enabled = false;
        }
        foreach (var val2 in descText)
        {
            val2.enabled = false;
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

    public void SetMoveDesc(List<attackSelector> attacks)
    {
        Debug.Log(descText.Count);
        for (int i = 0; i < descText.Count; ++i)
        {
            descText[i].enabled = true;
            if (i < attacks.Count)
            {
                descText[i].text = attacks[i].Base.Desc;
            }
            else
            {
                descText[i].text = "-";
            }
        }
    }

    public void SelectAction(int idx)
    {
        if (battleManager.posManager.state != PositionManager.GameState.moveSelect)
        {
            if (battleManager.posManager.state != PositionManager.GameState.targetSelect)
            {
                Debug.Log("Aborted. In state: " + battleManager.posManager.state);
                return;
            }
        }

        battleManager.posManager.UnhighlightTargets();
        Attack attack = Resources.Load("Attacks/" + actionTexts[idx].text) as Attack;

        // Target Enemies
        if (attack.Target == "Enemy")
        {
            battleManager.AddActionToQueue(attack);
            battleManager.posManager.HighlightTargets(attack.Location);
            Debug.Log("Picked" + attack.name);
        }
        // Target Players
        if (attack.Target == "Player")
        {
            battleManager.AddActionToQueue(attack);
            battleManager.posManager.HighlightPlayers();
            Debug.Log("Picked" + attack.name);
        }
        // Target Players
        if (attack.Target == "Self")
        {
            battleManager.AddActionToQueue(attack);
            battleManager.posManager.HighlightSelf(battleManager.posManager.selectedCharacter.name);
            Debug.Log("Picked" + attack.name);
        }
    }
}
