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

    [Header("A value of -1 will hide that move in that location")]
    [Header("N,E,S,W refers to enemy location relative to player")]
    [Header("Cardinal Damage Multiplier: [Neutral, North, East, South, West]")]
    
    

    [SerializeField]
    float[] cardinalDamageMultiplier;

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
