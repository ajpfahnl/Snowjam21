using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pupIcon : MonoBehaviour
{
    public int ID;

    public SpriteRenderer rend;
    Color alpha = new Color(0,0,0,.05f);
    public Sprite[] pupSprites;

    public int action; //0: nothing; 1: blink

    private void FixedUpdate()
    {
        if (action == 1)
        {
            rend.color += alpha;
            if (rend.color.a >= 1)
            {
                alpha.a = -.05f;
            } else if (rend.color.a <= 0)
            {
                alpha.a = .05f;
            }
        }
    }

    public void setID(int pID)
    {
        ID = pID;
        rend.sprite = pupSprites[ID];
        rend.color = new Color(1,1,1,1);
        action = 0;
    }
    public void blink()
    {
        action = 1;
    }
    public void end()
    {
        rend.sprite = null;
        action = 0;
    }
}
