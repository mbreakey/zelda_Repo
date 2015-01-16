using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public bool ShowMenu { get; set; }

	void Awake() {
		ShowMenu = true;
		DontDestroyOnLoad (gameObject);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		const int windowWidth = 400;
		const int windowHeight = 300;
		if (ShowMenu) {
			Rect windowRect = new Rect(
				(Screen.width - windowWidth) / 2, 
				(Screen.height - windowHeight) / 2,
				windowWidth, windowHeight);
			GUILayout.Window (0, windowRect, MainMenu, "Main Menu");
		}
	}

	private void MainMenu(int id) {
		GUILayout.Label ("Test");
	}

}
