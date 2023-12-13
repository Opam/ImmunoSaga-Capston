using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public AnimationClip fadeOutClip;
    int indexScene;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void FadeOutLoadScene(int nomerScene)
    {
        gameObject.SetActive(true);

        indexScene = nomerScene;

        Invoke("FadeOutCheck", fadeOutClip.length);
    }

    void FadeOutCheck()
    {
        SceneManager.LoadScene(indexScene);
    }
}
