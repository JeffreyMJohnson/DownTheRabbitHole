using UnityEngine;
using System.Collections;

public class PlayerSwapManager : MonoBehaviour
{	
	// Update is called once per frame
	void Update ()
	{
		// If the jump button is pressed and the player is grounded then the player should jump.
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			BroadcastMessage("SwapPlayer", null);
		}
	}
}
