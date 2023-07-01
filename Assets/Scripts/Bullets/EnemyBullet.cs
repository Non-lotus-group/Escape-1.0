using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// manage enemies' bullet 
public class EnemyBullet : MonoBehaviour
{
    public Vector3 PlayerDir;
    public float Attack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(PlayerDir*Time.deltaTime*3f);
    }
}
