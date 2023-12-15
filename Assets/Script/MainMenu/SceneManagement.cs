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

    public void story()
    {
        SceneManager.LoadScene("Story");
    }

    public void gameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void prolog()
    {
        SceneManager.LoadScene("Prolog");
    }
}
