using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ActionSelector : MonoBehaviour
{
    [SerializeField]
    List<Text> actionTexts;

    public void SetMoveNames(List<attackSelector> attacks)
    {
        for(int i = 0; i < actionTexts.Count; ++i)
        {
            if (i < attacks.Count)
            {
                actionTexts[i].text = attacks[i].Base.name;
            }
            else
            {
                actionTexts[i].text = "-";
            }
        }
    }
}
