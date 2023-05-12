using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public Vector3 GrivityDir;
    public Rigidbody2D ThisRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        ThisRigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        SetGravity();
    }

    void SetGravity()
    {
        if (GrivityDir != null)
        {
            ThisRigidbody.AddForce(-GrivityDir*10f);
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
}
