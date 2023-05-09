using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public PlayerVariable playerVariable;
    public Rigidbody2D ThisRigbody;
    public BoxCollider2D BoxCollider;
    public CapsuleCollider2D CapCollider;
    private void Start()
    {
        playerVariable = GetComponent<PlayerVariable>();
        ThisRigbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            ContactPoint2D contactPoint = other.contacts[0];
            playerVariable.GrivityDir = contactPoint.normal;

            if (CapCollider.IsTouching(other.collider))
            {
                playerVariable.IsWalking = true;
                ThisRigbody.gravityScale = 0;

                playerVariable.AbleJump = true;
                playerVariable.IsJump = false;
            }
            else
            {
                ThisRigbody.AddForce(playerVariable.GrivityDir * (playerVariable.JumpCount + 1), ForceMode2D.Impulse);
                //will make player cannot move for few seconds

            }
        }
    }
}
