using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Combat/Create new Base Character")]
public class baseCharacter : ScriptableObject
{
   [SerializeField]
   List<PotentialMoves> potentialMoves;

    public List<PotentialMoves> PotentialMoves
    {
        get { return potentialMoves; }
    }
}
[System.Serializable]
public class PotentialMoves{
    [SerializeField]
    Attack attackBase;
    public Attack Base
    {
        get { return attackBase; }
    }
}
