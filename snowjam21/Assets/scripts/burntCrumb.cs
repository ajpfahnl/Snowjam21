using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burntCrumb : MonoBehaviour
{
    public float spd;
    public touchingGround groundScr;
    public Transform spriteTrfm;
    Transform trfm;
    int rotate;
    // Start is called before the first frame update
    void Start()
    {
        rotate = 4;
        trfm = transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!gameState.started) { return; }
        if (!groundScr.onGround) 
        {
            groundScr.forceGrounded();
            trfm.Rotate(Vector3.up*180);
        }
        trfm.position += trfm.right * spd;
        rock();
    }

    void rock()
    {
        spriteTrfm.Rotate(Vector3.forward * rotate);
        if (spriteTrfm.localEulerAngles.z > 14 && spriteTrfm.localEulerAngles.z < 90) { rotate = -4; }
        if (spriteTrfm.localEulerAngles.z > 346) { rotate = 4; }
    }
}
