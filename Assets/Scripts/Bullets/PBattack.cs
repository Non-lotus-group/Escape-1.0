using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBattack : MonoBehaviour
{
    public float Attack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void CallWhenHit() {
        if (GetComponent<MissileMove>() != null) {
            this.gameObject.GetComponent<MissileMove>().SelfDestroy();
        }
    }
}
