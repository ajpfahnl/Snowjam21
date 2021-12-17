using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{
    public static int points;
    public Transform plyrTrfm;
    int threshold;

    public Transform scoreboardTrfm;
    public SpriteRenderer[] numRends;
    bool passedTens, passedHunds;
    public Sprite[] faNums;

    public static score scoreScr;

    void Start()
    {
        scoreScr = GetComponent<score>();
        threshold = 5;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (plyrTrfm.position.y*2 > threshold)
        {
            threshold += 5;
            addPoint();
        }
    }
    public static void addPoint()
    {
        points++;
        scoreScr.incrPoint();
    }
    public void incrPoint()
    {
        setSprite(0,points%10);
        if (!passedHunds)
        {
            if (!passedTens)
            {
                if (points > 9)
                {
                    passedTens = true;
                    numRends[1].enabled = true;
                    scoreboardTrfm.localPosition = new Vector3(.3f,4.4f,10);
                    setSprite(1, points%100/10);
                }
            } else
            {
                setSprite(1, points % 100 / 10);
                if (points > 99)
                {
                    passedHunds = true;
                    numRends[2].enabled = true;
                    scoreboardTrfm.localPosition = new Vector3(.6f, 4.4f, 10);
                    setSprite(2, points / 100);
                }
            }
        } else
        {
            setSprite(1, points % 100 / 10);
            setSprite(2, points / 100);
        }
        
    }
    void setSprite(int index, int pts)
    {
        numRends[index].sprite = faNums[pts];
    }
}