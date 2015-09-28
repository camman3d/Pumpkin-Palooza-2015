using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CrosshairBehavior : MonoBehaviour {

	private RawImage rawImage;

	public KeyCode keyCode;

	public int scoreIndex;

	// Use this for initialization
	void Start () {
		this.rawImage = GetComponent<RawImage> ();
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(this.transform.position);
		RaycastHit hit = new RaycastHit();
		if (Physics.Raycast (ray, out hit)) {
			rawImage.color = Color.red;
			if (Input.GetKeyDown(keyCode)) {
				ExploderBehaviourScript exploder = hit.transform.GetComponent<ExploderBehaviourScript>();
				if (exploder != null) {
					int points = exploder.explode();
					CoreBehavior.scores[scoreIndex] += points;

					// TODO: Merge in startOffset endpoint and use that
					var explosionUrl = "http://localhost:9001/api/start/explosion";
					WWW www = new WWW(explosionUrl);
				}
				BossBehaviour boss = hit.transform.GetComponent<BossBehaviour>();
				if (boss != null) {
					boss.hit(CoreBehavior.scores [scoreIndex]);
				}
			}
		} else {
			rawImage.color = Color.white;
		}
	}
}
