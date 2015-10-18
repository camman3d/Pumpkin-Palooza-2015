using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitlePage : MonoBehaviour {

	public KeyCode keyCode1;
	public KeyCode keyCode2;
	public KeyCode keyCode3;
	public KeyCode keyCode4;

	public AudioClip audio1;
	public AudioClip audio2;
	public AudioClip audio3;
	public AudioClip audio4;
	public AudioClip audio5;
	public AudioClip audio6;

	public Image fader;

	public static int audioIndex = 0;

	private AudioSource source;
	private float audioVolume = 0.25f;
	private bool fadeOut;
	private float fadeOutStart;
	private string nextShow;
	private int houseLightIndex = 12;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
		if (audioIndex == 0) {
			source.clip = audio1;
		} else if (audioIndex == 1) {
			source.clip = audio2;
		} else if (audioIndex == 2) {
			source.clip = audio3;
		} else if (audioIndex == 3) {
			source.clip = audio4;
		} else if (audioIndex == 4) {
			source.clip = audio5;
		} else if (audioIndex == 5) {
			source.clip = audio6;
		}
		source.volume = audioVolume;
		source.Play ();
		audioIndex = (audioIndex + 1) % 6;


		Color c = fader.color;
		c.a = 1;
		fader.color = c;
		fader.CrossFadeAlpha (0, 2, false);
		DMXController.start ("houseon", houseLightIndex);

		fadeOut = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!fadeOut) {
			if (Input.GetKeyDown (keyCode1)) {
				startGame ("aha", 33);
			} else if (Input.GetKeyDown (keyCode2)) {
				startGame ("died", 31);
			} else if (Input.GetKeyDown (keyCode3)) {
				startGame ("remains2", 33);
			} else if (Input.GetKeyDown (keyCode4)) {
				startGame ("treasure", 57);
			}
		} else {
			fadeOutStart += Time.deltaTime;
			float fadeP = fadeOutStart / 4f;
			source.volume = (1f - fadeP) * audioVolume;

			if (fadeP >= 1) {
				DMXController.start (nextShow);
				Application.LoadLevel ("Scene1");
			}
		}
	}

	void startGame(string show, float duration) {
		fadeOut = true;
		fadeOutStart = 0;
		CoreBehavior.duration = duration;
		nextShow = show;

		fader.CrossFadeAlpha (1f, 4, false);
		DMXController.start ("houseoff", houseLightIndex);
	}
}
