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
    public PositionManager posManager;
    [SerializeField]
    Text nameText;

    public static bool swap = false;
    public Queue<Action> actionQueue;
    Attack currAttack;
    GameObject currActor;

    void Start()
    {
        test.Init();
        nameText.enabled = false;
        actionQueue = new Queue<Action>();
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

    public void AddActionToQueue(Attack attack)
    {
        currActor = posManager.selectedCharacter;
        if (currActor == null)
        {
            Debug.Log("Null Actor Selection.");
            return;
        }
        
        if (attack == null)
        {
            Debug.Log("Null Attack Selection.");
            return;
        } 
        else
        {
            currAttack = attack;
            posManager.state = PositionManager.GameState.targetSelect;
        }
    }

    public void SetActionTarget(GameObject target)
    {
        actionQueue.Enqueue(new Action(currActor, target, currAttack));
        Debug.Log(currActor + " used " + currAttack + " on " + target + ", Action Queue Length: " + actionQueue.Count);
        currActor.GetComponent<Character>().hasAttacked = true;
        currActor.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f);
        posManager.UnhighlightTargets();
        posManager.UnselectChar();
        posManager.state = PositionManager.GameState.charSelect;
        currActor = null;
        currAttack = null;
    }

}
