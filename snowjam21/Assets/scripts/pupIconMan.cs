using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pupIconMan : MonoBehaviour
{
    //0: jelly; 1: peanut butter; 2: cheese; 3: butter; 4: avocado
    int powerups;
    public pupIcon[] pupScr;
    // Start is called before the first frame update
    
    public void addPowerup(int ID)
    {
        for (int i = 0; i < powerups; i++)
        {
            if (pupScr[i].ID == ID) { pupScr[i].setID(ID); return; }
        }
        for (int i = powerups; i > 0; i--)
        {
            pupScr[i].setID(pupScr[i-1].ID);
            pupScr[i].action = pupScr[i - 1].action;
        }
        pupScr[0].setID(ID);
        powerups++;
    }
    public void blinkPowerup(int ID)
    {
        for (int i = 0; i < powerups; i++)
        {
            if (pupScr[i].ID == ID) { pupScr[i].blink(); }
        }
    }
    public void endPowerup(int ID)
    {
        for (int i = 0; i < powerups; i++)
        {
            if (pupScr[i].ID == ID)
            {
                for (int j = i; j < powerups-1; j++)
                {
                    pupScr[i].setID(pupScr[i + 1].ID);
                    pupScr[i].action = pupScr[i + 1].action;
                }
                pupScr[powerups - 1].end();
                powerups--;
            }
        }
    }
}
