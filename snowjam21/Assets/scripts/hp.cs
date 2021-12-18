using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp : MonoBehaviour
{
    public int anim; //0: default; 1: lost; 2: restore;

    int timer;
    int cycler;
    public SpriteRenderer rend;
    public Sprite[] normal;
    public Sprite[] lost;
    public Sprite[] restore;
    Transform trfm;
    float yDefault;
    // Start is called before the first frame update
    void Start()
    {
        trfm = transform;
        yDefault = trfm.localPosition.y;
    }

    private void FixedUpdate()
    {
        if (anim == 0)
        {
            rend.sprite = normal[cycler];
            if (doCycle() && cycler >= normal.Length) { cycler = 0; }
        } else if (anim == 1)
        {
            rend.sprite = lost[cycler];
            if (doCycle() && cycler >= lost.Length) { cycler = 0; anim = -1; }
        }
        else if (anim == 2)
        {
            rend.sprite = restore[cycler];
            if (doCycle() && cycler >= restore.Length) { cycler = 0; anim = 0; }
        }
    }
    
    public void loseHP()
    {
        anim = 1;
        cycler = 0;
        trfm.localPosition = new Vector3(trfm.localPosition.x, -.55f + yDefault, 0);
        rend.sprite = lost[0];
    }
    public void recoverHP()
    {
        anim = 2;
        cycler = 0;
        trfm.localPosition = new Vector3(trfm.localPosition.x, yDefault, 0);
        rend.sprite = restore[0];
    }
    
    bool doCycle()
    {
        if (timer > 0) { timer--; return false; }
        else
        {
            timer = 3;
            cycler++;
            return true;
        }
    }
}
