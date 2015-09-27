using UnityEngine;
using System.Collections;

public class TitlePage : MonoBehaviour {

	public KeyCode keyCode1;
	public KeyCode keyCode2;
	public KeyCode keyCode3;
	public KeyCode keyCode4;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (keyCode1)) {
			startGame("aha", 33);
		} else if (Input.GetKeyDown (keyCode2)) {
			startGame("died", 31);
		} else if (Input.GetKeyDown (keyCode3)) {
			startGame("remains", 38);
		} else if (Input.GetKeyDown (keyCode4)) {
			startGame("", 0);
		}
	}

	void startGame(string show, float duration) {
		CoreBehavior.duration = duration;
		var dmxUrl = "http://localhost:9001/api/start/" + show;
		WWW www = new WWW (dmxUrl);

		Application.LoadLevel ("Scene1");
	}
}
