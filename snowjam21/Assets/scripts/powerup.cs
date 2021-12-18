using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
    int powerupID;
    public Sprite[] sprites;
    public SpriteRenderer rend;
    Color alpha = new Color(0,0,0,0.16f);
    public Rigidbody2D rb;
    public BoxCollider2D boxCol;
    Vector2 bounce = new Vector2(0,5);
    Vector3 grow = new Vector3(0.08f,0.08f,0);
    Transform trfm;
    int timer;
    int collectTmr;
    // Start is called before the first frame update
    void Start()
    {
        trfm = transform;
        powerupID = Random.Range(0,7);
        rend.sprite = sprites[powerupID];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (collectTmr > 0)
        {
            collectTmr--;
            trfm.localScale += grow;
            rend.color -= alpha;

            if (collectTmr == 0)
            {
                Destroy(gameObject);
            }
        } else
        {
            if (timer > 0)
            {
                timer--;
            }
            else
            {
                timer = 100;
                rb.velocity = bounce;
                if (trfm.position.y < mainCam.trfm.position.y - 10) { Destroy(gameObject); }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 10 && collectTmr == 0)
        {
            playerMovement.plyrMoveScr.doPowerup(powerupID);
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
            boxCol.enabled = false;
            collectTmr = 7;
        }
    }
}
