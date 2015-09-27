using UnityEngine;
using System.Collections;

public class ExploderBehaviourScript : MonoBehaviour {

	public GameObject explosion1;
	public GameObject explosion2;
	public GameObject explosion3;

	public int pointModifier;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public int explode() {
		GameObject obj1 = (GameObject) Instantiate(explosion1, this.gameObject.transform.position, Quaternion.identity);
		GameObject obj2 = (GameObject) Instantiate(explosion2, this.gameObject.transform.position, Quaternion.identity);
		GameObject obj3 = (GameObject) Instantiate(explosion3, this.gameObject.transform.position, Quaternion.identity);
		Destroy(this.gameObject);
		return pointModifier;
	}
}
