using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakethingsAppearOnTrigge : MonoBehaviour {

	public GameObject exhibition;
    public AudioClip exhibitionOnSFX;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player"){
			exhibition.SetActive(true);
            AudioManager.Instance.playSound(exhibitionOnSFX, gameObject, 0.1f, 0.2f, 0.06f, false, 8);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.tag == "Player"){
			exhibition.SetActive(false);
		}
	}
}
