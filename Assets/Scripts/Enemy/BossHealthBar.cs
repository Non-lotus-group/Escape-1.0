using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthBar : MonoBehaviour
{
    public EnemyHealth enemyHealth;
    public float Health;
    public float MaxHealth;
    public GameObject Bar;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        Health = enemyHealth.Health;
        MaxHealth = enemyHealth.MaxHealth;
        float Rate = Health / MaxHealth;
        Bar.transform.localPosition = new Vector3((float)(-0.5 * (1-Rate)), 0, -0.1f);
        Bar.transform.localScale = new Vector3(Rate, 1, 1);
    }
}
