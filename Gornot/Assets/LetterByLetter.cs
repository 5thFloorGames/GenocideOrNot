using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class LetterByLetter : MonoBehaviour {

	private Text UItext;
	private string[] lines;
	private int i = 0;
	private int max = 0;
	public Image background;
	public Image titlebackground;
	public Text TitleText;

	// Use this for initialization
	void Start () {
		UItext = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartTyping(List<string> lines){
		max = lines.Count;
		this.lines = lines.ToArray();
		titlebackground.enabled = true;
		TitleText.color = Color.white;
		StartCoroutine(TypeText(lines[i], TitleText,true));
	}

	IEnumerator TypeText(string line, Text text, bool title = false){
		int index = 0;
		string toType = line;
		while (index < toType.Length) {
			index++;
			text.text = toType.Substring (0, index) + "<color=#1110>" + toType.Substring(index) + "</color>";
			yield return new WaitForSeconds (0.03f);
		}
		yield return new WaitForSeconds(0.5f);
		if(!title){
			StartCoroutine(EraseText(text));
		} else {
			titlebackground.enabled = false;
			StartCoroutine(FadeOut());
		}
		yield return new WaitForSeconds(1f);
		i++;
		if(i < max && !title){
			StartCoroutine(TypeText(lines[i], text));
		} else if (title){
			yield return new WaitForSeconds(1f);
			background.enabled = true;
			StartCoroutine(TypeText(lines[i], UItext));
		} else {
			StartCoroutine(EraseText(text));
			yield return new WaitForSeconds(1f);
			background.enabled = false;
			i = 0;
		}
	}

	IEnumerator EraseText(Text text){
		while(UItext.text.Length > 3){
			text.text = text.text.Substring(4);
			yield return null;
		}
		text.text = "";
	}

	IEnumerator FadeOut(){
		while(TitleText.color.a > 0){
			TitleText.color = new Color(
				TitleText.color.r,
				TitleText.color.g,
				TitleText.color.b,
				TitleText.color.a - 0.01f
			);
			yield return new WaitForSeconds(0.01f);
		}
		TitleText.text = "";
	}

	public void StopTyping(){
		StopAllCoroutines();
		StartCoroutine(EraseText(UItext));
		background.enabled = false;
		i = 0;
	}
}
