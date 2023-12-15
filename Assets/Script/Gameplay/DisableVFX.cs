using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableVFX : MonoBehaviour
{
    public float timer;
    void Start()
    {
        
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer > 0)
        {
            return;
        }
        DisableVfx();
    }


    public void DisableVfx()
    {
        Destroy(gameObject);
    }
}
