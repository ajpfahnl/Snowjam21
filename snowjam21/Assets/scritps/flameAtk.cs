using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flameAtk : MonoBehaviour
{
    public Transform trfm;
    public float spd;
    public Vector3 scale;

    private void Start()
    {
        Destroy(gameObject, .3f);
    }
    private void FixedUpdate()
    {
        trfm.localScale += scale;
        trfm.position += trfm.right * spd;
    }
}
