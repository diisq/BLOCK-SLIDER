using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSounds : MonoBehaviour
{
    public AudioSource footstepsSound, sprintSound;
    public float pitchMin = 0.8f;
    public float pitchMax = 1.2f;
    private float threshold = 0.1f; // Time close to end to detect loop
    private bool footstepsPitchChanged = false;
    private bool sprintPitchChanged = false;

    void Update()
    {
        bool pressingKeys = Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0;
        bool running = Input.GetKey(KeyCode.LeftShift);

        footstepsSound.enabled = pressingKeys && !running;
        sprintSound.enabled = pressingKeys && running;

        // Apply pitch change to footsteps sound
        if (footstepsSound.isPlaying)
        {
            float clipLength = footstepsSound.clip.length;

            if (footstepsSound.time >= clipLength - threshold)
            {
                if (!footstepsPitchChanged) // Only change pitch once per loop
                {
                    ChangePitch(footstepsSound);
                    footstepsPitchChanged = true;
                }
            }
            else
            {
                footstepsPitchChanged = false;
            }
        }

        // Apply pitch change to sprint sound
        if (sprintSound.isPlaying)
        {
            float clipLength = sprintSound.clip.length;

            if (sprintSound.time >= clipLength - threshold)
            {
                if (!sprintPitchChanged) // Only change pitch once per loop
                {
                    ChangePitch(sprintSound);
                    sprintPitchChanged = true;
                }
            }
            else
            {
                sprintPitchChanged = false;
            }
        }
    }

    // Method to change the pitch without affecting the tempo
    private void ChangePitch(AudioSource audioSource)
    {
        // Store the current timeSample position
        int currentSample = audioSource.timeSamples;

        // Set the new pitch value
        audioSource.pitch = Random.Range(pitchMin, pitchMax);

        // Reset the timeSample to the previously stored position to avoid tempo changes
        audioSource.timeSamples = currentSample;
    }
}
