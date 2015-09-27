using UnityEngine;
using System.Collections;

public class CoreBehavior : MonoBehaviour {

	public Rigidbody pumpkin;
	public Rigidbody greenPumpkin;
	public Rigidbody redPumpkin;
	public GameObject boss;

	// Boss position
	private Vector3 bossPos = new Vector3 (0, 0, 120);
	private Vector3 bossDestPos = new Vector3 (0, 0, 50);
	private Vector3 bossRot = new Vector3 (0, 180, 0);

	// Creation positions
//	private Vector3 basePos = new Vector3 (0, 38, -15);
	private Vector3 basePos = new Vector3 (0, -4, 10);
	private Vector3 column1 = new Vector3(-8, 0, 0);
	private Vector3 column2 = new Vector3(-0.35f, 0, 0);
	private Vector3 column3 = new Vector3(7.3f, 0, 0);
	private Vector3 top = new Vector3(0, 8, 0);
	private Vector3 bottom = new Vector3(0, -5, 0);

	// Creation forces
	private Vector3 upForce = Vector3.up * 700;
	private Vector3 downForce = Vector3.zero;

	// Time for a round to clear
	private float timer = 0;
	private float upClearTime = 3;
	private float downClearTime = 2;
	private float upBurstClearTime = 0.3f;
	private float downBurstClearTime = 0.6f;
	private float crazyClearTime = 0.05f;
	private float totalTime;

	public static float duration = 0;

	private int counter = 0;
	private int basicCount = 4;
	private int upBurstCount = 4;
	private int downBurstCount = 4;
	private int crazyCount = 20;

	// Score keeping
	public static int[] scores = new int[3];

	// Modes
	private int mode = 1; // 0 = not playing, 1 = basic, 2 = burst up, 3 = burst down, 4 = crazy, 5 = create boss, 6 = wait for end

	// Use this for initialization
	void Start () {
		scores [0] = 0;
		scores [1] = 0;
		scores [2] = 0;
		totalTime = 0;
	}

	private void createPumpkin(Vector3 column, bool up) {
//		Vector3 origin = pumpkin.transform.position * -1;
		int rand = Random.Range(0, 10);
		Rigidbody obj;
		if (rand < 7) {
			obj = pumpkin;
		} else if (rand < 9) {
			obj = greenPumpkin;
		} else {
			obj = redPumpkin;
		}

		Vector3 newPos = Camera.main.transform.position + basePos + column + (up ? bottom : top);
		Rigidbody clone = (Rigidbody) Instantiate(obj, newPos, Quaternion.identity);
		clone.AddForce (up ? upForce : downForce);
		clone.AddTorque (Random.insideUnitSphere * 50);
	}

	private void createRound(bool up) {
		createPumpkin (column1, up);
		createPumpkin (column2, up);
		createPumpkin (column3, up);
	}
	
	private void createBoss() {
		GameObject clone = (GameObject)Instantiate (boss, bossPos, Quaternion.Euler(bossRot));
		iTween.MoveTo (clone, bossDestPos, duration - totalTime);
	}

	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		totalTime += Time.deltaTime;

		if (mode == 1) { // Basic
			if (timer <= 0) {
				bool up = Random.seed % 2 == 0;
				createRound (up);
				timer = up ? upClearTime : downClearTime;
				counter++;
			}
			if (counter >= basicCount) {
				counter = 0;
				mode = 2;
			}
		} else if (mode == 2) { // Burst up
			if (timer <= 0) {
				createRound (true);
				timer = upBurstClearTime;
				counter++;
			}
			if (counter >= upBurstCount) {
				timer = upClearTime;
				counter = 0;
				mode = 3;
			}
		} else if (mode == 3) { // Burst down
			if (timer <= 0) {
				createRound (false);
				timer = downBurstClearTime;
				counter++;
			}
			if (counter >= downBurstCount) {
				timer = upClearTime;
				counter = 0;
				mode = 4;
			}
		} else if (mode == 4) { // Burst down
			if (timer <= 0) {
				createRound (counter % 2 == 0);
				timer = crazyClearTime;
				counter++;
			}
			if (counter >= crazyCount) {
				mode = 5;
			}
		} else if (mode == 5) { // Create Boss
			createBoss ();
			mode = 6;
		} else if (mode == 6) {
			if (totalTime >= duration) {
				mode = 0;
				Application.LoadLevel("Title");
			}
		}



//		if (Input.GetKeyDown (KeyCode.A)) {
//			createRound(false);
//		}
//		if (Input.GetKeyDown (KeyCode.S)) {
//			createRound(true);
//		}
		if (Input.GetKeyDown (KeyCode.Alpha0)) {
			mode = 0;
		}
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			mode = 1;
			counter = 0;
			scores[0] = 0;
			scores[1] = 0;
			scores[2] = 0;
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			mode = 2;
			counter = 0;
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			mode = 3;
			counter = 0;
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			mode = 4;
			counter = 0;
		}
	}
}
