using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{
	public float score = 0;						// The player's score.


	private PlayerControl playerControl;		// Reference to the player control script.
	private float previousScore = 0;			// The score in the previous frame.

	public GameObject clueShower;


	void Awake ()
	{
		// Setting up the reference.
		playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
	}


	void Update ()
	{

		if (clueShower) {
			clueShower.SetActive (score >= 500);
		}

		// Set the score text.
		GetComponent<GUIText>().text = "Score: " + (int)score;

		// If the score has changed...
		if(previousScore != score)
			// ... play a taunt.
			playerControl.StartCoroutine(playerControl.Taunt());

		// Set the previous score to this frame's score.
		previousScore = score;
	}

}
