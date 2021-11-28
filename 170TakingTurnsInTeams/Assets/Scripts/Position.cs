using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    //will change from static later, just want to test this
    public static GameObject charReference;
    public static GameObject enemyRef;
    public GameObject character;
    public bool occupied;
    public PositionManager pm;
    public BattleManager bm;
    [SerializeField] float scale = 1.25f;

    private void Start()
    {
        pm = GameObject.FindGameObjectWithTag("PositionManager").GetComponent<PositionManager>();
        bm = FindObjectOfType<BattleManager>();
    }

    void Update()
    {
        // If a charecter is assinged to this postion change bool
        if (character == null)
            occupied = false;
        else
            occupied = true;
    }

    public void asignPosition(GameObject chara)
    {
        // Set charecter to this position
        character = chara;
        character.transform.position = this.transform.position;
        // Assign character's position
        character.GetComponent<PCManager>().location = this.transform;
        
    }

    public void unasignPosition()
    {
        // Set charecter to this position
        character = null;
    }

    private void OnMouseDown()
    {
        // If the player has not selected a character
        if (pm.selectedCharacter == null)
        {
            if (character == null)
                Debug.Log("Nothing here!");
            else
            {
                if (character.tag == "PlayerCharacter")
                {
                    //Debug.Log("Clicked on: " + character.name);
                    if (!character.GetComponent<Character>().hasAttacked)
                    {
                        pm.SelectChar(character);
                        charReference = character;
                        BattleManager.swap = true;
                        //print("CHARACTER: " + charReference.name);
                        pm.selectedCharacterlocation = this.gameObject;
                    }
                }
                else if (character.tag == "Enemy")
                {
                    Debug.Log("Clicked on: " + character.name);
                    Debug.Log("Cannot select an enemy!");
                }
            }
        }
        // IF the player has selected a character
        else
        {
            if (character == null)
            {
                // Characters can't move once they've already selected an attack
                if (pm.selectedCharacter.GetComponent<Character>().hasAttacked)
                {
                    return;
                }
                
                // Check if empty space is clicked during attack target selection
                if (pm.state == PositionManager.GameState.targetSelect)
                {
                    pm.UnhighlightTargets();
                    pm.UnselectChar();
                    pm.state = PositionManager.GameState.charSelect;
                    return;
                }
                Debug.Log("Moving " + pm.selectedCharacter.name + " to " + this.gameObject.name);
                // Unasign old pos
                pm.selectedCharacterlocation.GetComponent<Position>().unasignPosition();
                // Asign new pos
                asignPosition(pm.selectedCharacter);
                // Unselect character
                pm.selectedCharacter.transform.localScale = Vector3.one;
                pm.selectedCharacter = null;
                pm.selectedCharacterlocation = null;
            }
            else
            {
                if (character.tag == "PlayerCharacter")
                {
                    Debug.Log("Clicked on: " + character.name);
                    if (pm.state == PositionManager.GameState.targetSelect)
                    {
                        pm.UnhighlightTargets();
                        pm.state = PositionManager.GameState.charSelect;
                        return;
                    }
                    if (!character.GetComponent<Character>().hasAttacked)
                    {
                        pm.SelectChar(character);
                        charReference = character;
                        BattleManager.swap = true;
                        pm.selectedCharacterlocation = this.gameObject;
                    }
                }
                else if (character.tag == "Enemy")
                {
                    if (pm.state == PositionManager.GameState.targetSelect)
                    {
                        // Lazy way of checking for valid target
                        if (character.GetComponent<SpriteRenderer>().color != Color.white)
                        {
                            bm.SetActionTarget(character);
                        }
                    } else
                    {
                        Debug.Log("Cannot move to an enemy occupied space!");
                    }
                }
            }
        }
        
    }
}
