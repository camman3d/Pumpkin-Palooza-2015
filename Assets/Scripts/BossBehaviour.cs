using UnityEngine;
using System.Collections;

public class BossBehaviour : MonoBehaviour {

	public readonly float damageModifier = 0.1f;

	public static float health;
	public static bool visible;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void hit (int damage) {
		health -= damage * damageModifier;
		Debug.Log ("Boss health: " + health);
		if (health <= 0) {
			Debug.Log("Boss Explosion");
			Destroy(gameObject);
			visible = false;
		}
	}
}
