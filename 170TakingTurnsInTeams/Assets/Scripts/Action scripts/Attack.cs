using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "Combat/Create new Attack")]
public class Attack : ScriptableObject  //This really should be called attack base
{
    [SerializeField]
    string name;
    [TextArea]
    [SerializeField]
    string desc;

    [SerializeField]
    int power;
}
