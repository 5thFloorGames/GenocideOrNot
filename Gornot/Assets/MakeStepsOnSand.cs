using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeStepsOnSand : MonoBehaviour {

	private CreateSteps steps; 

	// Use this for initialization
	void Start () {
		steps = FindObjectOfType<CreateSteps>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player"){
			steps.StartSteps();
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.tag == "Player"){
			steps.StopSteps();
		}
	}

}
