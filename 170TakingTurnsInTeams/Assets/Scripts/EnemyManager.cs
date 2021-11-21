using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Enemy type
    public enum classeTypes
    {
        Goblin
    };
    public classeTypes classtype;

    // Public Variables
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

    // Start is called before the first frame update
    void Start()
    {
        NorthFlank = location.transform.GetChild(0).gameObject;
        EastFlank = location.transform.GetChild(1).gameObject;
        SouthFlank = location.transform.GetChild(2).gameObject;
        WestFlank = location.transform.GetChild(3).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        NorthFlankCharacter = NorthFlank.GetComponent<Position>().character;
        EastFlankCharacter = EastFlank.GetComponent<Position>().character;
        SouthFlankCharacter = SouthFlank.GetComponent<Position>().character;
        WestFlankCharacter = WestFlank.GetComponent<Position>().character;
    }
}
