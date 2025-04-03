using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class RandomSong : MonoBehaviour
{
    public AudioClip[] songs;
    private void Start()
    {
        AudioSource source = GetComponent<AudioSource>();
        source.clip = songs[Random.Range(0,songs.Length)];
        source.Play();
    }
}
