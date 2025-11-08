using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent startGame;
    public UnityEvent transit;
    public UnityEvent stop;
    public UnityEvent gator;
    public UnityEvent fish;
    public UnityEvent fail;
    public UnityEvent end;

    enum DebugStateEnum
    {
        startGame,
        transit,
        stop,
        gator,
        fish,
        fail,
        end,
    }
    [SerializeField] private DebugStateEnum debugState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (debugState)
        {
            case DebugStateEnum.startGame:
                startGame.Invoke();
                break;
            case DebugStateEnum.transit:
                transit.Invoke();
                break;
            case DebugStateEnum.stop:
                stop.Invoke();
                break;
            case DebugStateEnum.gator:
                gator.Invoke();
                break;
            case DebugStateEnum.fish:
                fish.Invoke();
                break;
            case DebugStateEnum.fail:
                fail.Invoke();
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
}
