using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPhase : MonoBehaviour
{
    public Transform turnContainer;
    public GameObject playerImagePrefabs;
    public GameObject enemyImagePrefabs;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DestroyFirstImage()
    {
        Transform first = turnContainer.GetChild(0);
        Destroy(first.gameObject);

        if (turnContainer.childCount == 6)
        {
            SpawnAgain();
        }
    }

    private void SpawnAgain()
    {
        Instantiate(playerImagePrefabs, turnContainer);
        Instantiate(enemyImagePrefabs, turnContainer);
    }
}
