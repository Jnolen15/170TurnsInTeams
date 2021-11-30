using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Enemy type
    public enum classeTypes
    {
        Spider, Dog
    };
    public classeTypes classtype;

    // Public Variables
    public LayerMask positions;
    
    public Transform location;

    public GameObject NorthFlankCharacter;
    public GameObject EastFlankCharacter;
    public GameObject SouthFlankCharacter;
    public GameObject WestFlankCharacter;

    // Private Variables
    private GameObject NorthFlank;
    private GameObject EastFlank;
    private GameObject SouthFlank;
    private GameObject WestFlank;
    private GameObject gameManagers;
    BattleManager battleManager;
    Attack attack;

    // Start is called before the first frame update
    void Start()
    {
        gameManagers = GameObject.Find("Game managers");
        Vector3 buffer = new Vector3(0, 1, 0);

        RaycastHit2D hit = Physics2D.Raycast(location.transform.position + buffer, Vector2.up, 4, positions);
        if (hit.collider != null)
            NorthFlank = hit.collider.gameObject;

        hit = Physics2D.Raycast(location.transform.position + buffer, Vector2.right, 4, positions);
        if (hit.collider != null)
            EastFlank = hit.collider.gameObject;

        hit = Physics2D.Raycast(location.transform.position + buffer, -Vector2.up, 4, positions);
        if (hit.collider != null)
            SouthFlank = hit.collider.gameObject;

        hit = Physics2D.Raycast(location.transform.position + buffer, -Vector2.right, 4, positions);
        if (hit.collider != null)
            WestFlank = hit.collider.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        NorthFlankCharacter = NorthFlank.GetComponent<Position>().character;
        EastFlankCharacter = EastFlank.GetComponent<Position>().character;
        SouthFlankCharacter = SouthFlank.GetComponent<Position>().character;
        WestFlankCharacter = WestFlank.GetComponent<Position>().character;
    }

    //this is called in the battlemanager script
    //  There definitly is a better way to organize this, but I wanted to get something
    //  running quickly, may be worth going back later and cleaning up
    public void Attack(GameObject target){
        //Unity docs says its inclusive, but it doesn't seem like it is
        //   if this causes errors, just change 4 to 3
        int rando = Random.Range(0,4);  
        //split up based on position so that the enemy has access to different moves based
        //  on where the player is
        if(NorthFlankCharacter == target){
            //the player that just attacked the enemy is in the north position (above enemy)
            print("NORTH");
            
            switch(rando){
                case 3:
                    //print("first move");
                    attack = Resources.Load("Attacks/" + "RandomAttack1") as Attack;
                    
                    Debug.Log(attack);
                    break;
                case 2:
                    //print("second move");
                    attack = Resources.Load("Attacks/" + "RandomAttack1") as Attack;
                    
                    Debug.Log(attack);
                    break;
                case 1:
                    //print("third move");
                    attack = Resources.Load("Attacks/" + "RandomAttack1") as Attack;

                    Debug.Log(attack);
                    break;
                case 0:
                    //print("fourth move");
                    attack = Resources.Load("Attacks/" + "RandomAttack1") as Attack;

                    Debug.Log(attack);
                    break;  
            }
            gameManagers.GetComponent<ScrollingHealth>().playersGettingDamage(target, attack.Power);
        }
        if(SouthFlankCharacter == target){
            //the player that just attacked the enemy is in the south position (below enemy)
            print("SOUTH");

            switch (rando)
            {
                case 3:
                    //print("first move");
                    attack = Resources.Load("Attacks/" + "RandomAttack1") as Attack;

                    Debug.Log(attack);
                    break;
                case 2:
                    //print("second move");
                    attack = Resources.Load("Attacks/" + "RandomAttack1") as Attack;

                    Debug.Log(attack);
                    break;
                case 1:
                    //print("third move");
                    attack = Resources.Load("Attacks/" + "RandomAttack1") as Attack;

                    Debug.Log(attack);
                    break;
                case 0:
                    //print("fourth move");
                    attack = Resources.Load("Attacks/" + "RandomAttack1") as Attack;

                    Debug.Log(attack);
                    break;
            }
            gameManagers.GetComponent<ScrollingHealth>().playersGettingDamage(target, attack.Power);
        }
        if(EastFlankCharacter == target){
            //the player that just attacked the enemy is in the east position (right of enemy)
            print("EAST");

            switch (rando)
            {
                case 3:
                    //print("first move");
                    attack = Resources.Load("Attacks/" + "RandomAttack1") as Attack;

                    Debug.Log(attack);
                    break;
                case 2:
                    //print("second move");
                    attack = Resources.Load("Attacks/" + "RandomAttack1") as Attack;

                    Debug.Log(attack);
                    break;
                case 1:
                    //print("third move");
                    attack = Resources.Load("Attacks/" + "RandomAttack1") as Attack;

                    Debug.Log(attack);
                    break;
                case 0:
                    //print("fourth move");
                    attack = Resources.Load("Attacks/" + "RandomAttack1") as Attack;

                    Debug.Log(attack);
                    break;
            }
            gameManagers.GetComponent<ScrollingHealth>().playersGettingDamage(target, attack.Power);
        }
        if(WestFlankCharacter == target){
            //the player that just attacked the enemy is in the west position (left of enemy)
            print("WEST");

            switch (rando)
            {
                case 3:
                    //print("first move");
                    attack = Resources.Load("Attacks/" + "RandomAttack1") as Attack;

                    Debug.Log(attack);
                    break;
                case 2:
                    //print("second move");
                    attack = Resources.Load("Attacks/" + "RandomAttack1") as Attack;

                    Debug.Log(attack);
                    break;
                case 1:
                    //print("third move");
                    attack = Resources.Load("Attacks/" + "RandomAttack1") as Attack;

                    Debug.Log(attack);
                    break;
                case 0:
                    //print("fourth move");
                    attack = Resources.Load("Attacks/" + "RandomAttack1") as Attack;

                    Debug.Log(attack);
                    break;
            }
            gameManagers.GetComponent<ScrollingHealth>().playersGettingDamage(target, attack.Power);
        }
    }
    
}
