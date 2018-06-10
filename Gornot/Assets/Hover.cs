using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour {

	public AnimationCurve curve;
	private Vector3 startposition;
	private float time;

	// Use this for initialization
	void Start () {
		startposition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		time = ((time + Time.deltaTime * 0.2f)) % 1;
		transform.localPosition = startposition +  new Vector3(0, curve.Evaluate(time) * 0.1f);
	}
}
