using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public GameObject[] enemy;
    public Transform trfm;
    void Start()
    {
        if (Random.Range(0, 2) == 0)
        {
            Instantiate(enemy[Random.Range(0, enemy.Length)], trfm.position + new Vector3(0,2,0), trfm.rotation);
        }
    }
}
