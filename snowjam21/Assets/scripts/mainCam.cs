using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCam : MonoBehaviour
{
    public Transform plyrTrfm;
    public static mainCam camScr;
    public static Transform trfm;
    Vector3 pos;
    float trauma;

    public Camera cam;
    public Transform hpTrfm;
    public Transform pupIconTrfm;
    public Transform score;

    public Transform bckgrnd;
    Vector3 bckgrndPos;

    public static float riseRate;

    public int width;
    public float scaler;

    bool every2;

    private void Awake()
    {
        camScr = GetComponent<mainCam>();
        riseRate = .03f;
    }
    private void Start()
    {
        trfm = transform;
        pos = new Vector3(0,-7,-10);
        bckgrndPos = bckgrnd.position;

        Vector3 hpPos = cam.WorldToViewportPoint(trfm.position);
        hpPos.x = Mathf.Clamp01(0.02f);
        hpPos.y = Mathf.Clamp01(0.02f);
        hpPos.z = 10;
        hpTrfm.position = cam.ViewportToWorldPoint(hpPos);
        hpPos.x = Mathf.Clamp01(0.98f);
        pupIconTrfm.position = cam.ViewportToWorldPoint(hpPos);
        hpPos.x = Mathf.Clamp01(0.02f);
        hpPos.y = Mathf.Clamp01(0.98f);
        score.position = cam.ViewportToWorldPoint(hpPos);
    }
    private void FixedUpdate()
    {
        if (every2)
        {
            bckgrndPos.y = (trfm.position.y + 6)/1.3f + 81;
            bckgrnd.position = bckgrndPos;
        }
        every2 = !every2;

        if (gameState.started && !gameState.lost)
        {
            traumaSystem();
            pos.x = (plyrTrfm.position.x - trfm.position.x) * .1f;
            pos.y += riseRate;
            trfm.position = pos;
            
        } else if (Input.anyKey && !gameState.lost)
        {
            gameState.doStart();
        }
    }

    public static void addTrauma(float pTrauma)
    {
        if (camScr.trauma < pTrauma)
        {
            float tempTrauma = pTrauma;
            pTrauma -= (pTrauma - camScr.trauma);
            camScr.trauma = tempTrauma;
            camScr.trauma += pTrauma / 5;
        }
        else
        {
            camScr.trauma += pTrauma / 5;
        }
    }

    float zAngle;
    Vector3 recalibrate;
    void traumaSystem()
    {
        if (trauma > 0)
        {
            trauma -= 1;
            trfm.position += new Vector3(Random.Range(-trauma / 120, trauma / 120), Random.Range(-trauma / 80, trauma / 80), 0);
            trfm.Rotate(Vector3.forward * Random.Range(-trauma / 20, trauma / 20));
        }
        zAngle = trfm.localEulerAngles.z;
        if (zAngle > .3f && zAngle < 180)
        {
            trfm.Rotate(Vector3.forward * -.5f);
        }
        if (zAngle > 180 && zAngle < 359.5f)
        {
            trfm.Rotate(Vector3.forward * .5f);
        }

        recalibrate.x = -trfm.position.x / 10;
        recalibrate.y = -trfm.position.y / 10;
        trfm.position += recalibrate;
    }
}
