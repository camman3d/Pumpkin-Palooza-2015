using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossHealthBarBehavior : MonoBehaviour {

	private RawImage image;

	// Use this for initialization
	void Start () {
		image = gameObject.GetComponent<RawImage> ();
		image.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		image.enabled = BossBehaviour.visible;
	}
}
