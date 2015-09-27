using UnityEngine;
using System.Collections;

public class WispMovement : MonoBehaviour {

	public float speed;

	private float timer = 2;
	private Vector3 direction = Vector3.forward;
	private float zRotation;
//	private float xRotation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

//		direction = Quaternion.AngleAxis (rotation * Time.deltaTime, Vector3.up) * direction;
//		this.transform.Translate (direction * speed * Time.deltaTime);
	}
}
