using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public PlayerVariable Pv;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Pv.Health >= Pv.MaxHealth) {
            Pv.Health = Pv.MaxHealth;
        }
    }
}
