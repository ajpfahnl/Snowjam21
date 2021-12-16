using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGenerator : MonoBehaviour
{
    public GameObject[] chunks;
    Vector3 placement;

    public Transform plyrTrfm;
    public float threshold;

    public static mapGenerator mapGenScr;

    private void Awake()
    {
        mapGenScr = GetComponent<mapGenerator>();
    }
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int k = 0; k < 2; k++)
            {
                placement.x = k * 7.5f - 3.75f;
                placement.y = i * 7.5f;
                instChunk();
            }
        }

        threshold = 7.5f;
        placement = new Vector3(0, threshold + 15, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!gameState.lost && plyrTrfm.position.y > threshold)
        {
            for (int i = 0; i < 2; i++)
            {
                placement.x = i * 7.5f - 3.75f;
                instChunk();
            }
            threshold += 7.5f;
            placement.y = threshold + 15;
        }
    }

    void instChunk()
    {
        Instantiate(chunks[Random.Range(0, chunks.Length)], placement, Quaternion.identity);
    }
}
