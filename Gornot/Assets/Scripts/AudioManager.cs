using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager Instance;
    public GameObject audioSourcePrefab;
    private FloorMaterial material;
    [SerializeField] private AudioClip[] m_FootstepSounds;
    [SerializeField] private AudioClip[] m_FootstepSoundsSand;
    [SerializeField] private AudioClip[] m_FootstepSoundsSnow;
    [SerializeField] private AudioClip[] m_FootstepSoundsLSD;


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
        Instance.playSound(imaginaryMusic, gameObject, 1f, 1f, 0.2f, true, 6);
    }

    public void ChangeMaterial(FloorMaterial material){
        this.material = material;
    }

    public void StepSound(){
        AudioClip[] steps;
        if (material == FloorMaterial.Sand)
        {
            steps = m_FootstepSoundsSand; // sandrray
        }
        else if (material == FloorMaterial.Snow)
        {
            steps = m_FootstepSoundsSnow;
        } // snowarray
        else if (material == FloorMaterial.Snow)
        {
            steps = m_FootstepSoundsLSD; // snowarray

        }
        else
        {
            steps = m_FootstepSounds; // normalarray
        }
        PlaySoundFromArray(steps);
    }

    private void PlaySoundFromArray(AudioClip[] array){
        if(array.Length == 0){
            return;
        }
        int n = Random.Range(1, array.Length);
        AudioClip footstepsClip = array[n];
        Instance.playSound(footstepsClip, gameObject, 0.2f, 0.4f, 0.08f, false, 3);
        array[n] = m_FootstepSounds[0];
        array[0] = footstepsClip;
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
