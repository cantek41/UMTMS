using UnityEngine;

namespace Core.Concreates.MyPhysics
{
    public class ClimbingMovment : MonoBehaviour
    {
        [Header("References")]
        public Transform orientation;
        public Rigidbody rb;

        public LayerMask whatIsWall;

        [Header("Climbing")]
        public float climbSpeed;
        public float maxClimbTime;
        private float climbTimer;

        private bool climbing;

        [Header("ClimbJumping")]
        public float climbJumpUpForce;
        public float climbJumpBackForce;

        public KeyCode jumpKey = KeyCode.Space;
        public int climbJumps;
        private int climbJumpsLeft;

        [Header("Detection")]
        public float detectionLength;
        public float sphereCastRadius;
        public float maxWallLookAngle;
        private float wallLookAngle;

        private RaycastHit frontWallHit;
        private bool wallFront;

        private Transform lastWall;
        private Vector3 lastWallNormal;
        public float minWallNormalAngleChange;

        [Header("Exiting")]
        public bool exitingWall;
        public float exitWallTime;
        private float exitWallTimer;

        private void Update()
        {
            WallCheck();
            StateMachine();

            //if (climbing) 
            ClimbingMovement();
        }

        private void StateMachine()
        {
            // State 1 - Climbing
            if (wallFront && Input.GetKey(KeyCode.C))// && wallLookAngle < maxWallLookAngle && !exitingWall)
            {
                Debug.Log("StateMachine true");
                if (!climbing && climbTimer > 0) StartClimbing();

                // timer
                if (climbTimer > 0) climbTimer -= Time.deltaTime;
                if (climbTimer < 0) StopClimbing();
            }

            // State 2 - Exiting
            else if (exitingWall)
            {
                if (climbing) StopClimbing();

                if (exitWallTimer > 0) exitWallTimer -= Time.deltaTime;
                if (exitWallTimer < 0) exitingWall = false;
            }

            // State 3 - None
            else
            {
                if (climbing) StopClimbing();
            }

            if (wallFront && Input.GetKeyDown(jumpKey) && climbJumpsLeft > 0) ClimbJump();
        }

        private void WallCheck()
        {
            wallFront = Physics.SphereCast(transform.position, sphereCastRadius, orientation.forward, out frontWallHit, detectionLength, whatIsWall);
            wallLookAngle = Vector3.Angle(orientation.forward, -frontWallHit.normal);

            bool newWall = frontWallHit.transform != lastWall || Mathf.Abs(Vector3.Angle(lastWallNormal, frontWallHit.normal)) > minWallNormalAngleChange;

            if ((wallFront && newWall))//|| pm.grounded)
            {
                climbTimer = maxClimbTime;
                climbJumpsLeft = climbJumps;
            }
        }

        private void StartClimbing()
        {
            Debug.Log("StartClimbing");

            climbing = true;
            //   pm.climbing = true;

            lastWall = frontWallHit.transform;
            lastWallNormal = frontWallHit.normal;

            /// idea - camera fov change
        }

        private void ClimbingMovement()
        {
            Debug.Log("ClimbingMovement true");

            //rb.velocity = new Vector3(rb.velocity.x, climbSpeed, rb.velocity.z);
            transform.Translate(Vector3.up * climbSpeed * Time.deltaTime);
            /// idea - sound effect
        }

        private void StopClimbing()
        {
            Debug.Log("StopClimbing");
            climbing = false;
            //   pm.climbing = false;

            /// idea - particle effect
            /// idea - sound effect
        }

        private void ClimbJump()
        {
            exitingWall = true;
            exitWallTimer = exitWallTime;

            Vector3 forceToApply = transform.up * climbJumpUpForce + frontWallHit.normal * climbJumpBackForce;

            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(forceToApply, ForceMode.Impulse);

            climbJumpsLeft--;
        }

    }

}