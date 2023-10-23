using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject settingPanel;
    public GameObject creditPanel;

    void Start()
    {
        mainPanel.SetActive(true);
        settingPanel.SetActive(false);
        creditPanel.SetActive(false);
    }

    void Update()
    {
        
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

    public void exitBtn()
    {
        Application.Quit();
    }
}
