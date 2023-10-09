using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject optionPanel;
    public GameObject creditPanel;

    void Start()
    {
        mainPanel.SetActive(true);
        optionPanel.SetActive(false);
        creditPanel.SetActive(false);
    }

    void Update()
    {
        
    }

    public void OptionPanel()
    {
        mainPanel.SetActive(false);
        optionPanel.SetActive(true);
        creditPanel.SetActive(false);
    }    

    public void CreditPanel()
    {
        mainPanel.SetActive(false);
        optionPanel.SetActive(false);
        creditPanel.SetActive(true);
    }

    public void exitBtn()
    {
        Application.Quit();
    }
}
