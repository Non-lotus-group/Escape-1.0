using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public PlayerVariable Pv;
    public GameObject Bar;

    // Start is called before the first frame update
    void Start()
    {
        Pv = GetComponent<PlayerVariable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Pv.Health >= Pv.MaxHealth)
        {
            Pv.Health = Pv.MaxHealth;

        }
        if (Pv.Health <= 0) {
            Destroy(this.gameObject);
        }

        float Rate = Pv.Health / Pv.MaxHealth;
        Bar.transform.localPosition = new Vector3((float)(-0.5 * (1 - Rate)), 0, -0.1f);
        Bar.transform.localScale = new Vector3(Rate, 1, 1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyBullet") {
            Pv.Health -= collision.GetComponent<EnemyBullet>().Attack;
        }
    }
}
