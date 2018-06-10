using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterABit : MonoBehaviour {

	private MeshRenderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponentInChildren<MeshRenderer>();
		StartCoroutine(FadeOut());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator FadeOut(){
		yield return new WaitForSeconds(6);
		// while(rend.material.color.a > 0){
		// 	rend.material.color = new Color(
		// 		rend.material.color.r,
		// 		rend.material.color.g,
		// 		rend.material.color.b,
		// 		rend.material.color.a - 0.01f
		// 	);
		// 	yield return null;
		// }
		Destroy(gameObject);
	}
}
