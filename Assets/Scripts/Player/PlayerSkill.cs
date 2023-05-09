using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public float LeftCoolDown = 4f;
    public float RightCoolDown = 4f;
    public PlayerVariable playerVariable;
    public Rigidbody2D ThisRigbody;
    public PlayerJump playerJump;
    public float LTimer;
    public float RTimer;
    public float Distance;
    public GameObject SkillBullet;
    public float AttackValue = 80f;
    // Start is called before the first frame update
    void Start()
    {
        playerVariable = GetComponent<PlayerVariable>();
        ThisRigbody = GetComponent<Rigidbody2D>();
        playerJump = GetComponent<PlayerJump>();
    }

    // Update is called once per frame
    void Update()
    {
        left();
        Right();
    }

    void left()
    {// can not move into wall 
        Distance = Vector2.Distance(playerJump.SelfPos, playerJump.MousePos);
        LTimer += Time.deltaTime;
        if (RTimer >= RightCoolDown)
        {
            LTimer = RightCoolDown + 1;
            if (Input.GetKeyDown(KeyCode.Q))
            {
                LTimer = 0;
                if (Distance < 10f)
                {
                    this.transform.position = playerJump.MousePos;
                }
                else
                {
                    transform.position -= new Vector3(playerJump.JumpDir.x, playerJump.JumpDir.y, 0);
                }
            }
        }

    }

    void Right()
    {
        RTimer += Time.deltaTime;
        Quaternion SwordRotation = Quaternion.AngleAxis(playerJump.JumpAngle, Vector3.forward);
        if (RTimer >= LeftCoolDown)
        {
            RTimer = RightCoolDown + 1;
            if (Input.GetKeyDown(KeyCode.E))
            {
                RTimer = 0;
                GameObject instance = Instantiate(SkillBullet, playerJump.SelfPos, SwordRotation);
                instance.transform.localScale = new Vector3(4, 4, 4);
                SwordAttack swordAttack = instance.GetComponent<SwordAttack>();
                swordAttack.AttackValue = AttackValue;
            }
        }

    }

}
