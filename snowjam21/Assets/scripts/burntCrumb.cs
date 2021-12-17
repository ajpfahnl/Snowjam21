using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burntCrumb : MonoBehaviour
{
    public bool toast;
    public bool deploy;
    public bool butter;

    public float spd;
    public touchingGround groundScr;
    public Transform spriteTrfm;
    Transform trfm;
    public GameObject crumb;
    public GameObject fireBlast;
    int rotate;
    // Start is called before the first frame update
    void Start()
    {
        rotate = 4;
        trfm = transform;
        if (deploy) { GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-8f,8f),6); }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!gameState.started) { return; }
        if (!groundScr.onGround) 
        {
            groundScr.forceGrounded();
            trfm.Rotate(Vector3.up * 180);
        }
        trfm.position += trfm.right * spd;
        if (!butter) { rock(); }
    }

    void rock()
    {
        spriteTrfm.Rotate(Vector3.forward * rotate);
        if (spriteTrfm.localEulerAngles.z > 14 && spriteTrfm.localEulerAngles.z < 90) { rotate = -4; }
        if (spriteTrfm.localEulerAngles.z > 346) { rotate = 4; }
    }
    private void OnDestroy()
    {
        if (toast)
        {
            Instantiate(crumb, trfm.position, trfm.rotation);
            Instantiate(crumb, trfm.position, trfm.rotation);
        }
        if (butter)
        {
            Instantiate(fireBlast, trfm.position, fireBlast.transform.rotation);
        }
    }
}
