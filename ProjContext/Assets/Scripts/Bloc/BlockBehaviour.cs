using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject isCorrect;
    [SerializeField] private Rigidbody2D rigidbody2d;
    [SerializeField] private float rayLength = 1.05f;

    private float _gravity = 1.0f;
    private bool isHolding;
    private bool isGrounded = true;

    public GameObject happyBlock;
    public bool GetHolding
    {
        get { return isHolding; }       
    }

    public void IsHeld(bool isHeld)
    {
        if (!isHeld)
        {
            isHolding = false;
            rigidbody2d.isKinematic = true;
            rigidbody2d.velocity = Vector2.zero; //Empty velocity value to prevent certain physics bugs
            isGrounded = false;
            return;            
        }
        isHolding = true;
        rigidbody2d.isKinematic = false;

        happyBlock.SetActive(true);
    
    }

    //Invokes when the block is placed in the right goal position
    public void Glowing(bool state)
    {
        isCorrect.SetActive(state);
    }

    public void ApplyGravity()
    {
        transform.position -= new Vector3(0, _gravity * Time.deltaTime, 0);
    }

    private void Update()
    {
        if (!isHolding)
        {
            CheckGrounded();
            happyBlock.SetActive(false);
            if (!isGrounded)
            {
                ApplyGravity();
            }
        }
    }


    private void CheckGrounded()
    {
        Vector3 leftRay = new Vector3(transform.position.x - 0.95f, transform.position.y, transform.position.z);
        Vector3 rightRay = new Vector3(transform.position.x + 0.95f, transform.position.y, transform.position.z);

        RaycastHit2D hitL = Physics2D.Raycast(leftRay, Vector2.down, rayLength);
        RaycastHit2D hitR = Physics2D.Raycast(rightRay, Vector2.down, rayLength);

        Debug.DrawRay(leftRay, Vector3.down, Color.cyan, rayLength);
        Debug.DrawRay(rightRay, Vector3.down, Color.cyan, rayLength);

        isGrounded = hitL.collider != null || hitR.collider != null;
    }
}
