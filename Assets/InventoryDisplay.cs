using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    public bool hasOnion = false;
    public bool hasPepper = false;
    public bool hasCelery = false;
    public bool hasGarlic = false;
    public bool hasChicken = false;
    public bool hasShrimp = false;
    public bool hasFish = false;
    public bool hasCrab = false;

    public SpriteRenderer onionSR;
    public SpriteRenderer onionCheck;

    public SpriteRenderer pepperSR;
    public SpriteRenderer pepperCheck;

    public SpriteRenderer celerySR;
    public SpriteRenderer celeryCheck;

    public SpriteRenderer garlicSR;
    public SpriteRenderer garlicCheck;

    public SpriteRenderer chickenSR;
    public SpriteRenderer chickenCheck;

    public SpriteRenderer shrimpSR;
    public SpriteRenderer shrimpCheck;

    public SpriteRenderer fishSR;
    public SpriteRenderer fishCheck;

    public SpriteRenderer crabSR;
    public SpriteRenderer crabCheck;

    /*public void CheckOff()
    {
        if (hasOnion)
        {
            onionSR.m_Color = color.white;
            onionCheck.m_Color.a = 0;
        }
        if (hasPepper)
        {
            pepperSR.m_Color = color.white;
            pepperCheck.m_Color.a = 0;
        }
        if (hasCelery)
        {
            celerySR.m_Color = color.white;
            celeryCheck.m_Color.a = 0;
        }
        if (hasGarlic)
        {
            garlicSR.m_Color = color.white;
            garlicCheck.m_Color.a = 0;
        }
        if (hasChicken)
        {
            chickenSR.m_Color = color.white;
            chickenCheck.m_Color.a = 0;
        }
        if (hasShrimp)
        {
            shrimpSR.m_Color = color.white;
            shrimpCheck.m_Color.a = 0;
        }
        if (hasFish) 
        {
            fishSR.m_Color = color.white;
            fishCheck.m_Color.a = 0;
        }
        if (hasCrab)
        {
            crabSR.m_Color = color.white;
            crabCheck.m_Color.a = 0;
        }
    }*/
}
