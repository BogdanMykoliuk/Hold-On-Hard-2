using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float multiplyVolume = 1f;
    public static float distanceToHearSounds = 7f;

    private AudioSource trapAudioSource;
    private Transform characterTransform;
    private Vector2 trapPosition;

    private void Awake()
    {  
        trapAudioSource = GetComponent<AudioSource>();
        trapPosition = (Vector2)GetComponent<Transform>().position;
        characterTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        trapAudioSource.volume = 0;
    }

    private void FixedUpdate()
    {
        float dist = Vector2.Distance(trapPosition, characterTransform.position);
        if (dist < distanceToHearSounds)
        {
            trapAudioSource.volume = (1.3f - dist / distanceToHearSounds) * multiplyVolume;
        }
        else {
            trapAudioSource.volume = 0;
        }
        
    }

    public void PlayAudioClip() {
        trapAudioSource.Play();
    }
}
