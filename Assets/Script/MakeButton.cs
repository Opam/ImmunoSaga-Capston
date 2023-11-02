using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.UI;

public class MakeButton : MonoBehaviour
{
    [SerializeField]
    private bool physical;

    private GameObject hero;

    void Start()
    {
        string temp = gameObject.name;
        gameObject.GetComponent<Button>().onClick.AddListener(() => AttachCallBack(temp));
        hero = GameObject.FindGameObjectWithTag("Hero");
    }

    private void AttachCallBack(string btn)
    {
        if (btn.CompareTo("MeeleBtn") == 0)
        {
            hero.GetComponent<FighterAction>().SelectAttack("meele");
        }
        else if (btn.CompareTo("RangeBtn") == 0)
        {
            hero.GetComponent<FighterAction>().SelectAttack("range");
        }
        else if (btn.CompareTo("DefBtn") == 0)
        {
            hero.GetComponent<FighterAction>().SelectAttack("def");
        }
        else
        {
            hero.GetComponent<FighterAction>().SelectAttack("heal");
        }
    }
}
