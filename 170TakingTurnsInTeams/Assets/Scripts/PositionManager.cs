using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    // Positions
    public Transform[] enemyPositions;

    // Selected charecter
    public GameObject selectedCharacter;
    public GameObject selectedCharacterlocation;

    public GameState state;
    public List<GameObject> enemies;

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
        // Hide position Indicators
        for(int i = 0; i < transform.childCount; i++)
        {
            if(this.transform.GetChild(i).gameObject.layer != 8) // Not an enemy position
            {
                this.transform.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().color = Color.blue;
                this.transform.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        
        // Instantiate enemies.
        for (int i = 0; i < enemyPositions.Length; i++)
        {
            if (i == 2)
            {
                GameObject boss = Instantiate(dog, enemyPositions[i].position, enemyPositions[i].rotation);
                enemyPositions[i].GetComponent<Position>().character = boss;
                enemies.Add(boss);
                boss.GetComponent<EnemyManager>().location = enemyPositions[i];
            }
            else
            {
                GameObject enemy = Instantiate(spider, enemyPositions[i].position, enemyPositions[i].rotation);
                enemyPositions[i].GetComponent<Position>().character = enemy;
                enemies.Add(enemy);
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
        // Highlight all Players if they are not dead
        if(rouge.gameObject.GetComponent<Character>().dead != true)
            rouge.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.6f, 1f, 0.6f);
        if (knight.gameObject.GetComponent<Character>().dead != true)
            knight.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.6f, 1f, 0.6f);
        if (mage.gameObject.GetComponent<Character>().dead != true)
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
            rouge.GetComponent<Character>().indicatorColor = "White";
        }
        if (mage.activeInHierarchy)
        {
            mage.GetComponent<SpriteRenderer>().color = Color.white;
            mage.GetComponent<Character>().indicatorColor = "White";
        }
        if (knight.activeInHierarchy)
        {
            knight.GetComponent<SpriteRenderer>().color = Color.white;
            knight.GetComponent<Character>().indicatorColor = "White";
        }
        knight.GetComponent<Character>().hasAttacked = false;
        rouge.GetComponent<Character>().hasAttacked = false;
        mage.GetComponent<Character>().hasAttacked = false;
        state = GameState.charSelect;
    }


    // Update is called once per frame
    void Update()
    {
        // Show position Indicators of available spaces
        if (selectedCharacter != null && state == GameState.moveSelect)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (this.transform.GetChild(i).gameObject.layer != 8) // Not an enemy position
                {
                    if(this.transform.GetChild(i).GetComponent<Position>().character == null)
                        this.transform.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
                }
            }
        }
        else
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (this.transform.GetChild(i).gameObject.layer != 8) // Not an enemy position
                {
                    this.transform.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                }
            }
        }
        if(rouge.GetComponent<Character>().dead && knight.GetComponent<Character>().dead && mage.GetComponent<Character>().dead){
            SceneManager.LoadScene("GameOver");
        }
    }
    public void checkIfPlayersWin(GameObject destroyObject){
        enemies.Remove(destroyObject);
        if(enemies.Count <= 0){
            print("Player wins!");
            SceneManager.LoadScene("Win");
        }
        Destroy(destroyObject);
    }
}
