using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakethingsAppearOnTrigge : MonoBehaviour {

	public GameObject exhibition;

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
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.tag == "Player"){
			exhibition.SetActive(false);
		}
	}
}
