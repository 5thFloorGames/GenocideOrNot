using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FetchText : MonoBehaviour {

	private Text text;
	private ExhibitionScriptHolder script;
	public string path;
	private string fulltext;
	private int i = 0;

	// Use this for initialization
	void Start () {
		script = FindObjectOfType<ExhibitionScriptHolder>();
		text = GetComponent<Text>();
		text.text = script.GetLine(path);
		for(int j = 0; j< 10;j++){
			fulltext += fulltext;
		}
		//StartCoroutine(Scroll());
	}


	IEnumerator Scroll(){
		while(i < fulltext.Length + 200){
			text.text = fulltext.Substring (i, 200) + "<color=#1110>" + fulltext.Substring(200 + i, 200 + i +50) + "</color>";

			i++;
			print(i);
			yield return new WaitForSeconds(0.1f);
		}
	}
}
