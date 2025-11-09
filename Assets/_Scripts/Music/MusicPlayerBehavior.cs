using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerBehavior : MonoBehaviour
{
    public AudioSource MusicSource;
    public AudioClip LoopedMusic;
    private bool callLoop = false;
    // Start is called before the first frame update
    void Start()
    {
        MusicSource = GetComponent<AudioSource>();
        StartCoroutine(StartLoop());
    }

    // Update is called once per frame
    void Update()
    {
        if (callLoop)
        {
            callLoop = false;
            StartCoroutine(SustainLoop());
        }
    }

    IEnumerator StartLoop()
    {
        yield return new WaitForSeconds(14.122f);
        MusicSource.PlayOneShot(LoopedMusic);
        callLoop = true;
    }

    IEnumerator SustainLoop()
    {
        yield return new WaitForSeconds(42.622f);
        MusicSource.PlayOneShot(LoopedMusic);
        callLoop = true;
    }
}
