using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent menu;
    [HideInInspector]
    public UnityEvent transit;
    [HideInInspector]
    public UnityEvent stop;
    [HideInInspector]
    public UnityEvent fish;
    [HideInInspector]
    public UnityEvent lose;
    [HideInInspector]
    public UnityEvent end;

    enum StateEnum
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
                    menu.Invoke();
                    break;
                case StateEnum.transit:
                    transit.Invoke();
                    break;
                case StateEnum.stop:
                    stop.Invoke();
                    break;
                case StateEnum.fish:
                    fish.Invoke();
                    break;
                case StateEnum.lose:
                    lose.Invoke();
                    break;
                case StateEnum.end:
                    end.Invoke();
                    break;
                default:
                    Debug.Log("Invalid state found for switch statement in GameManagerBehavior:");
                    Debug.Log(state);
                    break;
            }
        }
        previousState = state;
    }

    public void FishState()
    {
        state = StateEnum.menu;
    }
}
