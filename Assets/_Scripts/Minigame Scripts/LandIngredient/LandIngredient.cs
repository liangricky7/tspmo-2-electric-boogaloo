using UnityEngine;

public class LandIngredient : MonoBehaviour
{
    public string ingredientName = "Land Ingredient";
    [SerializeField]
    SpriteRenderer ingredientSpriteRenderer;

    public void SetIngredientInfo(string name, Sprite sprite)
    {
        ingredientName = name;
        ingredientSpriteRenderer.sprite = sprite;
    }
}
