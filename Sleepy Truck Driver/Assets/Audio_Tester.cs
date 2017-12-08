using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Tester : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        AudioSource[] audios = GetComponents<AudioSource>();
        foreach (var audio in audios)
        {
            audio.loop = true;
            audio.Play();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
