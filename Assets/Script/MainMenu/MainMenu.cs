using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject settingPanel;
    public GameObject creditPanel;
    public Animator animator;
    public Animator btnanimator;


    public Button button;


    void Start()
    {
        mainPanel.SetActive(false);
        settingPanel.SetActive(false);
        creditPanel.SetActive(false);
    }

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
        {
            mainPanel.SetActive(true);
        }

        if (settingPanel.activeSelf)
        {
            mainPanel.SetActive(false);
            creditPanel.SetActive(false);
        }

        if (creditPanel.activeSelf)
        {
            mainPanel.SetActive(false);
            settingPanel.SetActive(false);
        }
    }

    public void MainPanel()
    {
        mainPanel.SetActive(true);
        settingPanel.SetActive(false);
        creditPanel.SetActive(false);
    }

    public void SettingPanel()
    {
        mainPanel.SetActive(false);
        settingPanel.SetActive(true);
        creditPanel.SetActive(false);
    }

    public void CreditPanel()
    {
        mainPanel.SetActive(false);
        settingPanel.SetActive(false);
        creditPanel.SetActive(true);
    }
}
