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
    public float LTimer;
    public float RTimer;
    // Start is called before the first frame update
    void Start()
    {
        playerVariable = GetComponent<PlayerVariable>();
        ThisRigbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        left();
        Right();
    }

    void left()
    {
        LTimer += Time.deltaTime;
        if (RTimer >= RightCoolDown)
        {
            RTimer = RightCoolDown + 1;
            if (Input.GetKey(KeyCode.Q))
            {
                LTimer = 0;
            }
        }

    }

    void Right()
    {
        RTimer += Time.deltaTime;
        if (RTimer >= LeftCoolDown)
        {
            RTimer = RightCoolDown + 1;
            if (Input.GetKey(KeyCode.E))
            {
                RTimer = 0;
            }
        }

    }

}
