using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character : MonoBehaviour
{
    [SerializeField]
    baseCharacter _base;
    public baseCharacter baseChar{
        get{return _base; }
    }
    public List<attackSelector> attacks{get; set;}
    // Start is called before the first frame update
    public void Init(){
        attacks = new List<attackSelector>();
        foreach(var move in baseChar.PotentialMoves)     //loops through each move and adds the learnable ones
        {
            attacks.Add(new attackSelector(move.Base));
            if(attacks.Count >= 4)
            {
                break;
            }
        }
    }
}
