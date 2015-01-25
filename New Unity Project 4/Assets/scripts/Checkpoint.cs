using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	private Transform player;		// Reference to the player's transform.
	private Transform player2;		// Reference to the player's transform.
	
	void Awake ()
	{
		// Setting up the reference.
		player = GameObject.FindGameObjectWithTag("Player").transform;
		player2 = GameObject.FindGameObjectWithTag("Player2").transform;
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player") || other.CompareTag("Player2"))
		{
			GameInformation.playerX = player.position.x;
			GameInformation.playerY = player.position.y;
			GameInformation.player2X = player2.position.x;
			GameInformation.player2Y = player2.position.y;

			Checkpoints.SaveCheckpoint();
			GameObject.Destroy(this.gameObject);
		}
	}
}
