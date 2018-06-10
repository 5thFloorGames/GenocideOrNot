using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class LetterByLetter : MonoBehaviour {

	private Text text;
	private string[] lines;
	private int i = 0;
	private int max = 0;
	public Image background;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartTyping(List<string> lines){
		background.enabled = true;
		max = lines.Count;
		this.lines = lines.ToArray();
		StartCoroutine(TypeText(lines[i]));
	}

	IEnumerator TypeText(string line){
		int index = 0;
		string toType = line;
		while (index < toType.Length) {
			index++;
			text.text = toType.Substring (0, index) + "<color=#1110>" + toType.Substring(index) + "</color>";
			yield return new WaitForSeconds (0.03f);
		}
		yield return new WaitForSeconds(0.5f);
		StartCoroutine(EraseText());
		yield return new WaitForSeconds(1f);
		i++;
		if(i < max){
			StartCoroutine(TypeText(lines[i]));
		} else {
			StartCoroutine(EraseText());
			yield return new WaitForSeconds(1f);
			background.enabled = false;
			i = 0;
		}
	}

	IEnumerator EraseText(){
		while(text.text.Length > 3){
			text.text = text.text.Substring(4);
			yield return null;
		}
		text.text = "";
	}

	public void StopTyping(){
		StopAllCoroutines();
		StartCoroutine(EraseText());
		background.enabled = false;
		i = 0;
	}
}
