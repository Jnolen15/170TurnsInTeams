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

    [Header("N,E,S,W refers to enemy location relative to player. A for anywhere")]
    [SerializeField]
    string location = "A";

    //[SerializeField]
    //float[] cardinalDamageMultiplier;

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

    public string Location
    {
        get { return location; }
    }
}
