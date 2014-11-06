using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class textScript : MonoBehaviour {
	public InputField userInput;
	public Text roboTalk;
	private string commandText, output, roboText = "";
	void Awake () { 
		userInput = GameObject.Find ("userInput").GetComponent<InputField>();
		userInput.onSubmit.AddListener (((value) => OnSubmit(value)));
		//userInput.validation = InputField.Validation.Alphanumeric;	
	}

	string Parser(string command) {
		/* miesjce na parser zosi */
		return "to ja robot i mowie";
	}

	void OnSubmit(string line) {	
		Debug.Log ("OnSubmit("+line+")");
		commandText = DateTime.Now.ToString("h:mm:ss tt") +  "\nUzytkownik: \n   "+ line + "\n" ;
		roboText = Parser (line);
		output += commandText + "Robot:\n" + "   "+roboText;
	}

	void OnGUI () {
		GUI.TextArea (new Rect(668 ,125, 130,300),output + "",250);	
	}
}
