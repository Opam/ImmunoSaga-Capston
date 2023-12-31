using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public List<GameObject> vfx;

    public static VFXManager instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject SpawnVFX(int index, Transform position)
    {
        return Instantiate(vfx[index], position.position, Quaternion.identity);
    }
}