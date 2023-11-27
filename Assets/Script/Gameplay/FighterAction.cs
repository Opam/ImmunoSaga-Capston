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
    private GameObject healingPrefab;

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
        bool isHero;
        isHero = false;
        if (tag == "Hero")
        {
            victim = enemy;
            isHero = true;
        }
        if (btn == "meele")
        {
            meelePrefab.GetComponent<AttackScript>().Attack(victim, isHero);
        }
        else if (btn == "range")
        {
            rangePrefab.GetComponent<AttackScript>().Attack(victim, isHero);
        }
        else if (btn == ("defense"))
        {
            defensePrefab.GetComponent<AttackScript>().Defense(victim);
        }
        else if (btn == ("heal"))
        {
            healingPrefab.GetComponent<AttackScript>().Healing(victim);
        }
    }
}
