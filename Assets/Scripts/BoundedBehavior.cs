using UnityEngine;
using System.Collections;

public class BoundedBehavior : MonoBehaviour {

	public double lowerBound;
	public double upperBound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.y < lowerBound || this.transform.position.y > upperBound) {
			Destroy(this.gameObject);
		}
	}
}
