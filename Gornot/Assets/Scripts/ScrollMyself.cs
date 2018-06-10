using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollMyself : MonoBehaviour {

	ScrollRect scroll;	

	// Use this for initialization
	void Start () {
		scroll = GetComponent<ScrollRect>();
		scroll.velocity = new Vector2(0,10);
	}
	
	// Update is called once per frame
	void Update () {
		print(scroll.velocity);
	}
}
