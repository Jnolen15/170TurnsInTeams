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
    GameObject canvas;
    private Text moveText;
    private Image moveImage;
    private IEnumerator inst = null;
    private void Start() {
        foreach(var val in actionTexts){
            val.enabled = false;
        }
        foreach (var val2 in descText)
        {
            val2.enabled = false;
        }
        moveText = GameObject.Find("enemyMoveText").GetComponent<Text>();
        moveImage = GameObject.Find("moveImage").GetComponent<Image>();
        moveImage.enabled = false;
        moveText.enabled = false;

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

        // Target Enemies if player has enough MP
        if (attack.ManaPoints <= battleManager.posManager.selectedCharacter.gameObject.GetComponent<Character>().mana)
        {
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
        else
        {
            inst = enableDisableManaText();
            Debug.Log("Not enough Mana!");
            if (moveImage.enabled == true)
            {
                StopCoroutine(inst);
            }
            StartCoroutine(inst);
            moveText.text = "No Mana";
        }
    }
    public IEnumerator enableDisableManaText()
    {
        moveImage.enabled = true;
        moveText.enabled = true;
        yield return new WaitForSeconds(3.0f);
        moveImage.enabled = false;
        moveText.enabled = false;
    }
}
