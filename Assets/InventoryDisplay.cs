using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    // 0 -> Onion, 1 -> Pepper, 2 -> Celery, 3 -> Garlic, 4 -> Chicken
    // 5 -> Shrimp, 6 -> Fish, 7 -> Crab

    public Sprite checkmarkSprite;
    public Sprite xmarkSprite;

    public bool[] hasIngredients = new bool[8];
    public SpriteRenderer[] ingredientSRs = new SpriteRenderer[8];
    public SpriteRenderer[] ingredientChecks = new SpriteRenderer[8];

    void Start()
    {
        for (int i = 0; i < ingredientSRs.Length; i++)
        {
            ingredientSRs[i] = transform.GetChild(1).GetChild(i).GetComponent<SpriteRenderer>();
            Debug.Log(transform.GetChild(1).GetChild(i).name);
            Debug.Log(ingredientSRs[i]);

        }
        for (int i = 0; i < ingredientChecks.Length; i++)
        {
            ingredientChecks[i] = transform.GetChild(2).GetChild(i).GetComponent<SpriteRenderer>();
            ingredientChecks[i].sprite = xmarkSprite;
        }
    }

    public void CheckOff(string ingredientName)
    {
        int index = -1;
        switch (ingredientName.ToLower())
        {
            case "onion":
                index = 0;
                break;
            case "pepper":
                index = 1;
                break;
            case "celery":
                index = 2;
                break;
            case "garlic":
                index = 3;
                break;
            case "chicken":
                index = 4;
                break;
            case "shrimp":
                index = 5;
                break;
            case "fish":
                index = 6;
                break;
            case "crab":
                index = 7;
                break;
            default:
                Debug.LogWarning("Unknown ingredient: " + ingredientName);
                return;
        }

        if (index < 0 || index >= hasIngredients.Length) return;

        hasIngredients[index] = true;
        ingredientSRs[index].sprite = checkmarkSprite;
        // Color checkColor = ingredientChecks[index].color;
        // checkColor.a = 1f; // Make the checkmark fully visible
        // ingredientChecks[index].color = checkColor;
    }

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
