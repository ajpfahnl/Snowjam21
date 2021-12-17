using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public bool dontSpawn;
    public GameObject[] enemy;
    public GameObject powerup;
    public Transform trfm;

    public Sprite closed;
    public SpriteRenderer rend;
    public BoxCollider2D boxCol;
    
    int slowUpdate;
    int fallTmr;

    static int powerupDrop;
    static bool first;

    void Start()
    {
        if (!dontSpawn)
        {
            if (Random.Range(0, mapGenerator.spawnChance) < 25)
            {
                if (mapGenerator.spawnChance > 115)
                {
                    Instantiate(enemy[0], trfm.position + new Vector3(0, 2, 0), trfm.rotation);
                }
                else if (mapGenerator.spawnChance > 100)
                {
                    Instantiate(enemy[Random.Range(0,2)], trfm.position + new Vector3(0, 2, 0), trfm.rotation);
                }
                else
                {
                    Instantiate(enemy[Random.Range(0, 3)], trfm.position + new Vector3(0, 2, 0), trfm.rotation);
                }
            }
            if (!first)
            {
                first = true;
                powerupDrop = Random.Range(0,15);
            } else
            {
                if (powerupDrop > 0) { powerupDrop--; }
                else
                {
                    powerupDrop = Random.Range(0, 15);
                    Instantiate(powerup, trfm.position + new Vector3(Random.Range(-2f, 2f), 2, 0), trfm.rotation);
                }
            }
            if (Random.Range(0, 5) == 1)
            {
                rend.sprite = closed;
                boxCol.usedByEffector = false;
            }
        }
        rotRight = Random.Range(0, 2) == 0;
    }
    Vector3 fall = new Vector3(0,0.2f);
    bool rotRight;
    private void FixedUpdate()
    {
        if (fallTmr > 0)
        {
            fallTmr--;
            trfm.position += fall;
            fall.y -= .02f;
            if (fallTmr > 40)
            {
                if (rotRight)
                {
                    trfm.Rotate(Vector3.forward*3);
                } else
                {
                    trfm.Rotate(Vector3.forward * -3);
                }
            }
            if (fallTmr == 0) { Destroy(gameObject); }
        } else
        {
            if (slowUpdate > 0)
            {
                slowUpdate--;
            }
            else
            {
                slowUpdate = 4;
                if (trfm.position.y < mainCam.trfm.position.y -4.5f)
                {
                    fallTmr = 50;
                    boxCol.enabled = false;
                }
            }
        }
    }
}
