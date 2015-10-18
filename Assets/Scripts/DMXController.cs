using UnityEngine;
using System.Collections;

public class DMXController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void start(string show) {
		var dmxUrl = "http://localhost:9001/api/start/" + show;
		WWW www = new WWW (dmxUrl);
	}

	public static void start(string show, int offset) {
		var dmxUrl = "http://localhost:9001/api/startOffset/" + offset + "/" + show;
		WWW www = new WWW (dmxUrl);
	}
}
