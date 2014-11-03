using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class textScript : MonoBehaviour {
	public InputField userInput;
	public Text roboTalk;
	private string commandText = "";
	void Awake () { 
		userInput = GameObject.Find ("userInput").GetComponent<InputField>();
		userInput.onSubmit.AddListener (((value) => OnSubmit(value)));
		//userInput.validation = InputField.Validation.Alphanumeric;	
	}
	void OnSubmit(string line) {
		Debug.Log ("OnSubmit("+line+")");
		commandText += DateTime.Now.ToString("h:mm:ss tt") +  "\n" + line + "\n" ;
	}
	void OnGUI () {
		GUI.TextArea (new Rect(668 ,125, 130,300),commandText,250);	
	}
}
