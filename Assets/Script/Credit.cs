using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit : MonoBehaviour
{
    public GameObject tombol;
    public Animator animator;

    private void Start()
    {
        tombol.SetActive(false);
    }

    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            tombol.SetActive(true);
        }
    }
}
