using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamGetPlayer : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        if (Player != null)
        {
            Vector3 PlayerPosition = new Vector3(Player.transform.position.x, Player.transform.position.y, -10f);
            transform.position = Vector3.Lerp(transform.position, PlayerPosition, 15f * Time.deltaTime);
        }

    }
}
