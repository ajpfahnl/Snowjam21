using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorObj : MonoBehaviour
{
    Transform trfm;
    // Start is called before the first frame update
    void Start()
    {
        trfm = transform;
    }

    // Update is called once per frame
    void Update()
    {
        trfm.position = flameThrower.mousePos;
    }
}
