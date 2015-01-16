using UnityEngine;
using System.Collections;

public enum MenuTypes {
	StartMenu,
	GameOverMenu
}

public class GameManager : MonoBehaviour {

	public MenuTypes ActiveMenu { get; set; }
	public bool ShowMenu { get; set; }

	void Awake() {
		ActiveMenu = MenuTypes.StartMenu;
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
			if (ActiveMenu == MenuTypes.StartMenu) {
				GUILayout.Window (0, windowRect, StartMenu, "StartMenu");
			} 
			else if (ActiveMenu == MenuTypes.GameOverMenu) {
				GUILayout.Window (0, windowRect, GameOverMenu, "GameOverMenu");
			}
		}
	}

	private void StartMenu(int id) {
		if (GUILayout.Button ("Start Game")) { ////////////////change to space bar 
			// possibly add click sound
			ShowMenu = false;

		}
		// can add other button, etc. here
		// possibly add an exit option here too - check actual game
	}

	private void GameOverMenu(int id) {
		if (GUILayout.Button("Quit")) { ///////////change this
			Application.Quit();
		}

	}


}
