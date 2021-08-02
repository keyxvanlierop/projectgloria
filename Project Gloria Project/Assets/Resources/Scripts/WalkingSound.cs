using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSound : MonoBehaviour
{

    public AudioSource walking;
    public AudioSource running;
    bool playing;
    float randomPitch;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {

            if (playing == false)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    StartCoroutine("playRunning");
                }
                else {
                    StartCoroutine("playFootStep");
                }
                
            }

        }
    }

    IEnumerator playFootStep()
    {
        playing = true;
        // Pick a random footstep sound to play
        //randomFootStep = Mathf.Floor(Random.Range(0, footStepAudioClips.Length));
        //footStepAudioSource.clip = footStepAudioClips[(int)randomFootStep];

        // Pick a random pitch to play it at
        randomPitch = Random.Range(1, 3);
        walking.pitch = (int)randomPitch;

        // Play the sound
        walking.Play();
        yield return new WaitForSeconds(walking.clip.length);
        playing = false;
    }

    IEnumerator playRunning()
    {
        playing = true;
        // Pick a random footstep sound to play
        //randomFootStep = Mathf.Floor(Random.Range(0, footStepAudioClips.Length));
        //footStepAudioSource.clip = footStepAudioClips[(int)randomFootStep];

        // Pick a random pitch to play it at
        randomPitch = Random.Range(1, 3);
        running.pitch = (int)randomPitch;

        // Play the sound
        running.Play();
        yield return new WaitForSeconds(running.clip.length);
        playing = false;
    }
}
