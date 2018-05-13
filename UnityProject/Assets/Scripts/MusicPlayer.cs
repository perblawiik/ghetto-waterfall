using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    public AudioClip[] clips;
    public AudioSource audioSource;

	// Use this for initialization
	void Start () {
        clips = Resources.LoadAll<AudioClip>("Music");
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
		
	}

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = clips[Random.Range(0, clips.Length)];
            audioSource.Play();
        }
    }
}
