using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public float leftBound;
	public float rightBound;
	public float speed;

	private int waypointIdx = 0;
	private Vector3 start = new Vector3 (70, -90, 300);
	private Vector3[][] waypoints = new Vector3[3][];
	private int[] timePoints = new int[] { 15, 15, 30 };

	// Use this for initialization
	void Start () {
		waypoints[0] = new Vector3[] {
			new Vector3(70, -66, 260),
			new Vector3(70, -66, 218),
			new Vector3(64, -66, 153),
			new Vector3(44, -111, 171)
		};
		waypoints[1] = new Vector3[] {
			new Vector3(161, -59, 138),
			new Vector3(182, -78, 138),
			new Vector3(182, -104, 80)
		};
		waypoints[2] = new Vector3[] {
			new Vector3(182, -104, -9),
			new Vector3(182, -80, -20),
			new Vector3(88, -80, -30),
			new Vector3(-6, -70, -20),
			new Vector3(-100, -80, -30)
		};
		transform.position = start;
		StartMove ();
	}

	void StartMove () {
		if (waypointIdx >= waypoints.Length) 
			return;
		var hm = iTween.Hash ("path", waypoints[waypointIdx],
		                      "time", timePoints[waypointIdx],
		                      "oncomplete", "MoveComplete",
		                      "easetype", iTween.EaseType.easeInOutSine);
		iTween.MoveTo (gameObject, hm);
	}

	void MoveComplete () {
		Debug.Log ("Move complete");
		waypointIdx++;
		StartMove ();
	}
	
	// Update is called once per frame
	void Update () {
	}
}
