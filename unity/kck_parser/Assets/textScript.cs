using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class textScript : MonoBehaviour {
	public InputField userInput;
	public Text roboTalk;
	private string commandText, output, roboText, main_word = "";
	private string processState = "main";
	private static Hashtable commands = new Hashtable();
	void Awake () { 
		userInput = GameObject.Find ("userInput").GetComponent<InputField>();
		userInput.onSubmit.AddListener (((value) => OnSubmit(value)));
		//userInput.validation = InputField.Validation.Alphanumeric;	
		//tworzenie tablicy komend
		commands.Add("build","main");//drugi argument w nawiasie to będzie np. jakiś wskaźnik na funkcje
		commands.Add("destroy","main");
		commands.Add("house","second-tier");
		commands.Add("shed","second-tier");
		commands.Add("cheap","third-tier");
		commands.Add("?","first-tier");
	}
	string Parser(string command) {
		string[] words = command.Split(new Char [] {' ', ',', '.', ':', '\t', '?' });

		foreach (var word in words) {
			Debug.Log(word);
			switch (processState) {
				case "main":
					if (String.Equals(commands[word],processState))
						return Process_main(word);
					break;
				case "second-tier":
					if (String.Equals(commands[word],processState))
						return Process_second_tier(word);
					break;
				case "third-tier":
					if (String.Equals(commands[word],processState)) ;
						//return Process_third_tier(word);
					break;
			}
		}
		//if (commands[command] == ) 
		return "Nie wiem o co ci chodzi. Proszę wyrażaj się jasno. Zapytaj mojego autora jak wyrażać się jasno";
	}

	string Process_main(string word) {
		processState = "second-tier";
		main_word = word;
		//miejsce na funkcję w zależności od słowa word
		return "Which structure would you like to "+word+" ?";
	}
	string Process_second_tier(string word){
		processState = "third-tier";
		return "Okay i will " + main_word + " the " + word;
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
