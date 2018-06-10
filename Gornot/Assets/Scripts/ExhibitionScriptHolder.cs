using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class ExhibitionScriptHolder : MonoBehaviour {

	private TextAsset inkJSONAsset;
    private Story story;

    void Awake()
    {
        inkJSONAsset = Resources.Load<TextAsset>("Memories");
        story = new Story(inkJSONAsset.text);
    }

    public void GetLines(string inkPath)
    {
        List<string> lines = new List<string>();
        if(story == null)
        {
            return;
        }
        story.ChoosePathString(inkPath);
        while (story.canContinue)
        {
            lines.Add(story.Continue().Trim());
        }
        FindObjectOfType<LetterByLetter>().StartTyping(lines);
    }

    public void StopTyping(){
        FindObjectOfType<LetterByLetter>().StopTyping();
    }
}
