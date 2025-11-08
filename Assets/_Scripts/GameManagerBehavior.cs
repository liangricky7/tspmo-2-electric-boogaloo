using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent menu;
    public UnityEvent transit;
    public UnityEvent stop;
    public UnityEvent fish;
    public UnityEvent lose;
    public UnityEvent end;

    enum DebugStateEnum
    {
        menu,
        transit,
        stop,
        fish,
        lose,
        end,
    }
    [SerializeField] private DebugStateEnum debugState;
    private DebugStateEnum previousDebugState;

    public GameObject gatorObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Inputs
        if (Input.GetKeyDown("1"))
        {
            debugState = DebugStateEnum.menu;
        }
        if (Input.GetKeyDown("2"))
        {
            debugState = DebugStateEnum.transit;
        }
        if (Input.GetKeyDown("3"))
        {
            debugState = DebugStateEnum.stop;
        }
        if (Input.GetKeyDown("4"))
        {
            debugState = DebugStateEnum.fish;
        }
        if (Input.GetKeyDown("5"))
        {
            debugState = DebugStateEnum.lose;
        }
        if (Input.GetKeyDown("6"))
        {
            debugState = DebugStateEnum.end;
        }

        if (debugState != previousDebugState)
        {
            switch (debugState)
            {
                case DebugStateEnum.menu:
                    menu.Invoke();
                    break;
                case DebugStateEnum.transit:
                    transit.Invoke();
                    break;
                case DebugStateEnum.stop:
                    stop.Invoke();
                    break;
                case DebugStateEnum.fish:
                    fish.Invoke();
                    break;
                case DebugStateEnum.lose:
                    lose.Invoke();
                    break;
                case DebugStateEnum.end:
                    end.Invoke();
                    break;
                default:
                    Debug.Log("Invalid state found for switch statement in GameManagerBehavior:");
                    Debug.Log(debugState);
                    break;
            }
        }
        previousDebugState = debugState;
    }
}
