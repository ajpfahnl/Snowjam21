using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBlast : MonoBehaviour
{
    public BoxCollider2D boxCol;
    int timer;

    private void FixedUpdate()
    {
        timer++;
        if (timer == 8)
        {
            boxCol.enabled = true;
        }
        if (timer == 27)
        {
            boxCol.enabled = false;
        }
        if (timer == 50)
        {
            Destroy(gameObject);
        }
    }

}
