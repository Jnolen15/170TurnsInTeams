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
    public int damageNum;
    public int healNum;
    public bool attackHappend = false;
    public Queue<Action> actionQueue;
    Attack currAttack;
    public GameObject currActor;
    public List<Character> activeAllies;

    void Start()
    {
        test.Init();
        nameText.enabled = false;
        actionQueue = new Queue<Action>();
        activeAllies = new List<Character>();
        activeAllies.Add(posManager.knight.GetComponent<Character>());
        activeAllies.Add(posManager.rouge.GetComponent<Character>());
        activeAllies.Add(posManager.mage.GetComponent<Character>());
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
        actionText.SetMoveDesc(chara.attacks);

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
        //Spend Mana
        currActor.GetComponent<Character>().mana -= currAttack.ManaPoints;
        // If its an attack on an enemy
        if (currAttack.Target == "Enemy")
        {
            damageNum = currAttack.Power;
            this.gameObject.GetComponent<ScrollingHealth>().enemiesGettingDamage(target, damageNum);
            currActor.GetComponent<Character>().hasAttacked = true;
            posManager.UnhighlightTargets();
            posManager.UnselectChar();
            posManager.state = PositionManager.GameState.charSelect;
            // If mana cost is 0 its a recahrge move. Gain mana
            if (currAttack.ManaPoints == 0)
                currActor.GetComponent<Character>().mana += damageNum;

            //calls function to make enemy attack the player character that just attacked them
            target.GetComponent<EnemyManager>().Attack(currActor);
            //posManager.checkIfPlayersWin();
        }
        // If its a healing on a player
        if (currAttack.Target == "Player" || currAttack.Target == "Self")
        {
            Debug.Log("Heal!");
            healNum = currAttack.Healing;
            this.gameObject.GetComponent<ScrollingHealth>().playersGettingHealing(target, healNum);
            currActor.GetComponent<Character>().hasAttacked = true;
            posManager.UnhighlightTargets();
            posManager.UnselectChar();
            posManager.state = PositionManager.GameState.charSelect;
        }

        currActor = null;
        currAttack = null;

        bool turnOver = true;
        foreach (Character ch in activeAllies)
        {
            if (ch == null)
            {
                activeAllies.Remove(ch);
                continue;
            }
            if (!ch.hasAttacked)
            {
                turnOver = false;
            }
        }


        if (turnOver)
        {
            posManager.ResetTurn();
        }
    }

}
