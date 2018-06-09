using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSteps : MonoBehaviour {

	private GameObject step;
	private GameObject left;
	private GameObject right;

	// Use this for initialization
	void Start () {
		left = Resources.Load<GameObject>("Art/BetterLeft");
		right = Resources.Load<GameObject>("Art/BetterRight");
		StartCoroutine(MakeStep());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator MakeStep(){
		while(true){
			Instantiate(left, transform.position + new Vector3(0,-1.5f,0), Quaternion.identity);
			yield return new WaitForSeconds(0.25f);
			Instantiate(right, transform.position + new Vector3(0,-1.5f,0),Quaternion.identity);
			yield return new WaitForSeconds(0.25f);
		}
	}
}
