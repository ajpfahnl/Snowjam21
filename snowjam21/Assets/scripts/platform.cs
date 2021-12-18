using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public bool dontSpawn;
    public GameObject[] enemy;
    public GameObject powerup;
    public Transform trfm;

    public Sprite[] plats;
    public SpriteRenderer rend;
    public BoxCollider2D boxCol;
    
    int slowUpdate;
    int fallTmr;

    static int wirePlat;
    static int closedPlat;
    static int powerupDrop;
    static bool first;

    public GameObject hotWire;

    void Start()
    {
        if (!dontSpawn)
        {
            if (Random.Range(0, mapGenerator.spawnChance) < 20)
            {
                if (mapGenerator.spawnChance > 125)
                {
                    Instantiate(enemy[0], trfm.position + new Vector3(0, 2, 0), trfm.rotation);
                }
                else if (mapGenerator.spawnChance > 105)
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
                wirePlat = Random.Range(4, 7);
                closedPlat = Random.Range(4, 7);
            } else
            {
                if (powerupDrop > 0) { powerupDrop--; }
                else
                {
                    powerupDrop = Random.Range(0, 15);
                    Instantiate(powerup, trfm.position + new Vector3(Random.Range(-2f, 2f), 2, 0), trfm.rotation);
                }
            }
            if (wirePlat > 0)
            {
                wirePlat--;
                if (closedPlat > 0)
                {
                    closedPlat--;
                } else
                {
                    rend.sprite = plats[0];
                    boxCol.usedByEffector = false;
                    closedPlat = Random.Range(4,7);
                }
            } else
            {
                rend.sprite = plats[1];
                wirePlat = Random.Range(4, 7);
                Instantiate(hotWire, trfm.position, trfm.rotation).transform.parent = trfm;
            }
        }
        rotRight = Random.Range(0, 2) == 0;
    }
    Vector3 fall = new Vector3(0,0.26f);
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
