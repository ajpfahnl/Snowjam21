using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCam : MonoBehaviour
{
    public Transform plyrTrfm;
    public static Transform trfm;
    Vector3 pos;

    private void Start()
    {
        trfm = transform;
        pos = new Vector3(0,-7,-10);
    }
    private void FixedUpdate()
    {
        if (gameState.started && !gameState.lost)
        {
            pos.x = (plyrTrfm.position.x - trfm.position.x) * .1f;
            pos.y += .03f;
            trfm.position = pos;

            if(trfm.position.y - plyrTrfm.position.y > 8)
            {
                gameState.doLose();
            }
        } else if (Input.anyKey)
        {
            gameState.doStart();
        }
    }
}
