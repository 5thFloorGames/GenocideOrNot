using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager Instance;
    public GameObject audioSourcePrefab;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void playSound (AudioClip clip, GameObject objectToPlayOn, float pitch, float volume, int waitToDestroy = 5)
    {
        if(clip != null){
            AudioSource myAudioSource = Instantiate(audioSourcePrefab).GetComponent<AudioSource>();

            myAudioSource.pitch = pitch;
            myAudioSource.volume = volume;
            myAudioSource.clip = clip;
            myAudioSource.Play();

            Destroy(myAudioSource.gameObject, myAudioSource.clip.length + waitToDestroy);
        }
    }



}
