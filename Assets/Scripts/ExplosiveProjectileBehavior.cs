using UnityEngine;
using System.Collections;

public class ExplosiveProjectileBehavior : MonoBehaviour {

	public Vector3 initialForce;

	// Use this for initialization
	void Start () {
		Rigidbody rigidbody = GetComponent<Rigidbody> ();
		rigidbody.AddForce (initialForce);
		rigidbody.AddTorque (Random.insideUnitSphere * 75);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
