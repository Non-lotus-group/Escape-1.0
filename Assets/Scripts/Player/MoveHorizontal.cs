using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHorizontal : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerVariable playerVariable;
    public Rigidbody2D ThisRigbody;
    private void Start()
    {
        playerVariable = GetComponent<PlayerVariable>();
        ThisRigbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (playerVariable.IsWalking == true)
        {
            ThisRigbody.AddForce(-playerVariable.GrivityDir * 120f);
            transform.Translate(Vector2.right * Input.GetAxis("Horizontal") *3f* Time.deltaTime);
            float Angle = Mathf.Atan2(playerVariable.GrivityDir.y, playerVariable.GrivityDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, Angle - 90));
        }
    }
}
