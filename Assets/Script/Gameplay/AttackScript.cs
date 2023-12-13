using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackScript : MonoBehaviour
{
    public GameObject owner;

    [SerializeField]
    private string animationName;

    [SerializeField]
    private bool magicAttack;

    [SerializeField]
    private float magicCost;

    [SerializeField]
    private float minAttackMultiplier;

    [SerializeField]
    private float maxAttackMultiplier;

    [SerializeField]
    private float minDefenseMultiplier;

    [SerializeField]
    private float maxDefenseMultiplier;

    private FighterStats attackerStats;
    private FighterStats targetStats;
    private float damage = 0.0f;

    public void SetOwner(GameObject newOwner)
    {
        owner = newOwner;
        attackerStats = owner.GetComponent<FighterStats>();
    }
    public void Attack(GameObject victim, bool isHero)
    {
        attackerStats = owner.GetComponent<FighterStats>();
        targetStats = victim.GetComponent<FighterStats>();

        if (attackerStats.magic >= magicCost)
        {
            if (isHero)
            {
                VFXManager.instance.SpawnVFX(0, victim.transform);
            }

            if (!isHero)
            {
                VFXManager.instance.SpawnVFX(1, victim.transform);
            }

            float multiplier = Random.Range(minAttackMultiplier, maxAttackMultiplier);

            damage = multiplier * attackerStats.meele;

            if (magicAttack)
            {
                damage = multiplier * attackerStats.magicRange;
            }

            float defenseMultiplier = Random.Range(minDefenseMultiplier, maxDefenseMultiplier);
            damage = Mathf.Max(0, damage - (defenseMultiplier * targetStats.defense));
            owner.GetComponent<Animator>().Play(animationName);
            targetStats.ReceiveDamage(Mathf.CeilToInt(damage));
            attackerStats.updateMagicFill(magicCost);
        }
        else
        {
            Invoke("SkipTurnContinueGame", 2);
        }
    }

    public void Defense(GameObject victim)
    {
        VFXManager.instance.SpawnVFX(4, owner.transform);
        attackerStats = owner.GetComponent<FighterStats>();
        targetStats = victim.GetComponent<FighterStats>();
        
        attackerStats.SetDefense();
        targetStats.ReceiveDamage(0);
    }

    public void Healing(GameObject victim)
    {
        attackerStats = owner.GetComponent<FighterStats>();
        targetStats = owner.GetComponent<FighterStats>();
        VFXManager.instance.SpawnVFX(2, owner.transform);

        if (attackerStats.magic >= magicCost)
        {
            float healingAmount = attackerStats.magicRange / 2;

            targetStats.UpdateHealthFill(healingAmount);

            attackerStats.updateMagicFill(magicCost);
        }

        Invoke("SkipTurnContinueGame", 2);
    }

    public void RestMana(GameObject victim)
    {
        attackerStats = owner.GetComponent<FighterStats>();
        targetStats = owner.GetComponent<FighterStats>();
        VFXManager.instance.SpawnVFX(3, owner.transform);

        if (owner.GetComponent<FighterStats>().manaRegenCount < owner.GetComponent<FighterStats>().maxManaRegenCount)
        {
            owner.GetComponent<FighterStats>().RegenerateMana(10);
        }

        Invoke("SkipTurnContinueGame", 2);
    }

    void SkipTurnContinueGame()
    {
        GameObject.Find("GameControllerObject").GetComponent<GameController>().NextTurn();
    }
}