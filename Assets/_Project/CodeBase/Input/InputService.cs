using System;
using Codebase;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CodeBase.Input
{
    public class InputService
    {
        public event Action<Vector2> MovePerformed;
        
        private readonly InputSystem_Actions _controls;

        public InputService()
        {
            _controls = new InputSystem_Actions();

            _controls.Player.MoveUp.performed += OnMoveUpPerformed;
            _controls.Player.MoveDown.performed += OnMoveDownPerformed;
            _controls.Player.MoveLeft.performed += OnMoveLeftPerformed;
            _controls.Player.MoveRight.performed += OnMoveRightPerformed;
            
            _controls.Player.Enable();
            
            Debug.Log($"{nameof(InputService)} created");
        }

        private void OnMoveUpPerformed(InputAction.CallbackContext context)
        {
            OnMovePerformed(Vector2.up);
        }

        private void OnMoveDownPerformed(InputAction.CallbackContext context)
        {
            OnMovePerformed(Vector2.down);
        }

        private void OnMoveLeftPerformed(InputAction.CallbackContext context)
        {
            OnMovePerformed(Vector2.left);
        }

        private void OnMoveRightPerformed(InputAction.CallbackContext context)
        {
            OnMovePerformed(Vector2.right);
        }

        private void OnMovePerformed(Vector2 input)
        {
            Debug.Log($"{nameof(InputService)}: move performed {input}");
            MovePerformed?.Invoke(input);
        }
    }
}