using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public PlayerVariable playerVariable;
    public Rigidbody2D ThisRigbody;
    public Vector2 MousePos;
    public Vector2 SelfPos;
    public Vector2 JumpDir;
    public float JumpAngle;

    private void Start()
    {
        playerVariable = GetComponent<PlayerVariable>();
        ThisRigbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {


    }
    private void Update()
    {
        GetMousePos();
        RotateWithMouse();
        Jump();
    }
    void GetMousePos()
    {
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        SelfPos = this.transform.position;
        JumpDir = (MousePos - SelfPos).normalized;
        JumpAngle = Mathf.Atan2(MousePos.y - SelfPos.y, MousePos.x - SelfPos.x) * Mathf.Rad2Deg;
    }

    void Jump()
    {
        if (playerVariable.AbleJump == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<CapsuleCollider2D>().enabled = !GetComponent<CapsuleCollider2D>().enabled;
                playerVariable.GrivityDir = new Vector2(0, 0);
                playerVariable.IsWalking = false;
                playerVariable.IsJump = true;
                playerVariable.AbleJump = false;
                ThisRigbody.AddForce(JumpDir * (playerVariable.JumpCount + 1), ForceMode2D.Impulse);
                playerVariable.JumpCount++;
                StartCoroutine(SetColliderActive());
                Debug.Log(playerVariable.JumpCount);
            }
        }
    }
    void RotateWithMouse()
    {
        if (playerVariable.IsJump == true)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, JumpAngle - 90));
        }

    }
    IEnumerator SetColliderActive()
    {
        yield return null;
        GetComponent<CapsuleCollider2D>().enabled = true;
    }
}
