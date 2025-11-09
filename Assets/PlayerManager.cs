using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    public GameObject playerReference;
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
}
