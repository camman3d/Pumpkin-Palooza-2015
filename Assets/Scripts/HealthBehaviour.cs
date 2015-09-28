using UnityEngine;
using System.Collections;

public class HealthBehaviour : MonoBehaviour {

	private Vector3 start;
	private float width;

	// Use this for initialization
	void Start () {
		var rt = (RectTransform) transform;
		start = new Vector3 (transform.position.x, transform.position.y);
		width = rt.rect.width;
	}
	
	// Update is called once per frame
	void Update () {
		var percent = BossBehaviour.health / 100;
		var newX = (percent * start.x) + ((1 - percent) * (start.x - width));
		transform.position = new Vector3 (newX, start.y);
	}
}
