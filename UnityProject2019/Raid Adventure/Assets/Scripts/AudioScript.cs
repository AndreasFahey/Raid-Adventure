using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioClip MusicClip;

    public AudioSource MusicSource;
    // Start is called before the first frame update
    void Start()
    {
        MusicSource.clip = MusicClip;
    }

    // Update is called once per frame
    // This plays the sound when space bar is pressed.
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            MusicSource.Play();
        }
    }
}
