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

    public void ResetSequence()
    {
        sequence = GenerateSequence();
        currentIndex = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        sequence = GenerateSequence();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentIndex >= sequence.Length)
        {
            StartCoroutine(ExitHandler());
        }
        if (sequence[currentIndex] == 0) // left
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                arrowSquares[currentIndex].TurnOff();
                currentIndex++;
            }
        }
        else if (sequence[currentIndex] == 1) // down
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                arrowSquares[currentIndex].TurnOff();
                currentIndex++;
            }
        }
        else if (sequence[currentIndex] == 2) // up
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                arrowSquares[currentIndex].TurnOff();
                currentIndex++;
            }
        }
        else if (sequence[currentIndex] == 3) // right
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                arrowSquares[currentIndex].TurnOff();
                currentIndex++;
            }
        }
    }

    int[] GenerateSequence()
    {
        int length = Random.Range(4, 5);
        int[] newSequence = new int[length];
        arrowSquares = new ArrowSquare[length];

        for (int i = 0; i < newSequence.Length; i++)
        {
            newSequence[i] = Random.Range(0, 3);
            arrowSquares[i] = Instantiate(arrowPrefabs[newSequence[i]], new Vector3((i * 1.2f) - (length * 2f / 5), 0, 0), Quaternion.identity).GetComponent<ArrowSquare>();
            arrowSquares[i].transform.SetParent(transform);
        }
        Debug.Log("Generated sequence: " + string.Join(", ", newSequence));

        return newSequence;
    }
    
    IEnumerator ExitHandler()
    {
        yield return new WaitUntil(arrowSquares[arrowSquares.Length - 1].GetAnimDone);
        Destroy(gameObject);
    }
}
