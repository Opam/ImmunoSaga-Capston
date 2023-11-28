using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStart : MonoBehaviour
{
    public float startCam;
    public float timeCam;
    public GameObject panelGame;
    private Camera cam;
    private float endCam;
    private float multiplier;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        endCam = cam.orthographicSize;

        multiplier = (endCam - startCam) / timeCam;
        cam.orthographicSize = startCam;
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (cam.orthographicSize < endCam)
        {
            cam.orthographicSize += (Time.deltaTime * multiplier);

            if (cam.orthographicSize >= endCam)
            {
                panelGame.SetActive(true);
            }
        }
    }
}
