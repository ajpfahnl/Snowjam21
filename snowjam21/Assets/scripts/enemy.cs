using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int hp;
    public Transform trfm;
    public GameObject death;
    
    void Start()
    {
        trfm = transform;
        trfm.parent = null;
    }

    // Update is called once per frame


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 9)
        {
            Instantiate(death, trfm.position, trfm.rotation);
            Destroy(gameObject);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == 7)
        {
            Destroy(col.gameObject);
            gameState.doLose();
        }
    }
}
