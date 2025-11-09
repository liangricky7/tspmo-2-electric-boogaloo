using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    // 0 -> Onion, 1 -> Pepper, 2 -> Celery, 3 -> Garlic
    // 4 -> Shrimp, 5 -> Catish, 6 -> Crab

    public Sprite checkmarkSprite;
    public Sprite xmarkSprite;
    bool openMenu = false;
    public bool[] hasIngredients = new bool[7];
    public SpriteRenderer[] ingredientSRs = new SpriteRenderer[7];
    public SpriteRenderer[] ingredientChecks = new SpriteRenderer[7];

    public static InventoryDisplay Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            // Destroy duplicate instances
            Destroy(gameObject);
        }
        else
        {
            Instance = this; // Assign the current instance
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        for (int i = 0; i < ingredientSRs.Length; i++)
        {
            ingredientSRs[i] = transform.GetChild(1).GetChild(i).GetComponent<SpriteRenderer>();
            // Debug.Log(transform.GetChild(1).GetChild(i).name);
            // Debug.Log(ingredientSRs[i]);
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
            case "bell pepper":
                index = 1;
                break;
            case "celery":
                index = 2;
                break;
            case "garlic":
                index = 3;
                break;
            case "shrimp":
                index = 4;
                break;
            case "catfish":
                index = 5;
                break;
            case "crab":
                index = 6;
                break;
            default:
                Debug.LogWarning("Unknown ingredient: " + ingredientName);
                return;
        }

        if (index < 0 || index >= hasIngredients.Length) return;

        hasIngredients[index] = true;
        ingredientChecks[index].sprite = checkmarkSprite;
        // Color checkColor = ingredientChecks[index].color;
        // checkColor.a = 1f; // Make the checkmark fully visible
        // ingredientChecks[index].color = checkColor;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            openMenu = !openMenu;
            if (openMenu)
            {
                transform.position -= new Vector3(4.18f, 0f, 0f);
            }
            else
            {
                transform.position += new Vector3(4.18f, 0f, 0f);
            }
        }

        if (CheckWin())
        {
            GameManager.Instance.EndState();
        }
    }
    
    bool CheckWin()
    {
        foreach (bool b in hasIngredients)
        {
            if (!b)
                return false;
        }
        return true;
        
    }
}
