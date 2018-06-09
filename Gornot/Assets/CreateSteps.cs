using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSteps : MonoBehaviour {

	private GameObject step;
	private GameObject left;
	private GameObject right;
	private bool makingSteps = false;
	private int rayMask = 1;

	// Use this for initialization
	void Start () {
		left = Resources.Load<GameObject>("Art/BetterLeft");
		right = Resources.Load<GameObject>("Art/BetterRight");
		rayMask |= 0 << LayerMask.NameToLayer ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartSteps(){
		StartCoroutine(MakeStep());
	}

	public void StopSteps(){
		StopAllCoroutines();
	}

	IEnumerator MakeStep(){
		while(true){
			RaycastHit hit;
			Physics.Raycast(transform.position, Vector3.down, out hit,5,rayMask);
			GameObject g = Instantiate(left, hit.point, new Quaternion(hit.normal.x, hit.normal.y, hit.normal.z, 1));
			g.transform.Rotate(transform.parent.rotation.eulerAngles + new Vector3(0,-90,0));
			yield return new WaitForSeconds(0.25f);
			Physics.Raycast(transform.position, Vector3.down, out hit,5,rayMask);
			g = Instantiate(right, hit.point, new Quaternion(hit.normal.x, hit.normal.y, hit.normal.z, 1));
			g.transform.Rotate(transform.parent.rotation.eulerAngles + new Vector3(0,-90,0));

			yield return new WaitForSeconds(0.25f);
		}
	}
}
