using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public Vector3 GrivityDir;
    public Rigidbody2D ThisRigidbody;
    public bool AbleWalk;
    public GameObject Ebullet;
    public float attack = 5f;
    // Start is called before the first frame update
    void Start()
    {
        AbleWalk = false;
        ThisRigidbody = GetComponent<Rigidbody2D>();
        Walk();
    }

    // Update is called once per frame
    void Update()
    {
        SetGravity();
        Walk();
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
            AbleWalk = true;
        }
    }
    public void Walk()
    {
        if (AbleWalk == true)
        {
            transform.Translate(Vector3.right * Time.deltaTime);
            if (ThisRigidbody.velocity.magnitude > 4f)
            {
                ThisRigidbody.velocity = ThisRigidbody.velocity * 0.5f;
            }
        }
    }
    public void Attack()
    {
        if (AbleWalk == false)
        {
            if (Ebullet != null)
            {
                Debug.Log("11");
                Vector3 PlayerPos = GameObject.FindWithTag("Player").transform.position;
                Vector3 ShootDir = (PlayerPos - transform.position).normalized;
                GameObject instan = GameObject.Instantiate(Ebullet, transform.position, Quaternion.identity);
                instan.transform.Translate(ShootDir * 2f);
                instan.GetComponent<EnemyBullet>().Attack = attack;
                Debug.Log(instan.GetComponent<EnemyBullet>().Attack);
            }

        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerVariable>().Health -= attack;
            Debug.Log("11");
            StartCoroutine(HeartPlayer());
        }

    }

  

    IEnumerator HeartPlayer() {
        yield return new WaitForSeconds(2f);
    }
}
