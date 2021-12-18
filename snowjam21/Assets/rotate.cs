using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public int rotateSpd;
    public Transform trfm;
    private void FixedUpdate()
    {
        trfm.Rotate(Vector3.forward*rotateSpd);
    }
}
