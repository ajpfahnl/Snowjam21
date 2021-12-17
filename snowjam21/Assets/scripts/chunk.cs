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
        if (Random.Range(0, 2) == 0) { trfm.localScale = new Vector3(-7.5f,7.5f,1); }
    }
    private void FixedUpdate()
    {
        if (mainCam.trfm.position.y-10 > y) { Destroy(gameObject); }
    }
}
