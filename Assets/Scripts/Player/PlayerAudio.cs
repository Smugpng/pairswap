using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] hitSound, lowHpSound, dashSound;
    // Start is called before the first frame update
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Dmg()
    {
        audioSource.clip = hitSound[Random.Range(0,hitSound.Length)];
        audioSource.Play();
    }
    public void low()
    {
        audioSource.clip = lowHpSound[Random.Range(0, lowHpSound.Length)];
        audioSource.Play();
    }
    public void dash()
    {
        audioSource.clip = dashSound[Random.Range(0, dashSound.Length)];
        audioSource.Play();
    }

}
