using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

namespace UnitySampleAssets._2D
{

    [RequireComponent(typeof(PlatformerCharacter2D))]
    public class girlUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D character;
        private bool jump;
        public bool isActive = true;
        private GameObject branchMantelPoint;


        private void Awake()
        {
            character = GetComponent<PlatformerCharacter2D>();
            //branchMantelPoint = GameObject.Find("branch/mantelPoint");
        }

        private void Update()
        {
            if (!jump)
                // Read the jump input in Update so button presses aren't missed.
                jump = CrossPlatformInputManager.GetButtonDown("Jump");
            //if (isManteling)
            //{
            //    float distCovered = (Time.time - startTime) * speed;
            //    float fracJourney = distCovered / journeyLength;
            //    transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
            //    if (transform.position == endMarker.position)
            //        isManteling = false;
            //}
        }

        private void FixedUpdate()
        {
            if (isActive)
            {
                // Read the inputs.
                bool crouch = Input.GetKey(KeyCode.LeftControl);
                float h = CrossPlatformInputManager.GetAxis("Horizontal");
                // Pass all parameters to the character control script.
                character.Move(h, crouch, jump);
                jump = false;

            }

        }

        //test code for lerping up branch
        //public Transform startMarker;
        //public Transform endMarker;
        //public float speed = 1.0f;
        //private float startTime;
        //private float journeyLength;
        //public Transform target;
        //public float smooth = 5.0f;
        private bool isManteling;


        void OnCollisionEnter2D(Collision2D collider)
        {
            //Debug.Log(collider.transform.ToString());

            //if (collider.transform == branchMantelPoint.transform)
            //{
            //    //startTime = Time.time;
            //    //startMarker = transform.Find("GroundCheck");
            //    //endMarker = GameObject.Find("branch").transform;
            //    //BoxCollider2D endMarkerBox = endMarker.GetComponent<BoxCollider2D>();
            //    //journeyLength = Vector3.Distance(startMarker.position, endMarker.position + endMarkerBox.bounds.extents);
            //    Renderer rend = GetComponent<Renderer>();
            //    transform.position = new Vector3(transform.position.x + rend.bounds.extents.x,
            //       rend.bounds.extents.y * .5f,
            //        transform.position.z);


            //    ////playerBottomPos = branch.position;
            //    //Vector3 sub = branchTopPos - playerBottomPos;
            //    //transform.Translate(sub.x, sub.y, sub.z, null);
            //    isManteling = true;
            //}

        }

        public void SwapPlayer()
        {
            isActive = !isActive;
        }
    }
}