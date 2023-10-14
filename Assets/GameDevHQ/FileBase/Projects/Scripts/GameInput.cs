using System;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private ActionMaps _actionMap;
    public event EventHandler _jumpPerformed;
    public event EventHandler _leftMouseClickInteract;
    public event EventHandler _jumpButtonPressed;
    private void Awake() {
        _actionMap = new ActionMaps();
    }

    private void OnEnable() {
        _actionMap.Player.Enable();
        _actionMap.Player.Attack.performed += MouseClickedPerformed;
        _actionMap.Player.Jump.performed += Jump_performed;
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        _jumpButtonPressed?.Invoke(this, EventArgs.Empty);
    }

    private void MouseClickedPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        _leftMouseClickInteract?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetNormalizedVector() {
        Vector2 movement = _actionMap.Player.Movement.ReadValue<Vector2>();
        Vector2 movementNorm = movement.normalized;
        return movementNorm;
    }
    
    public bool IsJumping() {
        if (_actionMap.Player.Jump.IsPressed()) {
            return true;
        }   
        else return false;
    }
}
