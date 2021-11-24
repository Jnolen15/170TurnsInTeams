using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    public Action(GameObject _actor, GameObject _target, Attack _attack)
    {
        actor = _actor;
        target = _target;
        attack = _attack;
    }
    
    public GameObject actor;
    public GameObject target;
    public Attack attack;
}
