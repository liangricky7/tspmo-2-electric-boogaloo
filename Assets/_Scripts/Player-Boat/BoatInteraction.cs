using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatInteraction : MonoBehaviour
{
    [SerializeField] private Alligator alligator;

    public AudioSource SoundSource; //License for sound used: Motorboat canoe in the river with water flow, splash and flapping, microphone close to the water, loud motor, slowing sometimes and subtle voices sometimes in Amazon rainforest by felix.blume -- https://freesound.org/s/672806/ -- License: Creative Commons 0
    private bool soundMuted = true;
    void Update()
    {
        SoundSource.mute = soundMuted;
        if (GameManager.Instance.GetState() == GameManager.StateEnum.stop && Input.GetKeyDown(KeyCode.W)) // start boat
        {
            GameManager.Instance.EndState();
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
