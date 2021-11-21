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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
