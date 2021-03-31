using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Character
{

    public class CameraController : InputMonoBehaviour, IPausable
    {

        [SerializeField] private GameObject FollowTarget;
        [SerializeField] private float RotationSpeed = 1f;
        [SerializeField] private float HorizontalDamping = 1f;


        private Transform FollowTargetTransform;

        private Vector2 PreviousMouseInput;

        private new void Awake()
        {
            base.Awake();
            FollowTargetTransform = FollowTarget.transform;
            PreviousMouseInput = Vector2.zero;
        }

        // Start is called before the first frame update
        private void Start()
        {
            //FollowTargetTransform = FollowTarget.transform;
            //PreviousMouseInput = Vector2.zero;
        }

        public void OnLook(InputValue delta)
        {
            //Vector2 aimValue = delta.Get<Vector2>();

            //FollowTargetTransform.rotation *=
            //    Quaternion.AngleAxis(
            //        Mathf.Lerp(PreviousMouseInput.x, aimValue.x, 1f / HorizontalDamping) * RotationSpeed,
            //        transform.up
            //        );
            //transform.rotation = Quaternion.Euler(0, FollowTargetTransform.transform.rotation.eulerAngles.y ,0);

            //FollowTargetTransform.localEulerAngles = Vector3.zero;

            //PreviousMouseInput = aimValue;
        }

        public void OnLooked(InputAction.CallbackContext obj)
        {
            Vector2 aimValue = obj.ReadValue<Vector2>();

            FollowTargetTransform.rotation *=
                Quaternion.AngleAxis(
                    Mathf.Lerp(PreviousMouseInput.x, aimValue.x, 1f / HorizontalDamping) * RotationSpeed,
                    transform.up
                    );

            PreviousMouseInput = aimValue;

            transform.rotation = Quaternion.Euler(0, FollowTargetTransform.transform.rotation.eulerAngles.y, 0);

            FollowTargetTransform.localEulerAngles = Vector3.zero;

        }



        private new void OnEnable()
        {
            base.OnEnable();
            GameInput.PlayerActionMap.Look.performed += OnLooked;
        }

        private new void OnDisable()
        {
            base.OnDisable();
            GameInput.PlayerActionMap.Look.performed -= OnLooked;
        }

        public void PauseGame()
        {
            GameInput.PlayerActionMap.Look.performed -= OnLooked;
        }

        public void UnPauseGame()
        {
            GameInput.PlayerActionMap.Look.performed += OnLooked;
        }
    }
}
