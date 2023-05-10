using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Walls;
    public GameObject Squares;
    public int tex;
    public float i;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int CollNum = Random.Range(0, 12);
        Collider2D Target = Walls[CollNum].GetComponent<Collider2D>();
        Vector3 TarSca = Target.transform.localScale;
        Vector3 FatherPos = Target.transform.position;
        Vector3 forward = Target.transform.right;
        Vector3 AinPos = FatherPos + (forward * TarSca.z);
        //* o r-
        float length = TarSca.z * 0.8f;
        Vector3 p1 = AinPos + Target.transform.up.normalized * length;
        Vector3 p2 = AinPos - Target.transform.up.normalized * length;
        //get a point on line-p1-p2
        // mathf normal p1-p2 and length random.range(length) then p1 + normal get point
        Debug.DrawLine(p1, p2, Color.red, 100f);
    }
}

//    i += Time.deltaTime;
//    if (i >= 0.5f)
//    {


//    }
//    int CollNum = Random.Range(0, 12);
//    Collider2D Target = Walls[CollNum].GetComponent<Collider2D>();
//    Vector3 TarSca = Target.transform.localScale;
//    Vector3 FatherPos = Target.transform.position;
//    Vector3 Pos = FatherPos + new Vector3(Random.Range(-0.8f, 0.8f) * Target.transform.localScale.z, 1.1f * TarSca.z, 0);
//    Vector3 normal = Pos - FatherPos;Debug.Log(Target.transform.right);
//    float angle = Vector3.Angle(Pos, FatherPos);
//    Vector3 normal2 = Quaternion.AngleAxis( angle, Target.transform.forward) * Target.transform.right * normal.magnitude;
//    Debug.DrawLine(FatherPos, FatherPos+normal2, Color.red, 100f);
//}


