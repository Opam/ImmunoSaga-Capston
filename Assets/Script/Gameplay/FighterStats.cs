using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Mathematics;

public class FighterStats : MonoBehaviour, IComparable
{

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Image healthFill;

    [SerializeField]
    private Image magicFill;

    [Header("Stats")]
    public float health;
    public float magic;
    public float meele;
    public float magicRange;
    public float defense;
    public float speed;
    public float experience;

    private float startHealth;
    private float startMagic;

    [HideInInspector]
    public int nextActTurn;

    private bool dead = false;

    //resize health and magic bar
    private Transform healthTransform;
    private Transform magicTransform;

    private Vector2 healthScale;
    private Vector2 magicScale;

    private float xNewHealthScale;
    private float xNewMagicScale;

    private GameObject GameControllerObj;

    private bool isDefense;
    public GameObject panelLose;
    public GameObject panelWin;

    public int manaRegenCount;
    public int maxManaRegenCount = 3;

    void Awake()
    {
        //healthTransform = healthFill.GetComponent<RectTransform>();
        //healthScale = healthFill.transform.localScale;

        //magicTransform = magicFill.GetComponent<RectTransform>();
        //magicScale = magicFill.transform.localScale;

        startHealth = health;
        startMagic = magic;

        GameControllerObj = GameObject.Find("GameControllerObject");
    }

    public void ReceiveDamage(float damage)
    {
        if (!isDefense)
        {
            if (isDefense)
            {
                DisableShieldVFX();
            }


            health = health - damage;
            animator.Play("hurt");

            //set damage text

            if (health <= 0)
            {
                if (gameObject.tag == "Hero" && health <= 0)
                {
                    panelLose.SetActive(true);
                }
                else if (gameObject.tag == "Enemy" && health <= 0)
                {
                    panelWin.SetActive(true);
                }

                dead = true;
                gameObject.tag = "Dead";
                Destroy(healthFill);
                Destroy(gameObject);
            }

            else if (damage > 0)
            {
                //xNewHealthScale = healthScale.x * (health / startHealth);
                //healthFill.transform.localScale = new Vector2(xNewHealthScale, healthScale.y);
                float hlth = health / startHealth;
                healthFill.fillAmount = hlth;
            }

            if (damage > 0)
            {
                GameControllerObj.GetComponent<GameController>().battleText.gameObject.SetActive(true);
                GameControllerObj.GetComponent<GameController>().battleText.text = damage.ToString();
            }

        }

        isDefense = false;

        Invoke("ContinueGame", 2);
    }

    public void DisableShieldVFX()
    {
        if (AttackScript.shieldVFX != null)
        {
            Debug.Log("VFX Hilang");
            AttackScript.shieldVFX.SetActive(false);
        }
    }

    public void RegenerateMana(int amount)
    {
        
        if (manaRegenCount < maxManaRegenCount)
        {
            magic += amount;
            manaRegenCount++;

            float mgc = magic / startMagic;
            magicFill.fillAmount = mgc;
        }
    }

    public void ReceiveHealing(int healingAmount)
    {
        health += healingAmount;

        if (health > startHealth)
        {
            health = startHealth;
        }
    }

    public void SetDefense()
    {
        isDefense = true;
    }

    public void UpdateHealthFill(float healingAmount)
    {
        health += healingAmount;

        if (health > startHealth)
        {
            health = startHealth;
        }

        //resize health bar
        //healthTransform = healthFill.GetComponent<RectTransform>();
        //healthScale = healthFill.transform.localScale;
        //xNewHealthScale = healthScale.x * (health / startHealth);
        //healthFill.transform.localScale = new Vector2(xNewHealthScale, healthScale.y);
        float hlth = health / startHealth;
        healthFill.fillAmount = hlth;
    }

    public void updateMagicFill(float cost)
    {
        if (cost > 0)
        {
            magic = magic - cost;
            //xNewMagicScale = magicScale.x * (magic / startMagic);
            //magicFill.transform.localScale = new Vector2(xNewMagicScale, magicScale.y);
            float mgc = magic / startMagic;
            magicFill.fillAmount = mgc;
        }
    }

    public bool GetDead()
    {
        return dead;
    }

    void ContinueGame()
    {
        if (GameControllerObj != null)
        {
            GameObject.Find("GameControllerObject").GetComponent<GameController>().NextTurn();
        }
    }

    public void CalculateNextTurn(int currentTurn)
    {
        nextActTurn = currentTurn + Mathf.CeilToInt(100f / speed);
    }

    public int CompareTo(object otherStats)
    {
        int nex = nextActTurn.CompareTo(((FighterStats)otherStats).nextActTurn);
        return nex;
    }
}
