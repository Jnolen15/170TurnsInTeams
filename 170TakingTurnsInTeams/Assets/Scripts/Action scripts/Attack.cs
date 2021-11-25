using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "Combat/Create new Attack")]
public class Attack : ScriptableObject  //This really should be called attack base
{
    [SerializeField]
    string nameOfAttack;
    [TextArea]
    [SerializeField]
    string desc;

    [SerializeField]
    int power;

    [SerializeField]
    int manaPoints;

    public string NameOfAttack{
        get { return nameOfAttack; }
    }
    public string Desc{
        get {return desc; }
    }
    public int Power{
        get { return power; }
    }

    public int ManaPoints{
        get { return manaPoints; }
    }
}
