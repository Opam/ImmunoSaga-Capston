using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void gameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
