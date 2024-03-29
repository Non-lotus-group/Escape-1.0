using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBullet : MonoBehaviour
{
    public float Damage;
    public float Rotation;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestory());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, Rotation);
    }

    IEnumerator SelfDestory() {

        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
        
    }
}
