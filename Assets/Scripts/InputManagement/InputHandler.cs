using JAM.Animations;
using JAM.Characters;
using UnityEngine;

namespace JAM.InputManagement {

    [AddComponentMenu("JAM/InputHandler/Input Handler")]
    [RequireComponent(typeof(Player))]
    [DisallowMultipleComponent]
    public class InputHandler : MonoBehaviour {

        protected CharacterBase character;
        protected Rigidbody2D rbody;
        protected AnimatorController animatorController;
        private float horizontalInput;
        private float verticalInput;
        
        private Vector2 movementInput;
        protected float currentVelocity = 0;
        protected Vector2 movementDirection;

        private void Awake() {
            character = GetComponent<CharacterBase>();
            rbody = character.characterComponents.characterRigidbody2D;
            animatorController = character.characterComponents.animatorController;
        }

        private void Update() {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            movementInput = new Vector2( horizontalInput, verticalInput );
            animatorController.Play(movementInput * currentVelocity);
            if (movementInput.magnitude > 0) {
                if (Vector2.Dot(movementInput.normalized, movementDirection) < 0) {
                    currentVelocity = 0;
                }
                movementDirection = movementInput.normalized;
            }
            currentVelocity = CalculateSpeed(movementInput);
        }

        public float CalculateSpeed (Vector2 movementInput) {
            if(movementInput.magnitude > 0) {
                currentVelocity += character.characterData.acceleration * Time.deltaTime;
            } else {
                currentVelocity -= character.characterData.deceleration * Time.deltaTime;
            }
            return Mathf.Clamp(currentVelocity, 0, character.characterData.maxSpeed);
        }

        void FixedUpdate() {
            character.characterData.currentVelocity = currentVelocity;
            Vector2 movement = movementDirection.normalized * currentVelocity;
            character.characterEvents.OnMovementVelocityNormal()?.Invoke(movement);
        }
    }
}