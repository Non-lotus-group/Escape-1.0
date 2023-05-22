using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public float AttackValue;
    public Rigidbody2D SwordRigid;
    public Vector2 ThisPos;
    public float SelfFlySpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        SwordRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SwordRigid.velocity = transform.right * SelfFlySpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
        }
        else { }
    }
}
