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
    public GameObject spider;
    public GameObject dog;

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
            if (i == 2)
            {
                GameObject boss = Instantiate(dog, enemyPositions[i].position, enemyPositions[i].rotation);
                enemyPositions[i].GetComponent<Position>().character = boss;
                boss.GetComponent<EnemyManager>().location = enemyPositions[i];
            }
            else
            {
                GameObject enemy = Instantiate(spider, enemyPositions[i].position, enemyPositions[i].rotation);
                enemyPositions[i].GetComponent<Position>().character = enemy;
                enemy.GetComponent<EnemyManager>().location = enemyPositions[i];

            }
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
            selectedCharacter.GetComponent<SpriteRenderer>().size = Vector2.one;
        }
        selectedCharacter = character;
        character.GetComponent<SpriteRenderer>().size = new Vector2(10f, 10f);
        state = GameState.moveSelect;
    }

    public void UnselectChar()
    {
        if (selectedCharacter != null)
        {
            selectedCharacter.GetComponent<SpriteRenderer>().size = Vector2.one;
            selectedCharacter = null;
        }
        state = GameState.charSelect;
    }

    public void HighlightTargets(string pos)
    {
        if (state != GameState.targetSelect) return;
        if (selectedCharacter == null)
        {
            return;
        }

        // If location is Any, highlight all enemies
        if (pos == "A")
        {
            // Highlight all enemies
            GameObject ntarget = selectedCharacter.GetComponent<PCManager>().NorthFlankCharacter;
            GameObject etarget = selectedCharacter.GetComponent<PCManager>().EastFlankCharacter;
            GameObject starget = selectedCharacter.GetComponent<PCManager>().SouthFlankCharacter;
            GameObject wtarget = selectedCharacter.GetComponent<PCManager>().WestFlankCharacter;

            if (ntarget != null)
                ntarget.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.6f, 1f, 0.6f);
            if (etarget != null)
                etarget.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.6f, 1f, 0.6f);
            if (starget != null)
                starget.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.6f, 1f, 0.6f);
            if (wtarget != null)
                wtarget.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.6f, 1f, 0.6f);
        }
        // Else compare target position and higlight acordingly
        else
        {
            GameObject target;

            // Check for valid North target
            if(pos == "N")
            {
                target = selectedCharacter.GetComponent<PCManager>().NorthFlankCharacter;
                if (target != null)
                {
                    target.GetComponent<SpriteRenderer>().color = new Color(0.6f, 1f, 0.6f);
                }
            }

            // Check for valid East target
            if (pos == "E")
            {
                target = selectedCharacter.GetComponent<PCManager>().EastFlankCharacter;
                if (target != null)
                {
                    target.GetComponent<SpriteRenderer>().color = new Color(0.6f, 1f, 0.6f);
                }
            }

            // Check for valid South target
            if (pos == "S")
            {
                target = selectedCharacter.GetComponent<PCManager>().SouthFlankCharacter;
                if (target != null)
                {
                    target.GetComponent<SpriteRenderer>().color = new Color(0.6f, 1f, 0.6f);
                }
            }

            // Check for valid West target
            if (pos == "W")
            {
                target = selectedCharacter.GetComponent<PCManager>().WestFlankCharacter;
                if (target != null)
                {
                    target.GetComponent<SpriteRenderer>().color = new Color(0.6f, 1f, 0.6f);
                }
            }
        }
    }

    public void HighlightPlayers()
    {
        // Highlight all Players
        rouge.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.6f, 1f, 0.6f);
        knight.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.6f, 1f, 0.6f);
        mage.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.6f, 1f, 0.6f);
    }

    public void HighlightSelf(string player)
    {
        if (player == "Rouge")
            rouge.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.6f, 1f, 0.6f);
        if (player == "Knight")
            knight.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.6f, 1f, 0.6f);
        if (player == "Mage")
            mage.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.6f, 1f, 0.6f);
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
        rouge.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        knight.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        mage.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
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
