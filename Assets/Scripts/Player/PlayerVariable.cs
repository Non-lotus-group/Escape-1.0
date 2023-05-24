using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariable : MonoBehaviour
{
    public bool IsWalking = false;
    public Vector2 GrivityDir;
    public bool AbleJump;
    public bool IsJump;
    public int JumpCount = 0;
    public float MaxHealth = 200f;
    public float Health = 200f;
    public float AttackScale;
    public GameObject Missile;
    public float CoolDownCount = 2f;
    public float RealCoolDown;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
}
