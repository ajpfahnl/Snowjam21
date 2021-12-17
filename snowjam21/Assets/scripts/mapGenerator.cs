using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGenerator : MonoBehaviour
{
    public GameObject[] chunks;
    int lastChunk;
    Vector3 placement;

    public Transform plyrTrfm;
    public float threshold;

    public static int spawnChance;
    public static mapGenerator mapGenScr;
    public static int elapsedTime;

    private void Awake()
    {
        InvokeRepeating("sec", 1, 1);
        mapGenerator.spawnChance = 125;

        lastChunk = -1;

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
        int selectChunk = Random.Range(0, chunks.Length);
        while (selectChunk == lastChunk) { selectChunk = Random.Range(0, chunks.Length); }
        Instantiate(chunks[selectChunk], placement, Quaternion.identity);
        lastChunk = selectChunk;
    }
    void sec()
    {
        if (spawnChance > 25) { spawnChance--; }
        elapsedTime++;
        if (elapsedTime>75)
        {
            if (mainCam.riseRate < .045f)
            {
                mainCam.riseRate += .0002f;
            } else
            {
                mainCam.riseRate = .04501f;
            }
        }
    }
}
