using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flameAtk : MonoBehaviour
{
    public bool big;
    public Transform trfm;
    public float spd;
    public Vector3 scale;

    private void Start()
    {
        mainCam.addTrauma(20);
        if (big) { Destroy(gameObject, .8f); }
        else { Destroy(gameObject, .4f); }
    }
    private void FixedUpdate()
    {
        trfm.localScale += scale;
        trfm.position += trfm.right * spd;
    }
}
