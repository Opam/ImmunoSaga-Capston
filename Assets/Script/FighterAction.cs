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
    private GameObject defPrefab;

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
        if (btn.CompareTo("meele") == 0)
        {
            meelePrefab.GetComponent<AttackScript>().Attack(victim);
        }
        else if (btn.CompareTo("range") == 0)
        {
            rangePrefab.GetComponent<AttackScript>().Attack(victim);
        }
        else if (btn.CompareTo("def") == 0)
        {
            def.GetComponent<AttackScript>().Attack(victim);
        }
        else
        {
            /* Debug.Log("Healing");*/
        }
    }
}
