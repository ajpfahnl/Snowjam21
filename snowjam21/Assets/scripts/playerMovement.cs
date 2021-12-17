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

    public Transform flameThrowerTrfm;
    Transform trfm;

    // Start is called before the first frame update
    void Start()
    {
        trfm = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && groundScr.onGround)
        {
            vel.y = jumpHeight;
            rb.velocity = vel;
        }
    }
    private void FixedUpdate()
    {
        keyA = Input.GetKey(KeyCode.A);
        keyD = Input.GetKey(KeyCode.D);

        if (keyA && !keyD)
        {
            vel.x = -spd;
            vel.y = rb.velocity.y;
            rb.velocity = vel;
        } else
        if (keyD && !keyA)
        {
            vel.x = spd;
            vel.y = rb.velocity.y;
            rb.velocity = vel;
        } else
        {
            vel.x = 0;
            vel.y = rb.velocity.y;
            rb.velocity = vel;
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
    }
}
