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
        if (Target == null) { StartCoroutine(FindEnemies()); }
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
        Destroy(gameObject);
    }

    IEnumerator FindEnemies()
    {
        GameObject[] TargetArray = GameObject.FindGameObjectsWithTag("Enemy");
        int Length = TargetArray.Length;
        if (Length != 0)
        {
            Target = TargetArray[Random.Range(0, TargetArray.Length)].transform;
        }
        else {
            yield return new WaitForSeconds(3f);
            GameObject[] TargetArray2 = GameObject.FindGameObjectsWithTag("Enemy");
            int Length2 = TargetArray.Length;
            if (Length2 != 0)
            {
                StartCoroutine(FindEnemies());
            }
            else { Destroy(gameObject); }
        }
        yield return null;
    }
}
