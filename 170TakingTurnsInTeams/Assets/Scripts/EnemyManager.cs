using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    private Text moveText;
    private Image moveImage;
    // Start is called before the first frame update
    void Start()
    {
        gameManagers = GameObject.Find("Game managers");
        moveText = GameObject.Find("enemyMoveText").GetComponent<Text>();
        moveImage = GameObject.Find("moveImage").GetComponent<Image>();
        moveImage.enabled = false;
        moveText.enabled = false;
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
    public void Attack(GameObject target)
    {

        if (classtype == classeTypes.Spider) // Spider attack moveset
        {
            int coinflip1 = Random.Range(0, 2); // decides base attack for all directions
            int coinflip2 = Random.Range(0, 3); // decides if base attack is swapped with laser attack
            int coinflip3 = Random.Range(0, 3); // decides if base attack is swapped with web attack

            switch (coinflip1)
            {
                case 0:
                    attack = Resources.Load("Attacks/Enemy/" + "Spider Poke") as Attack;
                    break;
                case 1:
                    attack = Resources.Load("Attacks/Enemy/" + "Spider Slash") as Attack;
                    break;
            }

            if (WestFlankCharacter == target)
            {
                if (coinflip2 == 0)
                {
                    attack = Resources.Load("Attacks/Enemy/" + "Spider Laser") as Attack;
                }
            }
            if (EastFlankCharacter == target)
            {
                if (coinflip3 == 0)
                {
                    attack = Resources.Load("Attacks/Enemy/" + "Spider Web") as Attack;
                }
            }
            // executes chosen attack
            Debug.Log(attack);
            gameManagers.GetComponent<ScrollingHealth>().playersGettingDamage(target, attack.Power);
            StartCoroutine(enableDisableEnemyText());
            moveText.text = "Spider used: " + attack;
        }

        if (classtype == classeTypes.Dog) // Dog attack moveset
        {
            int randoFront = Random.Range(0, 3); // chooses from 3 forward-facing moves
            int randoElse = Random.Range(0, 2); // all other directions have 2 moves to choose from

            if (WestFlankCharacter == target)
            {
                switch (randoFront)
                {
                    case 2:
                        attack = Resources.Load("Attacks/Enemy/" + "Dog Bite") as Attack;
                        break;
                    case 1:
                        attack = Resources.Load("Attacks/Enemy/" + "Dog Claw") as Attack;
                        break;
                    case 0:
                        attack = Resources.Load("Attacks/Enemy/" + "Dog Laser") as Attack;
                        break;
                }
            }
            if (NorthFlankCharacter == target)
            {
                switch (randoElse)
                {
                    case 1:
                        attack = Resources.Load("Attacks/Enemy/" + "Dog Sweep 1") as Attack;
                        break;
                    case 0:
                        attack = Resources.Load("Attacks/Enemy/" + "Dog Punch 1") as Attack;
                        break;
                }
            }
            if (SouthFlankCharacter == target)
            {
                switch (randoElse)
                {
                    case 1:
                        attack = Resources.Load("Attacks/Enemy/" + "Dog Sweep 2") as Attack;
                        break;
                    case 0:
                        attack = Resources.Load("Attacks/Enemy/" + "Dog Punch 2") as Attack;
                        break;
                }
            }
            if (EastFlankCharacter == target)
            {
                switch (randoElse)
                {
                    case 1:
                        attack = Resources.Load("Attacks/Enemy/" + "Dog Whip") as Attack;
                        break;
                    case 0:
                        attack = Resources.Load("Attacks/Enemy/" + "Dog Kick") as Attack;
                        break;
                }
            }
            // executes chosen attack
            Debug.Log(attack);
            gameManagers.GetComponent<ScrollingHealth>().playersGettingDamage(target, attack.Power);
            if(moveImage.enabled == true){
                StopCoroutine(enableDisableEnemyText());
            }
            StartCoroutine(enableDisableEnemyText());
            moveText.text = "Dog used: " + attack;
        }
    }
    public IEnumerator enableDisableEnemyText(){
        moveImage.enabled = true;
        moveText.enabled = true;
        yield return new WaitForSeconds(3.0f);
        moveImage.enabled = false;
        moveText.enabled = false;
    }
}
