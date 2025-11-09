using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatInteraction : MonoBehaviour
{
    [SerializeField] private Alligator alligator;

    public AudioSource SoundSource;
    private bool soundMuted = true;
    void Update()
    {
        SoundSource.mute = soundMuted;
        if (GameManager.Instance.GetState() == GameManager.StateEnum.stop && Input.GetKeyDown(KeyCode.W)) // start boat
        {
            soundMuted = false;
            if (alligator.isAttacking)
            {
                // Debug.Log("Gator on boat! Can't start!");
                return; // maybe indicate you need to get the gator off of the boat
            }
            // Debug.Log("Starting Transit");
            GameManager.Instance.TransitState();
        }
        else if (GameManager.Instance.GetState() == GameManager.StateEnum.transit && Input.GetKeyDown(KeyCode.S)) // stop boat
        {
            soundMuted = true;
            GameManager.Instance.StopState();
        }
        
    }
}
