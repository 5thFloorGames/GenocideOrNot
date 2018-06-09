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
<<<<<<< HEAD
        AudioSource myAudioSource = Instantiate(audioSourcePrefab).GetComponent<AudioSource>();
        float randomPitch = Random.Range(-0.1f, 0.1f); 
        myAudioSource.pitch = pitch + randomPitch;
        myAudioSource.volume = volume;
        myAudioSource.clip = clip;
        myAudioSource.Play();
=======
        if(clip != null){
            AudioSource myAudioSource = Instantiate(audioSourcePrefab).GetComponent<AudioSource>();

            myAudioSource.pitch = pitch;
            myAudioSource.volume = volume;
            myAudioSource.clip = clip;
            myAudioSource.Play();
>>>>>>> 7f5aea512bd5480fcf6430c1ed1bf095686f2e29

            Destroy(myAudioSource.gameObject, myAudioSource.clip.length + waitToDestroy);
        }
    }



}
