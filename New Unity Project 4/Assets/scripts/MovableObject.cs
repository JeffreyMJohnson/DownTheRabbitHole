using UnityEngine;
using System.Collections;

public class MovableObject : MonoBehaviour {

	private Vector3 startPos;

	// Use this for initialization
	void Start () {
		startPos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void RespawnObject()
	{
		gameObject.transform.position = startPos;
	}
}
