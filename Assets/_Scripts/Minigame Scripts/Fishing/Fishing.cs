using System.Collections;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    public GameObject quickTimePrefab; //game object
    [SerializeField]
    private SpriteRenderer fishingIndicator;
    [SerializeField]
    private Transform fishingSpot;
    private bool fishingActive = false; // is in fishing state, not necessarily in fishing minigame
    private bool isFishing = false; // activated when we spawn quicktime event
    private int chanceToFish = 5; // 1 in X chance each second

    void Start()
    {
        fishingIndicator.color = new Color(1f, 1f, 1f, 0f);
    }

    void OnEnable()
    {
        // Subscribe when enabled
        GameManager.Instance.FishEvent.AddListener(StartFishing);
    }

    void OnDisable()
    {
        // IMPORTANT: Unsubscribe to prevent memory leaks
        GameManager.Instance.FishEvent.RemoveListener(StartFishing);
    }

    void StartFishing()
    {
        fishingActive = true;
        StartCoroutine(FishCheck());
    }

    // exit fishing
    void Update()
    {
        if (fishingActive && Input.GetKeyDown(KeyCode.Q))
        {
            StopAllCoroutines();
            isFishing = false;
            fishingActive = false;
            GameManager.Instance.StopState();
            fishingIndicator.color = new Color(1f, 1f, 1f, 0f);
        }
    }

    IEnumerator FishCheck() // waiting for fish
    {
        

        Debug.Log("enter fish check");
        while (!isFishing)
        {
            yield return new WaitForSeconds(1f);
            int chance = Random.Range(0, chanceToFish); // independently defined for debugging purposes
            // Debug.Log(chance);
            if (chance == 1)
            {
                isFishing = true;
                StartCoroutine(CatchFish());
            }
        }
    }
    
    IEnumerator CatchFish() // fish appears, player must react and do qt
    {
        float timer = 0f;
        bool fishAccepted = false;
        fishingIndicator.color = new Color(1f, 1f, 1f, 1f);
        while (timer < Random.Range(0.5f, 2f) && !fishAccepted)
        {
            timer += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                fishAccepted = true;
                fishingIndicator.color = new Color(1f, 1f, 1f, 0f);
            }
            yield return null;
        }

        if (!fishAccepted) // fish got away
        {
            Debug.Log("Fish got away!");
            fishingIndicator.color = new Color(1f, 1f, 1f, 0f);
        }
        else
        {
            SequenceGenerator quickTime = Instantiate(quickTimePrefab, fishingSpot.position, Quaternion.identity).GetComponent<SequenceGenerator>();
            yield return new WaitUntil(quickTime.GetSequencePassed);
            Debug.Log("Fish caught!");

        }
        isFishing = false;
        StartCoroutine(FishCheck());

        // GameObject quickTime = Instantiate(quickTimePrefab);

        // Destroy(quickTime);
        // isFishing = false;

        // Return to fishing check
        // StartCoroutine(FishCheck());
    }


}