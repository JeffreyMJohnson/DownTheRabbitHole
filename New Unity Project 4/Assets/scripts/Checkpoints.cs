using UnityEngine;
using System.Collections;

public class Checkpoints
{
	public static void SaveCheckpoint()
	{
		PlayerPrefs.SetFloat("PlayerX", GameInformation.playerX);
		PlayerPrefs.SetFloat("PlayerY", GameInformation.playerY);
		PlayerPrefs.SetFloat("Player2X", GameInformation.player2X);
		PlayerPrefs.SetFloat("Player2Y", GameInformation.player2Y);
	}

	public static void LoadCheckpoint()
	{
		GameInformation.playerX = PlayerPrefs.GetFloat("PlayerX");
		GameInformation.playerY = PlayerPrefs.GetFloat("PlayerY");
		GameInformation.player2X = PlayerPrefs.GetFloat("Player2X");
		GameInformation.player2Y = PlayerPrefs.GetFloat("Player2Y");

	}
}
