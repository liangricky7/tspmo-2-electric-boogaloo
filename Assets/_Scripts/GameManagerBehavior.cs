using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent MenuEvent;
    [HideInInspector]
    public UnityEvent TransitEvent;
    [HideInInspector]
    public UnityEvent StopEvent;
    [HideInInspector]
    public UnityEvent FishEvent;
    [HideInInspector]
    public UnityEvent LoseEvent;
    [HideInInspector]
    public UnityEvent EndEvent;

    [HideInInspector]
    public enum StateEnum
    {
        menu,
        transit,
        stop,
        fish,
        lose,
        end,
    }
    [SerializeField] private StateEnum state;
    private StateEnum previousState;

    public GameObject gatorObject;

    public static GameManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (state != previousState)
        {
            switch (state)
            {
                case StateEnum.menu:
                    MenuEvent.Invoke();
                    break;
                case StateEnum.transit:
                    TransitEvent.Invoke();
                    break;
                case StateEnum.stop:
                    StopEvent.Invoke();
                    break;
                case StateEnum.fish:
                    FishEvent.Invoke();
                    break;
                case StateEnum.lose:
                    LoseEvent.Invoke();
                    break;
                case StateEnum.end:
                    EndEvent.Invoke();
                    break;
                default:
                    Debug.Log("Invalid state found for switch statement in GameManagerBehavior:");
                    Debug.Log(state);
                    break;
            }
        }
        previousState = state;
    }

    public StateEnum GetState()
    {
        return state;
    }

    public void FishState()
    {
        state = StateEnum.fish;
    }
}
