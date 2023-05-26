using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyShootEnemy : MonoBehaviour
{
    public GameObject Ebullet;
    public float AttackCoolDown = 3f;
    public float attack = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
    void Attack() {
        AttackCoolDown += Time.deltaTime;
        if (AttackCoolDown >= 2)
        {
            if (Ebullet != null)
            {
                Vector3 PlayerDir = (GameObject.FindWithTag("Player").transform.position - transform.position).normalized;
                GameObject instance = GameObject.Instantiate(Ebullet, transform.position, Quaternion.identity);
                instance.GetComponent<EnemyBullet>().PlayerDir = PlayerDir;
                instance.GetComponent<EnemyBullet>().Attack = attack;
                AttackCoolDown = 0;
            }
        }
    }
}
