using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public int spd;
    public int jumpHeight;
    public int recoil;
    public Rigidbody2D rb;
    public touchingGround groundScr;
    Vector2 vel;
    bool keyA; bool keyD;

    public Camera cam;
    public static bool faceRight;
    int freePhys;

    public Transform flameThrowerTrfm;
    public static Transform trfm;
    public static playerMovement plyrMoveScr;

    public Sprite[] toastSprites;
    public int hp;
    public hp[] hpScr;
    public SpriteRenderer rend;
    public SpriteRenderer whiteFlash;
    int immunity;

    public pupIconMan pupIconScr;
    int[] powerupTmr; //0: jelly; 1: peanutButter; 2: cheese; 3: butter; 4: avocado
    public GameObject pbShield;
    public flameThrower flameThrowerScr;
    bool every2;

    // Start is called before the first frame update
    void Start()
    {
        powerupTmr = new int[5];
        plyrMoveScr = GetComponent<playerMovement>();
        trfm = transform;
        hp = 3;

        if (flameThrower.mousePos.x > trfm.position.x)
        {
            faceRight = true;
            trfm.localScale = new Vector3(.1f, .1f, 1);
        }
        else
        {
            faceRight = false;
            trfm.localScale = new Vector3(-.1f, .1f, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && groundScr.onGround)
        {
            vel.y = jumpHeight;
            rb.velocity = vel;
            mainCam.addTrauma(7);
        }
    }
    private void FixedUpdate()
    {
        keyA = Input.GetKey(KeyCode.A);
        keyD = Input.GetKey(KeyCode.D);

        if (freePhys < 0)
        {
            if (keyA && !keyD)
            {
                vel.x = -spd;
                vel.y = rb.velocity.y;
                rb.velocity = vel;
            }
            else
        if (keyD && !keyA)
            {
                vel.x = spd;
                vel.y = rb.velocity.y;
                rb.velocity = vel;
            }
            else
            {
                vel.x = 0;
                vel.y = rb.velocity.y;
                rb.velocity = vel;
            }
        } else
        {
            freePhys--;
            if (freePhys == 0) { updateSprite(); }
        }

        if (!faceRight && flameThrower.mousePos.x > trfm.position.x)
        {
            faceRight = true;
            trfm.localScale = new Vector3(.1f,.1f,1);
        } else if (faceRight && flameThrower.mousePos.x < trfm.position.x)
        {
            faceRight = false;
            trfm.localScale = new Vector3(-.1f, .1f, 1);
        }

        if (Input.GetMouseButton(0) && flameThrower.fuel > 9 && !flameThrower.overheated)
        {
            if (faceRight)
            {
                rb.velocity = flameThrowerTrfm.right * -recoil;
            } else
            {
                rb.velocity = flameThrowerTrfm.right * recoil;
            }
        }

        if (immunity > 0)
        {
            if (immunity > 25 && immunity % 2 == 0)
            {
                whiteFlash.enabled = !whiteFlash.enabled;
            }
            immunity--;
            if (immunity == 25)
            {
                whiteFlash.enabled = false;
            }
        }

        if (trfm.position.y < mainCam.trfm.position.y - 4.5f && freePhys < 1)
        {
            takeDmg(trfm.position + new Vector3(Random.Range(-2f, 2f), -4, 0), 26);
        }

        if (every2)
        {
            for (int i = 0; i < 5; i++)
            {
                if (powerupTmr[i] > 0)
                {
                    powerupTmr[i]--;
                    if (powerupTmr[i] == 50)
                    {
                        pupIconScr.blinkPowerup(i);
                    }
                    if (powerupTmr[i] == 0)
                    {
                        pupIconScr.endPowerup(i);
                        if (i == 0)
                        {
                            jumpHeight = 22;
                        }
                        if (i == 1)
                        {
                            pbShield.SetActive(false);
                        }
                        if (i == 2)
                        {
                            flameThrowerScr.switchFlames(0);
                        }
                        if (i == 3)
                        {
                            spd = 7;
                        }
                    }
                }
            }
        }
        every2 = !every2;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 13 && immunity<1)
        {
            takeDmg(col.transform.position, 18);
        }
    }
    public void takeDmg(Vector2 source, int force)
    {
        if (powerupTmr[1] <= 0)
        {
            hp--;
            hpScr[hp].loseHP();
            if (hp == 0)
            {
                knockback(source, force);
                freePhys = 999;
                Time.timeScale = .3f;
                gameState.doLose();
                rend.sprite = toastSprites[0];
            }
            else
            {
                rend.sprite = toastSprites[4];
                mainCam.addTrauma(50);
                knockback(source, force);
                freePhys = 15;
                immunity = 50;
            }
        }
        else
        {
            powerupTmr[1] = 0;
            pbShield.SetActive(false);
            pupIconScr.endPowerup(1);
        }
    }

    Quaternion original;
    public void knockback(Vector2 source, int force)
    {
        original = trfm.rotation;
        trfm.rotation = Quaternion.AngleAxis(Mathf.Atan2(trfm.position.y - source.y, trfm.position.x - source.x) * Mathf.Rad2Deg, Vector3.forward);
        rb.velocity = trfm.right * force;
        trfm.rotation = original;
    }

    public void doPowerup(int powerupID)
    {
        if (powerupID == 0) //jelly
        {
            powerupTmr[0] = 200;
            jumpHeight = 28;
            pupIconScr.addPowerup(0);
        }
        if (powerupID == 1) //jam
        {
            if (hp < 14)
            {
                hpScr[hp].recoverHP();
                hp++;
                updateSprite();
            }
        }
        if (powerupID == 2) //peanut butter
        {
            powerupTmr[1] = 150;
            pupIconScr.addPowerup(1);
            pbShield.SetActive(true);
        }
        if (powerupID == 3) //cheese
        {
            powerupTmr[2] = 200;
            pupIconScr.addPowerup(2);
            flameThrowerScr.switchFlames(1);
        }
        if (powerupID == 4) //butter
        {
            spd = 11;
            powerupTmr[3] = 200;
            pupIconScr.addPowerup(3);
        }
        if (powerupID == 5) //honey
        {
            while (hp < 3)
            {
                hpScr[hp].recoverHP();
                hp++;
                updateSprite();
            }
        }
    }

    void updateSprite()
    {
        if (hp < 4) { rend.sprite = toastSprites[hp]; }
        else { rend.sprite = toastSprites[3]; }
    }
}
