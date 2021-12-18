using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hotWire : MonoBehaviour
{
    public SpriteRenderer rend;
    public Color alpha;
    public BoxCollider2D boxCol;
    public Transform trfm; bool adj;
    int timer;

    private void Start()
    {
        trfm.localScale = new Vector3(1, 1, 1);
        alpha.a = .05f;
    }

    private void FixedUpdate()
    {
        if (timer > 0)
        {
            timer--;
            if (timer < 90)
            {
                if (timer < 40)
                {
                    if (timer == 39)
                    {
                        alpha.r = 1;
                        alpha.g = 1;
                        alpha.b = 1;
                        alpha.a = 1;
                        rend.color = alpha;
                        boxCol.enabled = true;
                    }
                } else
                {
                    if (rend.color.a >= .25) { alpha.a = -0.05f; }
                    if (rend.color.a <= 0) { alpha.a = 0.05f; }
                    rend.color += alpha;
                }
            }
        } else
        {
            //if (!adj) { adj = true; trfm.localScale = new Vector3(1, 1, 1); }
            timer = Random.Range(125,186);
            alpha.a = 0;
            rend.color = alpha;
            alpha.r = 0;
            alpha.g = 0;
            alpha.b = 0;
            boxCol.enabled = false;
        }

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 10)
        {
            playerMovement.plyrMoveScr.takeDmg(playerMovement.trfm.position + new Vector3(Random.Range(-2f, 2f), -4, 0), 24, false);
        }
    }
}
