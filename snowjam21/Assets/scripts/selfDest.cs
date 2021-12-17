using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDest : MonoBehaviour
{
    public float life;
    private void Start()
    {
        Destroy(gameObject, life);
    }
}
