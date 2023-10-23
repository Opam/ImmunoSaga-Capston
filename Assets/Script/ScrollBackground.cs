using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBackground : MonoBehaviour
{
    RawImage background;
    public float valueX, valueY;

    void Start()
    {
        background = GetComponent<RawImage>();
    }


    void Update()
    {
        background.uvRect = new Rect(background.uvRect.position + new Vector2(valueX, valueY) * Time.deltaTime, background.uvRect.size);
    }
}
