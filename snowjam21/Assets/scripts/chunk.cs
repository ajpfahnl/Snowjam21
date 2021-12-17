using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chunk : MonoBehaviour
{
    public Transform trfm;
    int y;
    private void Start()
    {
        y = Mathf.RoundToInt(trfm.position.y);
    }
    private void FixedUpdate()
    {
        if (mainCam.trfm.position.y-10 > y) { Destroy(gameObject); }
    }
}
