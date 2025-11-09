using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject landIngredientPrefab;

    [SerializeField]
    private string [] landNames;

    [SerializeField]
    private Sprite[] landSprites;
    
    private int chanceToSpawn = 4; // 1 in X chance each second

    void Start()
    {
        StartCoroutine(SpawnLandIngredient());
    }

    IEnumerator SpawnLandIngredient()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            int chance = UnityEngine.Random.Range(0, chanceToSpawn); // independently defined for debugging purposes
            if (chance == 1)
            {
                GameObject ingredient = Instantiate(landIngredientPrefab, new Vector3(transform.position.x, transform.position.y + UnityEngine.Random.Range(-3f, 3f), transform.position.z), Quaternion.identity);
                
                // assign random ingredient info
                int randInd = UnityEngine.Random.Range(0, landNames.Length);
                ingredient.GetComponent<LandIngredient>().SetIngredientInfo(landNames[randInd], landSprites[randInd]);
                
                ingredient.GetComponent<Rigidbody2D>().velocity = new Vector2(-4f, 0f);
                yield return new WaitForSeconds(2f); //grace period
            }
        }
    }
}
