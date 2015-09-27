using UnityEngine;
using System.Collections;

public class ExplosionBehavior : MonoBehaviour {

	private float timer = 0;
	private float lifetime = 5;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= this.lifetime) {
			Destroy(this.gameObject);
		}
	}
}
