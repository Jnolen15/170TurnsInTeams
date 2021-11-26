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
    public LayerMask positions;
    public GameObject NorthFlankCharacter;
    public GameObject EastFlankCharacter;
    public GameObject SouthFlankCharacter;
    public GameObject WestFlankCharacter;

    // Private Variables
    private GameObject NorthFlank;
    private GameObject EastFlank;
    private GameObject SouthFlank;
    private GameObject WestFlank;

    void Update()
    {
        Vector3 buffer = new Vector3(0, 1, 0);

        RaycastHit2D hit = Physics2D.Raycast(location.transform.position + buffer, Vector2.up, 4, positions);
        if (hit.collider != null)
        {
            NorthFlank = hit.collider.gameObject;
            NorthFlankCharacter = NorthFlank.GetComponent<Position>().character;
        }
        else
        {
            NorthFlankCharacter = null;
            NorthFlank = null;
        }

        hit = Physics2D.Raycast(location.transform.position + buffer, Vector2.right, 4, positions);
        if (hit.collider != null)
        {
            EastFlank = hit.collider.gameObject;
            EastFlankCharacter = EastFlank.GetComponent<Position>().character;
        }
        else
        {
            EastFlankCharacter = null;
            EastFlank = null;
        }

        hit = Physics2D.Raycast(location.transform.position + buffer, -Vector2.up, 4, positions);
        if (hit.collider != null)
        {
            SouthFlank = hit.collider.gameObject;
            SouthFlankCharacter = SouthFlank.GetComponent<Position>().character;
        }
        else
        {
            SouthFlankCharacter = null;
            SouthFlank = null;
        }

        hit = Physics2D.Raycast(location.transform.position + buffer, -Vector2.right, 4, positions);
        if (hit.collider != null)
        {
            WestFlank = hit.collider.gameObject;
            WestFlankCharacter = WestFlank.GetComponent<Position>().character;
        }
        else
        {
            WestFlankCharacter = null;
            WestFlank = null;
        }
    }
}
