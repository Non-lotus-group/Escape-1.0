using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAILD : MonoBehaviour
{
    public GameObject Player;
    public GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Attack()
    {
        Vector3 Dir = Player.transform.position - transform.position;
        GameObject gameObject = GameObject.Instantiate(Bullet, transform.position, Quaternion.identity);
        gameObject.GetComponent<Rigidbody2D>().AddForce(Dir.normalized * 8f, ForceMode2D.Impulse);
        gameObject.GetComponent<EnemyBullet>().Attack = 15f;
        yield return new WaitForSeconds(2f);
        StartCoroutine(Attack());
    }
}
