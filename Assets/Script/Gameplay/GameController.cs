using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private List<FighterStats> fighterStats;

    [SerializeField]
    private GameObject battleMenu;

    public Text battleText;

    public TurnPhase turnPhase;

    void Start()
    {
        animator.Play("getar");

        fighterStats = new List<FighterStats>();

        GameObject hero = GameObject.FindGameObjectWithTag("Hero");
        FighterStats currentFighterStats = hero.GetComponent<FighterStats>();
        currentFighterStats.CalculateNextTurn(0);
        fighterStats.Add(currentFighterStats);

        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        FighterStats currentEnemyStats = enemy.GetComponent<FighterStats>();
        currentEnemyStats.CalculateNextTurn(0);
        fighterStats.Add(currentEnemyStats);

        fighterStats.Sort();
        this.battleMenu.SetActive(false);

        NextTurn();
    }

    public void NextTurn()
    {
        battleText.gameObject.SetActive(false);
        FighterStats currentFighterStats = fighterStats[0];
        fighterStats.Remove(currentFighterStats);

        if (!currentFighterStats.GetDead())
        {
            GameObject currentUnit = currentFighterStats.gameObject;
            currentFighterStats.CalculateNextTurn(currentFighterStats.nextActTurn);
            fighterStats.Add(currentFighterStats);
            fighterStats.Sort();

            if (currentUnit.tag == "Hero")
            {
                this.battleMenu.SetActive(true);
                turnPhase.DestroyFirstImage();
            }
            else
            {
                this.battleMenu.SetActive(false);
                string AttackType = Random.Range(0, 2) == 1 ? "meele" : "range";
                currentUnit.GetComponent<FighterAction>().SelectAttack(AttackType);
                turnPhase.DestroyFirstImage();
            }
        }
        else
        {
            NextTurn();
        }
    }
}
