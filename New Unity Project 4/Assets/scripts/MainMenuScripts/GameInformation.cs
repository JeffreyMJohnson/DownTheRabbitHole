using UnityEngine;
using System.Collections;

public class GameInformation : MonoBehaviour
{
	private Transform player;		// Reference to the player's transform.
	private Transform player2;		// Reference to the player's transform.
	
	void Awake ()
	{
		// Setting up the reference.
		player = GameObject.FindGameObjectWithTag("Player").transform;
		player2 = GameObject.FindGameObjectWithTag("Player2").transform;

		if (isResuming)
		{
			LoadState();
			isResuming = false;
		}
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.CapsLock))
		{
			LoadState();
		}
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			//PauseMenu.PauseGame();
		}
	}

	private void LoadState()
	{
		Checkpoints.LoadCheckpoint();
		player.position = new Vector3(playerX, playerY, 0);
		player2.position = new Vector3(player2X, player2Y, 0);
		
		BroadcastMessage("RespawnObject");
	}

	public static float playerX{get;set;}
	public static float playerY{get;set;}
	public static float player2X{get;set;}
	public static float player2Y{get;set;}

	public static bool isResuming = false;
}
