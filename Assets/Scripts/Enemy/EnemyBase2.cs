using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase2 : MonoBehaviour
{
    public Vector3 GrivityDir;
    public Rigidbody2D ThisRigidbody;
    public GameObject Ebullet;
    public float AttackCoolDown;
    // Start is called before the first frame update
    void Start()
    {
        ThisRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SetGravity();
        Attack();
    }

    void SetGravity()
    {
        if (GrivityDir != null)
        {
            ThisRigidbody.AddForce(-GrivityDir * 10f);
            float Angle = Mathf.Atan2(GrivityDir.y, GrivityDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, Angle - 90));
        }

    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            ContactPoint2D contactPoint = other.contacts[0];
            GrivityDir = contactPoint.normal;
        }
    }
    public void Attack()
    {
        AttackCoolDown += Time.deltaTime;
        if (AttackCoolDown >= 1)
        {
            if (Ebullet != null)
            {
                Vector3 PlayerPos = GameObject.FindWithTag("Player").transform.position;
                Vector3 ShootDir = (PlayerPos - transform.position).normalized;
                float ShootAngle = Mathf.Atan2(ShootDir.y, ShootDir.x) * Mathf.Rad2Deg;
                Quaternion BulletRotation = Quaternion.AngleAxis(ShootAngle, Vector3.forward);
                GameObject instan = Instantiate(Ebullet, transform.position, BulletRotation);
                instan.transform.Translate(ShootDir * 2f);
                AttackCoolDown = 0;
            }
        }

    }
}
