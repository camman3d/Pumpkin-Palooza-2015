using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour {

	private Text text;

	public int scoreIndex;

	// Use this for initialization
	void Start () {
		this.text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = CoreBehavior.scores [scoreIndex] + "";
	}
}
