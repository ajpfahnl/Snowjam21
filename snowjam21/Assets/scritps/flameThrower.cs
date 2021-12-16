using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flameThrower : MonoBehaviour
{
    public static int fuel;
    public static bool overheated;
    public Transform[] rings;
    Vector3 rotation;

    public Transform trfm;
    public static Vector2 mousePos;
    public Camera cam;

    public ParticleSystem ptclSys;
    bool ptclPlaying;
    public GameObject flameObj;

    public Transform backwards;
    int atkTimer;

    private void Start()
    {
        fuel = 200;
        atkTimer = 0;
    }
    private void Update()
    {

    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && !overheated)
        {
            if (fuel > 9)
            {
                if (!ptclPlaying)
                {
                    ptclPlaying = true;
                    ptclSys.Play();
                }
                if (atkTimer > 0)
                {
                    atkTimer--;
                }
                else
                {
                    atkTimer = 3;
                    if (playerMovement.faceRight)
                    {
                        Instantiate(flameObj, trfm.position, trfm.rotation);
                    }
                    else
                    {
                        Instantiate(flameObj, trfm.position, backwards.rotation);
                    }
                }
                fuel -= 10;
            } else
            {
                overheated = true;
            }
        } else
        {
            if (ptclPlaying)
            {
                ptclPlaying = false;
                ptclSys.Stop();
            }
        }
        if (fuel < 200)
        {
            fuel+=2;
            rotation.z = fuel/200f*180;
            rings[0].localEulerAngles = rotation;
            rotation.z = 360 - fuel/200f*180;
            rings[1].localEulerAngles = rotation;
        } else
        {
            if (overheated) { overheated = false; }
        }

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (playerMovement.faceRight)
        {
            trfm.rotation = Quaternion.AngleAxis(Mathf.Atan2(trfm.position.y - mousePos.y, trfm.position.x - mousePos.x) * Mathf.Rad2Deg + 180, Vector3.forward);
        } else
        {
            trfm.rotation = Quaternion.AngleAxis(Mathf.Atan2(trfm.position.y - mousePos.y, trfm.position.x - mousePos.x) * Mathf.Rad2Deg, Vector3.forward);
        }
    }
}
