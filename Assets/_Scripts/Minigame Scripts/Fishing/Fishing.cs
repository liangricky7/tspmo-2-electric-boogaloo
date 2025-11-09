using System.Collections;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    [SerializeField]
    private GameObject quickTimePrefab; //game object
    [SerializeField]
    private SpriteRenderer fishingIndicator;
    [SerializeField]
    private Transform fishingSpot;
    private bool fishingActive = false; // is in fishing state, not necessarily in fishing minigame
    private bool isFishing = false; // activated when we spawn quicktime event
    private int chanceToFish = 5; // 1 in X chance each second

    private GameObject playerReference; // reference to player
    private Animator playerAnimator;
    private PlayerMoveInteract playerAnimCheck;

    public AudioSource SoundsSource;
    public AudioClip CastSound;
    public AudioClip ReelSound;

    void Start()
    {
        fishingIndicator.color = new Color(1f, 1f, 1f, 0f);
        playerReference = PlayerManager.Instance.playerReference;
        playerAnimator = playerReference.GetComponent<Animator>();
        playerAnimCheck = playerReference.GetComponent<PlayerMoveInteract>();
        SoundsSource = GetComponent<AudioSource>();

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
        StartCoroutine(PlayCastSound(0.7f));
    }

    void StopFishing()
    {
        playerAnimator.SetInteger("FishingPhase", 0); // reset animation
        StopAllCoroutines();
        isFishing = false;
        fishingActive = false;
        GameManager.Instance.StopState();
        fishingIndicator.color = new Color(1f, 1f, 1f, 0f);
    }

    // exit fishing
    void Update()
    {
        if (fishingActive && Input.GetKeyDown(KeyCode.Q))
        {
            StopFishing();
        }
    }

    IEnumerator FishCheck() // waiting for fish
    {
        // Debug.Log("enter fish check");
        playerAnimator.SetInteger("FishingPhase", 1); // cast line
        while (!isFishing)
        {
            yield return new WaitUntil(() => playerAnimCheck.animationDone == true);
            yield return new WaitForSeconds(1.2f);
            playerAnimator.SetInteger("FishingPhase", 2); // maintain cast line
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
            playerAnimator.SetInteger("FishingPhase", 3); // fight for fish
            SequenceGenerator quickTime = Instantiate(quickTimePrefab, fishingSpot.position, Quaternion.identity).GetComponent<SequenceGenerator>();
            yield return new WaitUntil(quickTime.GetSequencePassed);
            StartCoroutine(PlayReelSound());
            playerAnimator.SetInteger("FishingPhase", 4); // successful catch
            yield return new WaitUntil(() => playerAnimCheck.animationDone == true);
            Debug.Log("Fish caught!");
            StartCoroutine(PlayCastSound(1.4f));
        }
        yield return new WaitForSeconds(0.5f);
        isFishing = false;
        StartCoroutine(FishCheck());
    }

    IEnumerator PlayCastSound(float wait)
    {
        yield return new WaitForSeconds(wait);
        SoundsSource.PlayOneShot(CastSound);
    }

    IEnumerator PlayReelSound()
    {
        yield return new WaitForSeconds(0.1f);
        SoundsSource.PlayOneShot(ReelSound);
    }
}