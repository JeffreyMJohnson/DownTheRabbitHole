using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame()
	{
		GameInformation.isResuming = false;
		StartCoroutine(ChangeLevel("Scene"));
	}

	public void ResumeGame()
	{
		GameInformation.isResuming = true;
		StartCoroutine(ChangeLevel("Scene"));
	}

	public void QuitGame()
	{
		Debug.Log("Quitting.");
		Application.Quit ();
	}

	private IEnumerator ChangeLevel(string level)
	{
		Debug.Log ("Changing");
		float fadeTime = GameObject.Find("Main Camera").GetComponent<CrossFade>().BeginFade(-1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel(level);
	}
}
