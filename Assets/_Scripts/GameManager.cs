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
    public UnityEvent ExitFishEvent;
    [HideInInspector]
    public UnityEvent ExitStopEvent;
    [HideInInspector]
    public UnityEvent ExitTransitEvent;

    [HideInInspector]
    public enum StateEnum
    {
        // placeholder, // to avoid defaulting to stop
        stop,
        transit,
        fish,
        end,
    }
    [SerializeField] private StateEnum state;
    private StateEnum previousState;

    public static GameManager Instance;

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

    // Update is called once per frame
    void Update()
    {
        if (state != previousState)
        {
            CleanUpStates();

            switch (state)
            {
                case StateEnum.transit:
                    TransitEvent.Invoke();
                    break;
                case StateEnum.stop:
                    StopEvent.Invoke();
                    break;
                case StateEnum.fish:
                    FishEvent.Invoke();
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

    void CleanUpStates()
    {
        // Debug.Log("previous " + previousState);
        switch (previousState)
            {
                case StateEnum.fish:
                    ExitFishEvent.Invoke();
                    break;
                case StateEnum.stop:
                    // Debug.Log("exiting stop state");
                    ExitStopEvent.Invoke();
                    break;    
                case StateEnum.transit:
                    // Debug.Log("exiting stop state");
                    ExitTransitEvent.Invoke();
                    break; 
                default:
                    // Debug.Log("Invalid state found for switch statement in GameManagerBehavior:");
                    // Debug.Log(state);
                    break;
            }
    }

    public StateEnum GetState()
    {
        return state;
    }

    public void StopState()
    {
        state = StateEnum.stop;
    }

    public void TransitState()
    {
        state = StateEnum.transit;
    }

    public void FishState()
    {
        state = StateEnum.fish;
    }
    public void EndState()
    {
        state = StateEnum.end;
    }
}
