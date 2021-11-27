using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    // Player Charecters
    public GameObject rouge;
    public GameObject mage;
    public GameObject knight;

    // Enemies
    public GameObject goblin;

    // Default Postions
    public GameObject defaultTop;
    public GameObject defaultMiddle;
    public GameObject defaultBottom;

    // Enemy positions
    public Transform[] enemyPositions;

    // Selected charecter
    public GameObject selectedCharacter;
    public GameObject selectedCharacterlocation;

    public GameState state;

    public enum GameState
    {
        charSelect,
        moveSelect,
        targetSelect,
        combat,
    }

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate enemies.
        for (int i = 0; i < enemyPositions.Length; i++)
        {
            GameObject enemy = Instantiate(goblin, enemyPositions[i].position, enemyPositions[i].rotation);
            enemyPositions[i].GetComponent<Position>().character = enemy;
            enemy.GetComponent<EnemyManager>().location = enemyPositions[i];
        }

        // Set PC to default positions
        defaultTop.GetComponent<Position>().asignPosition(rouge);
        defaultMiddle.GetComponent<Position>().asignPosition(mage);
        defaultBottom.GetComponent<Position>().asignPosition(knight);

        state = GameState.charSelect;
    }

    public void SelectChar(GameObject character)
    {
        if (selectedCharacter != null)
        {
            selectedCharacter.transform.localScale = Vector3.one;
        }
        selectedCharacter = character;
        character.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
        state = GameState.moveSelect;
    }

    public void UnselectChar()
    {
        if (selectedCharacter != null)
        {
            selectedCharacter.transform.localScale = Vector3.one;
            selectedCharacter = null;
        }
        state = GameState.charSelect;
    }

    public void HighlightTargets()
    {
        if (state != GameState.targetSelect) return;
        if (selectedCharacter == null)
        {
            return;
        }

        bool isNeutral = false;

        // If character is in neutral position, highlight all enemies
        if (defaultTop.transform.position == selectedCharacter.transform.position)
        {
            isNeutral = true;
        } 
        else if (defaultMiddle.transform.position == selectedCharacter.transform.position)
        {
            isNeutral = true;
        } 
        else if (defaultBottom.transform.position == selectedCharacter.transform.position)
        {
            isNeutral = true;
        }

        if (isNeutral)
        {
            // Highlight all enemies
            foreach (var enemyPos in enemyPositions)
            {
                if (enemyPos.GetComponent<Position>().character != null)
                {
                    enemyPos.GetComponent<Position>().character.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.6f, 1f, 0.6f);
                }
            }
        }
        else
        {
            GameObject target;

            // Check for valid North target
            target = selectedCharacter.GetComponent<PCManager>().NorthFlankCharacter;
            if (target != null)
            {
                target.GetComponent<SpriteRenderer>().color = new Color(0.6f, 1f, 0.6f);
            }
                
            // Check for valid East target
            target = selectedCharacter.GetComponent<PCManager>().EastFlankCharacter;
            if (target != null)
            {
                target.GetComponent<SpriteRenderer>().color = new Color(0.6f, 1f, 0.6f);
            }

            // Check for valid South target
            target = selectedCharacter.GetComponent<PCManager>().SouthFlankCharacter;
            if (target != null)
            {
                target.GetComponent<SpriteRenderer>().color = new Color(0.6f, 1f, 0.6f);
            }
                
            // Check for valid West target
            target = selectedCharacter.GetComponent<PCManager>().WestFlankCharacter;
            if (target != null)
            {
                target.GetComponent<SpriteRenderer>().color = new Color(0.6f, 1f, 0.6f);
            }
        }
    }

    public void UnhighlightTargets()
    {
        foreach (var enemyPos in enemyPositions)
        {
            if (enemyPos.GetComponent<Position>().character != null)
            {
                enemyPos.GetComponent<Position>().character.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        
    }

    public void ResetTurn()
    {
        if (rouge.activeInHierarchy)
        {
            rouge.GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (mage.activeInHierarchy)
        {
            mage.GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (knight.activeInHierarchy)
        {
            knight.GetComponent<SpriteRenderer>().color = Color.white;
        }
        state = GameState.charSelect;
    }


    // Update is called once per frame
    void Update()
    {
        //HighlightTargets();
    }
}
