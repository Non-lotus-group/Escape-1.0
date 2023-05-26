using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SelfExplodeFly : MonoBehaviour
{
    public GameObject Player;
    bool Trigger = false;
    public float Speed = 5f;
    public float RotateSpeed = 100f;
    public Rigidbody2D Rb;
    public Collider2D C1;
    public Collider2D C2;
    Transform Pt;
    Transform Ts;
    public Vector2 Dir;
    float Health = 100f;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Rb = GetComponent<Rigidbody2D>();
        Pt = Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerCollections>().CallFromOutside();
            Destroy(this.gameObject);
        }
    }
    void DashToPlayer()
    {
        if (!Trigger)
        {
            Vector2 Dir = (Vector2)Player.transform.position - Rb.position;
            Dir.Normalize();
            float RotationAmout = Vector3.Cross(Dir, transform.up).z;
            Rb.angularVelocity = -RotationAmout * RotateSpeed;
            Rb.velocity = transform.up * Speed;
        }
        if (Trigger)
        {
            Rb.velocity = Dir.normalized * Speed;
            StartCoroutine(Wait());
        }
    }
    private void FixedUpdate()
    {
        DashToPlayer();
        MathfDir();
    }

    void MathfDir()
    {
        if (!Trigger)
        {

            Dir = Pt.position - this.transform.position;
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.IsTouching(C1))
        {
            if (other.tag == "Player")
            {
                Trigger = true;
                C1.enabled = !C1.enabled;
            }


        }
        if (other.IsTouching(C2))
        {
            if (other.tag == "PlayerBullet")
            {
                float Dam = other.GetComponent<PBattack>().Attack;
                other.GetComponent<PBattack>().CallWhenHit();
                Health -= Dam;
            }
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        Rb.velocity = new Vector2(0, 0);
        if ((Player.transform.position - transform.position).magnitude <= 1f)
        {
            Player.GetComponent<PlayerVariable>().Health -= 45f;
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
