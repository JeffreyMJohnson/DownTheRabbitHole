using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;
using System.Collections;

namespace UnitySampleAssets._2D
{

    [RequireComponent(typeof(PlatformerCharacter2D))]
    public class BunnyUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D character;
        private bool jump;
        public bool isActive = false;

        private float lastMovedTime;

        private void Awake()
        {
            character = GetComponent<PlatformerCharacter2D>();
            lastMovedTime = Time.time;
        }

        private void Update()
        {
            if (!jump)
                // Read the jump input in Update so button presses aren't missed.
                jump = CrossPlatformInputManager.GetButtonDown("Jump");
        }

        private void FixedUpdate()
        {
            if (isActive)
            {
                float hMovement = CrossPlatformInputManager.GetAxis("Horizontal");

                switch (Application.loadedLevel)
                {
                    case 1:
                        StartCoroutine(WiggleWiggleWiggle(hMovement));
                        break;

                    case 2:
                        MoveStandard(hMovement);
                        break;
                }
                

                
            }
        }

        public void SwapPlayer()
        {
            isActive = !isActive;
        }

        private IEnumerator WiggleWiggleWiggle(float hMovement)
        {
            // Always reset the jump param. We'll never take it into account
            jump = false;

            // The Speed animator parameter is set to the absolute value of the horizontal input.
            //anim.SetFloat("Speed", Mathf.Abs(hMovement));

            // Move the character if it's over a threshold speed.
            if ((Mathf.Abs(hMovement) > 0.01) &&
                (Time.time - lastMovedTime > 2))
            {
                rigidbody2D.velocity = new Vector2(Mathf.Sign(hMovement), 0);
                yield return new WaitForSeconds(0.1f);
                rigidbody2D.velocity = new Vector2(-Mathf.Sign(hMovement), 0);
                yield return new WaitForSeconds(0.1f);
                rigidbody2D.velocity = new Vector2(0, 0);

                lastMovedTime = Time.time;
            }
        }

        private void MoveStandard(float hMovement)
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            // Pass all parameters to the character control script.
            character.Move(hMovement, crouch, jump);
            jump = false;
        }

    }
}