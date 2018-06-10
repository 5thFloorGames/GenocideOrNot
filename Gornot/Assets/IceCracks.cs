using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCracks : MonoBehaviour {

	public Material[] materials;
	private MeshRenderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<MeshRenderer>();
		StartCoroutine(Crack());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Crack(){
		int i = 0;
		while(i < materials.Length){
			rend.material = materials[i];
			yield return new WaitForSeconds(3);
		}
	}
}
