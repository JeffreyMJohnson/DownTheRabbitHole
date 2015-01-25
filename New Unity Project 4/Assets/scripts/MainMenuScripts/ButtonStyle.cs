using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonStyle : MonoBehaviour
{
	void OnMouseEnter()
	{
		GetComponent<Text> ().color = Color.white;
	}

	void OnMouseExit()
	{
		GetComponent<Text> ().color = Color.black;
	}
}
