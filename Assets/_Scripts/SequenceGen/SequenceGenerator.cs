using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SequenceGenerator : MonoBehaviour
{
    [SerializeField]
    private Object[] arrowPrefabs;
    private ArrowSquare[] arrowSquares;
    int[] sequence;
    int currentIndex = 0;
    bool sequencePassed = false;

    public AudioSource SoundSource;
    public AudioClip KeypressSound;
    [SerializeField] private float soundVolume = 1f;

    public void ResetSequence()
    {
        sequence = GenerateSequence();
        currentIndex = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        sequence = GenerateSequence();
        SoundSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentIndex >= sequence.Length)
        {
            StartCoroutine(ExitHandler());
        }
        if (currentIndex < sequence.Length && sequence[currentIndex] == 0) // left
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                arrowSquares[currentIndex].TurnOff();
                currentIndex++;
                SoundSource.PlayOneShot(KeypressSound, soundVolume);
            }
            else if (Input.anyKeyDown)
            {
                arrowSquares[currentIndex].Wrong();
                for (int i = 0; i < arrowSquares.Length; i++)
                {
                    arrowSquares[i].TurnOn();
                }
                currentIndex = 0;
            }
        }
        else if (currentIndex < sequence.Length && sequence[currentIndex] == 1) // down
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                arrowSquares[currentIndex].TurnOff();
                currentIndex++;
                SoundSource.PlayOneShot(KeypressSound, soundVolume);
            }
            else if (Input.anyKeyDown)
            {
                arrowSquares[currentIndex].Wrong();
                for (int i = 0; i < arrowSquares.Length; i++)
                {
                    arrowSquares[i].TurnOn();
                }
                currentIndex = 0;
            }
        }
        else if (currentIndex < sequence.Length && sequence[currentIndex] == 2) // up
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                arrowSquares[currentIndex].TurnOff();
                currentIndex++;
                SoundSource.PlayOneShot(KeypressSound, soundVolume);
            }
            else if (Input.anyKeyDown)
            {
                arrowSquares[currentIndex].Wrong();
                for (int i = 0; i < arrowSquares.Length; i++)
                {
                    arrowSquares[i].TurnOn();
                }
                currentIndex = 0;
            }
        }
        else if (currentIndex < sequence.Length && sequence[currentIndex] == 3) // right
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                arrowSquares[currentIndex].TurnOff();
                currentIndex++;
                SoundSource.PlayOneShot(KeypressSound, soundVolume);
            }
            else if (Input.anyKeyDown)
            {
                arrowSquares[currentIndex].Wrong();
                for (int i = 0; i < arrowSquares.Length; i++)
                {
                    arrowSquares[i].TurnOn();
                }
                currentIndex = 0;
            }
        }
    }

    int[] GenerateSequence()
    {
        int length = Random.Range(4, 7);
        int[] newSequence = new int[length];
        arrowSquares = new ArrowSquare[length];

        for (int i = 0; i < newSequence.Length; i++)
        {
            newSequence[i] = Random.Range(0, 3);
            arrowSquares[i] = Instantiate(arrowPrefabs[newSequence[i]], new Vector3(transform.position.x +  (i * 0.8f) - (length * 1.65f / 5), transform.position.y, 0), Quaternion.identity).GetComponent<ArrowSquare>();
            arrowSquares[i].transform.SetParent(transform);
        }
        Debug.Log("Generated sequence: " + string.Join(", ", newSequence));

        return newSequence;
    }

    IEnumerator ExitHandler()
    {
        yield return new WaitUntil(arrowSquares[arrowSquares.Length - 1].GetAnimDone);
        sequencePassed = true;

        // hard coded check for land ingredient
        LandIngredient ingredientData = null;
        if (gameObject.TryGetComponent(out ingredientData))
        {
            InventoryDisplay.Instance.CheckOff(ingredientData.ingredientName);
        }

        Destroy(gameObject);
    }
    
    public bool GetSequencePassed()
    {
        return sequencePassed;
    }
}
