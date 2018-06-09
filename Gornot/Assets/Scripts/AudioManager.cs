using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager Instance;
    public GameObject audioSourcePrefab;

    public AudioClip imaginaryMusic;

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

    public void Start()
    {
        AudioManager.Instance.playSound(imaginaryMusic, gameObject, 1f, 1f, 0.2f, true, 6);
    }

    public void playSound (AudioClip clip, GameObject objectToPlayOn, float volume, float pitch, float randomRange, bool loop, int waitToDestroy = 5)
    {
        if(clip != null){
            AudioSource myAudioSource = Instantiate(audioSourcePrefab).GetComponent<AudioSource>();
            float randomPitch = Random.Range(randomRange * -1, randomRange);
            myAudioSource.pitch = pitch + randomPitch;
            myAudioSource.volume = volume;
            myAudioSource.loop = loop;
            myAudioSource.clip = clip;
            myAudioSource.Play();

            Destroy(myAudioSource.gameObject, myAudioSource.clip.length + waitToDestroy);
        }
    }

    public void stopSound (string soundToStop, int waitToDestroy = 5)
    {
        GameObject soundToStopObject = GameObject.Find(soundToStop);
        soundToStopObject.GetComponent<AudioSource>().Stop();
        Destroy(soundToStopObject, waitToDestroy);
    }

}
