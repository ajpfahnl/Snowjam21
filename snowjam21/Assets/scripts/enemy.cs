using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int hp;
    public int burnTime;
    public ParticleSystem onFire;
    public selfDest onFireSelfDest;
    public Transform trfm;
    public Rigidbody2D rb;
    public GameObject death;

    public SpriteRenderer flashRend;
    public Color flashCol;

    public bool noKB;
    public bool untoasted;
    public SpriteRenderer rend;
    Color darken;

    void Start()
    {
        trfm = transform;
        trfm.parent = null;

        if (untoasted) { darken = new Color(.2f, .2f, .2f, 0); }
    }

    private void FixedUpdate()
    {
        if (burnTime > 0)
        {
            burnTime--;
            if (burnTime == 0) { onFire.Stop(); }
            if (burnTime%20==0)
            {
                takeDmg();
            }
            if (trfm.position.y < mainCam.trfm.position.y - 4.5f)
            {
                score.addPoint(); Destroy(gameObject);
                Instantiate(death, trfm.position, trfm.rotation);
            }
        } else
        {
            if (trfm.position.y < mainCam.trfm.position.y - 4.5f)
            {
                Destroy(gameObject);
                Instantiate(death, trfm.position, trfm.rotation);
            }
        }
        if (flashCol.a > 0)
        {
            flashCol.a -= .05f;
            flashRend.color = flashCol;
        }
    }

    void takeDmg()
    {
        if (untoasted)
        {
            rend.color -= darken;
        }
        hp -= 20;
        if (hp <= 0)
        {
            Instantiate(death, trfm.position, trfm.rotation);
            
            onFire.transform.parent = null;
            onFire.Stop();
            onFireSelfDest.enabled = true;
            score.addPoint();
            Destroy(gameObject);
        } else
        {
            flashCol.a = .8f;
            flashRend.color = flashCol;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 11)
        {
            if (burnTime < 1) { onFire.Play(); if (!noKB) { knockback(playerMovement.trfm.position, 8); } }
            takeDmg();
            burnTime = 100;
        }
        
    }

    Quaternion original;
    void knockback(Vector2 source, int force)
    {
        original = trfm.rotation;
        trfm.rotation = Quaternion.AngleAxis(Mathf.Atan2(trfm.position.y - source.y, trfm.position.x - source.x) * Mathf.Rad2Deg, Vector3.forward);
        rb.velocity = trfm.right * force;
        trfm.rotation = original;
    }
}
