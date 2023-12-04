using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySounds : MonoBehaviour
{
     public AudioClip[] audioClips; // Array of audio clips
     private AudioSource audioSource; // Reference to the AudioSource component
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoorOpen() {
        audioSource.PlayOneShot(audioClips[1]);
    }
    public void ClickSound() {
        // audioSource.clip = ;
        audioSource.PlayOneShot(audioClips[0]);
    }
        public void TypeWritter() {
        audioSource.clip = audioClips[2];
        audioSource.Play();
    }

    public void StopSound()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
