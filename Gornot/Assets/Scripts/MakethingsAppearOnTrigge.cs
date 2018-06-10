using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakethingsAppearOnTrigge : MonoBehaviour {

	public GameObject exhibition;
    public AudioClip exhibitionOnSound;
    public AudioClip exhibitionOffSound;
    public AudioClip AmbSound;
    public Color AmbientLight;
	public FloorMaterial material;
	public string inkpath;
	private ExhibitionScriptHolder script;

    // Use this for initialization
    void Start () {
		script = FindObjectOfType<ExhibitionScriptHolder>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player"){
			exhibition.SetActive(true);
            AudioManager.Instance.playSound(exhibitionOnSound, gameObject, 0.1f, 0.9f, 0.1f, false, 8);
            AudioManager.Instance.playSound(AmbSound, gameObject, 0.1f, 0.9f, 0.04f, false, 8);
            RenderSettings.ambientLight = AmbientLight;
			AudioManager.Instance.ChangeMaterial(material);
			script.GetLines(inkpath);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.tag == "Player"){
			exhibition.SetActive(false);
            AudioManager.Instance.playSound(exhibitionOffSound, gameObject, 0.5f, 0.9f, 0.1f, false, 8);
            AudioManager.Instance.stopSound(AmbSound.name);
            RenderSettings.ambientLight = Color.black;
			AudioManager.Instance.ChangeMaterial(FloorMaterial.Normal);
			script.StopTyping();
		}
	}
}
