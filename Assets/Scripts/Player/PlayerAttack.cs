using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerVariable playerVariable;
    public Rigidbody2D ThisRigbody;
    public GameObject BulletPrefeb;
    public PlayerJump playerJump;
    public bool AttackReady = true;
    public float CoolDownCount = 2f;
    public float attackValue = 45f;
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
        Attack();
    }

    void Attack()
    {//实例化swordLight
        Quaternion SwordRotation = Quaternion.AngleAxis(playerJump.JumpAngle, Vector3.forward);
        if (AttackReady == false)
        {
            CoolDownCount -= Time.deltaTime;
            if (CoolDownCount < 0)
            {
                AttackReady = true;
                CoolDownCount = 2;
            }
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (AttackReady == true)
            {
                GameObject instance = Instantiate(BulletPrefeb, playerJump.SelfPos, SwordRotation);
                SwordAttack swordAttack = instance.GetComponent<SwordAttack>();
                swordAttack.AttackValue = attackValue;
                swordAttack.transform.localScale *= 1 + playerVariable.AttackScale;
                AttackReady = false;
            }
        }

    }
}
