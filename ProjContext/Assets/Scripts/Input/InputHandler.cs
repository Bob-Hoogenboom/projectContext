using System.Linq;
using UnityEngine;
using TarodevController;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;



/// <summary>
/// Tutorial Source: https://www.youtube.com/watch?v=2YhGK-PXz7g
/// </summary>
public class InputHandler : MonoBehaviour
{
    private PlayerMovement _playerController;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        var players = FindObjectsOfType<PlayerMovement>();
        var index = _playerInput.playerIndex;
        _playerController = players.FirstOrDefault(m => m.GetPlayerIndex() == index);
;    }

    public void OnWalking(CallbackContext context)
    {
        _playerController.SetMoveVector(context.ReadValue<Vector2>());
    }

    public void OnJumping(CallbackContext context)
    {
        _playerController.SetJumpBool(context.performed);
    }

    public void OnGrab(CallbackContext context)
    {
        if (context.canceled)
        {
            _playerController.OnGrab();
        }
    }
}
