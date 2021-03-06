using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

namespace Character { 
    public class MovementComponent : MonoBehaviour
    {



        [SerializeField] private float WalkSpeed;
        [SerializeField] private float RunSpeed;
        [SerializeField] private float JumpForce;


        // Components

        private PlayerController PlayerController;
        private Animator PlayerAnimator;
        private NavMeshAgent PlayerNavMesh;

        // Refs

        Transform PlayerTransform;

        private Vector2 InputVector = Vector2.zero;
        private Vector3 MoveDirection = Vector3.zero;
        private Rigidbody PlayerRigidbody;
        private Vector3 NextPositionCheck = Vector3.zero;
        [SerializeField] private float MoveDirectionBuffer = 2.0f;

        // Animator Hashes

        public readonly int MovementXHash = Animator.StringToHash("MovementX");
        public readonly int MovementYHash = Animator.StringToHash("MovementY");
        public readonly int IsJumpingHash = Animator.StringToHash("IsJumping");
        public readonly int IsRunningHash = Animator.StringToHash("IsRunning");

        private void Awake()
        {
            PlayerTransform = transform;
            PlayerController = GetComponent<PlayerController>();
            PlayerAnimator = GetComponent<Animator>();
            PlayerRigidbody = GetComponent<Rigidbody>();
            PlayerNavMesh = GetComponent<NavMeshAgent>();

        }

        public void OnMovement(InputValue value)
        {
            Debug.Log(value.Get());
            InputVector = value.Get<Vector2>();

            PlayerAnimator.SetFloat(MovementXHash, InputVector.x);
            PlayerAnimator.SetFloat(MovementYHash, InputVector.y);
        }

        public void OnRun(InputValue value)
        {
            PlayerController.IsRunning = value.isPressed;
            PlayerAnimator.SetBool(IsRunningHash, value.isPressed);
        }

        public void OnJump(InputValue value)
        {
            if (PlayerController.IsJumping) return;

            PlayerController.IsJumping = value.isPressed;
            PlayerAnimator.SetBool(IsJumpingHash, value.isPressed);

            //PlayerNavMesh.enabled = false; ///////////////////////////////////////////

            PlayerRigidbody.AddForce((PlayerTransform.up + MoveDirection) * JumpForce, ForceMode.Impulse);

            //Invoke(nameof(Jump),0.1f);

        }

        public void Jump()
        {
            PlayerRigidbody.AddForce((PlayerTransform.up + MoveDirection) * JumpForce, ForceMode.Impulse);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag("Ground") && !PlayerController.IsJumping) return;

            //PlayerNavMesh.enabled = true; //////////////////////////////////////////
            PlayerController.IsJumping = false;
            PlayerAnimator.SetBool(IsJumpingHash, false);
        }

        private void Update()
        {
            if (PlayerController.IsJumping) return;

            //if (!(InputVector.magnitude > 0)) return;

            MoveDirection = PlayerTransform.forward * InputVector.y + PlayerTransform.right * InputVector.x;

            float currentSpeed = PlayerController.IsRunning ? RunSpeed : WalkSpeed;

            Vector3 movementDirection = MoveDirection * (currentSpeed * Time.deltaTime);

            NextPositionCheck = transform.position + MoveDirection * MoveDirectionBuffer;

            if (NavMesh.SamplePosition(NextPositionCheck,out NavMeshHit hit,1f,NavMesh.AllAreas))
            {
                transform.position += movementDirection;
            }



            PlayerNavMesh.Move(movementDirection);

            //PlayerTransform.position += movementDirection;

        }

        private void OnGrewGizmos()
        {
            if (NextPositionCheck != Vector3.zero)
            {
                Gizmos.DrawSphere(NextPositionCheck, 0.5f);
            }
        }

    }

}
