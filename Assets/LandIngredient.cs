using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandIngredient : MonoBehaviour
{
    string ingredientName = "Land Ingredient";
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void SetIngredientInfo(string name, Sprite sprite)
    {
        ingredientName = name;
        spriteRenderer.sprite = sprite;
    }
}
