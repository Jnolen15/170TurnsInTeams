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

    // Start is called before the first frame update
    void Start()
    {
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
}
