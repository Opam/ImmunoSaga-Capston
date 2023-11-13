using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FighterAction : MonoBehaviour
{
    private GameObject enemy;
    private GameObject hero;

    [SerializeField]
    private GameObject meelePrefab;

    [SerializeField]
    private GameObject rangePrefab;

    [SerializeField]
    private GameObject defensePrefab;

    [SerializeField]
    private GameObject healPrefab;

    [SerializeField]
    private Sprite faceIcon;

    private GameObject currentAttack;
    private GameObject def;
    private GameObject heal;

    void Awake()
    {
        hero = GameObject.FindGameObjectWithTag("Hero");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    public void SelectAttack(string btn)
    {
        GameObject victim = hero;
        if (tag == "Hero")
        {
            victim = enemy;
        }
        if (btn == "meele")
        {
            Debug.Log("melee");
            meelePrefab.GetComponent<AttackScript>().Attack(victim);
        }
        else if (btn == "range")
        {
            Debug.Log("range");
            rangePrefab.GetComponent<AttackScript>().Attack(victim);
        }
        else if (btn == ("defense"))
        {
            Debug.Log("defense");
            defensePrefab.GetComponent<AttackScript>().Defense(victim);
        }
        else
        {
            /* Debug.Log("Healing");*/
        }
    }
}
