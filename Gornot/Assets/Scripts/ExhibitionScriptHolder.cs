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

    public string GetLine(string inkPath)
    {
        string paragraph = "";
        if(story == null)
        {
            return "";
        }
        story.ChoosePathString(inkPath);
        while (story.canContinue)
        {
            paragraph += story.Continue().Trim();
        }
        return paragraph;
    }
}
