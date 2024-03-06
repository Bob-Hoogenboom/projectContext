using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private int playerIndex = 0;
    private CharacterController2D _charCon2D;
    private PlayerGrabHandler _grabHandler;

    [Header("Movement")]
    [SerializeField] private float speed= 40f;

    private Vector2 _moveVector;
    private bool _isJumping;

    // Start is called before the first frame update
    void Start()
    {
        _charCon2D = GetComponent<CharacterController2D>();
        _grabHandler = GetComponent<PlayerGrabHandler>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        var moveValue = _moveVector.x * speed * Time.fixedDeltaTime;
        _charCon2D.Move(moveValue, false, _isJumping);
    }


    #region InputSystem
    public void SetMoveVector(Vector2 moveVector)
    {
        if(moveVector.x > 0)
        {
            _grabHandler.GrabHandlerLeft(false);
        }

        if (moveVector.x < 0)
        {
            _grabHandler.GrabHandlerLeft(true);
        }

        _moveVector = moveVector;
    }

    public void SetJumpBool(bool isPressed)
    {
        _isJumping = isPressed;
    }

    public void OnGrab()
    {
        _grabHandler.Grab();
    }

    #endregion

    #region ConnectPlayer
    public int GetPlayerIndex()
    {
        return playerIndex;
    }
    #endregion
}
