using UnityEngine;
using System.Collections;

public class RockSoundController : MonoBehaviour {

	// Use this for initialization
    //public AudioClip rockScrap;
    public AudioSource source;
    public bool isSliding;
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (rigidbody2D.velocity.x != 0)
        {
            //Debug.Log(rigidbody.velocity.x);
            isSliding = true;
        }
        else
        {
            isSliding = false;
        }

        PlayAudio();

	}
    private void PlayAudio()
    {

        if(isSliding && !audio.isPlaying)
        {
            //audio.clip = rockScrap;
            source.Play();
        }
        else
        {
          //  source.Stop();
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), rigidbody2D.velocity.x.ToString());
    }
}