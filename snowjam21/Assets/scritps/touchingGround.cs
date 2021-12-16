using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchingGround : MonoBehaviour
{
    public bool onGround;
    public int timer;
    private void FixedUpdate()
    {
        if (timer > 0)
        {
            timer--;
        } else
        {
            onGround = false;
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        timer = 2;
        onGround = true;
    }

    public void forceGrounded()
    {
        onGround = true;
        timer = 3;
    }
}
