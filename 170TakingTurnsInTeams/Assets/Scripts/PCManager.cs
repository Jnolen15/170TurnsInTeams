using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCManager : MonoBehaviour
{
    // Class type
    public enum classeTypes
    {
        Rouge,
        Mage,
        Knight
    };
    public classeTypes classtype;

    // Public Variables
    public Transform location;
    public GameObject adjacentEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (location.parent.tag != "PositionManager")
        {
            adjacentEnemy = location.parent.GetComponent<Position>().character;
        }
        else
        {
            adjacentEnemy = null;
        }
    }
}
