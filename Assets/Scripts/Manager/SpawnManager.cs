using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Walls;
    public GameObject Squares;
    public int WallNum;
    public Vector3 SpawnPos;
    public Vector3 P1;
    public Vector3 P2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetLandSpawnPos();
    }

    void GetLandSpawnPos()
    {
        GetLine();
        GetPoint();
    }

    void GetLine()
    {
        WallNum = Random.Range(0, 12);
        Collider2D Target = Walls[WallNum].GetComponent<Collider2D>();
        float WallSide = Random.Range(-1, 1) < 0 ? -1 : 1;
        float WallScale = Target.transform.localScale.x;
        Vector3 FatherPos = Target.transform.position;
        Vector3 FatherForword = Target.transform.right * WallSide;
        Vector3 AimPos = FatherPos + (FatherForword * WallScale);
        float LineLength = WallScale * 0.8f;
        P1 = AimPos + Target.transform.up.normalized * LineLength;
        P2 = AimPos - Target.transform.up.normalized * LineLength;
        float LineTime = Random.Range(0f, 1f);
        Vector3 LineNormal = P2 - P1;
        SpawnPos = P1 + LineNormal * LineTime;
    }
    void GetPoint() { }
}


