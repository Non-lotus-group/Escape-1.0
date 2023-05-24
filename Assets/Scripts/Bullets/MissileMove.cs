using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMove : MonoBehaviour
{
    public Transform Target;
    public GameObject[] Enemies;
    public float Speed = 5f;
    public float RotateSpeed = 200f;
    public Rigidbody2D Rb;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FindEnemies());
        Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        Vector2 Dir = (Vector2)Target.position - Rb.position;
        Dir.Normalize();
        float RotationAmout = Vector3.Cross(Dir, transform.up).z;
        Rb.angularVelocity = -RotationAmout * RotateSpeed;
        Rb.velocity = transform.up * Speed;
    }
    public void SelfDestroy()
    {
        Destroy(this.gameObject);
    }

    IEnumerator FindEnemies()
    {
        //waiting for finf an enemy
        yield return null;
    }
}
