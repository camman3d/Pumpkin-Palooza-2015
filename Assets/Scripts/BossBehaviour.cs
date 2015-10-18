using UnityEngine;
using System.Collections;

public class BossBehaviour : MonoBehaviour {

	public readonly float damageModifier = 0.2f;

	public static float health;
	public static bool visible;

	public GameObject explosion;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void hit (int damage) {
		damage = Mathf.Max (damage, 1);
		health -= damage * damageModifier;
		if (health <= 0) {
			DMXController.start("bossexplosion", 11);
			var e = (GameObject) Instantiate(explosion);
			e.transform.position = new Vector3(transform.position.x, transform.position.y + 30, transform.position.z - 50);
			Destroy(gameObject);
			visible = false;
			CoreBehavior.scores[0] *= 2;
			CoreBehavior.scores[1] *= 2;
			CoreBehavior.scores[2] *= 2;
		}
	}
}
