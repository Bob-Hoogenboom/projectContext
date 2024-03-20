using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject isCorrect;
    [SerializeField] private Rigidbody2D rigidbody2d;

    private bool isHolding;
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
            return;
        }
        isHolding = true;
        rigidbody2d.isKinematic = false;
    }

    //Invokes when the block is placed in the right goal position
    public void Glowing(bool state)
    {
        isCorrect.SetActive(state);
    }
}
