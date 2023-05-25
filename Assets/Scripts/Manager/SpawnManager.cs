using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public List<EnemyGroup> EnemyGroups;
    }
    [System.Serializable]
    public class EnemyGroup
    {
        public string EnemyName;
        public int EnemyCount;
        public float HealthTime;
        //public int SpawnCount;
        public GameObject EnemyPrefebs;
    }

    public List<Wave> Waves;
    public int CurrentWaveCount;//index of current wave
    public GameObject[] Walls;
    public GameObject Squares;
    public int WallNum;
    public float RollTime;
    public BoxCollider2D[] Boxs;
    public int WaveInterval = 0;
    public GameObject Boss;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyInWaves());

    }

    // Update is called once per frame
    void Update()
    {
        RollTime += Time.deltaTime;
        if (RollTime >= 1f)
        {
            RollTime = 0;
        }

    }

    void GetSpawnPosOfEnemyLand1(int ColliderNum, List<Vector3> posList, List<Vector3> normalList)//get landEnemy's spawn pos
    {
        //WallNum = Random.Range(0, 12);
        Collider2D Target = Walls[ColliderNum].GetComponent<Collider2D>();
        float WallSide = Random.Range(-1, 1) < 0 ? -1 : 1;
        float WallScale = Target.transform.localScale.x;
        Vector3 FatherPos = Target.transform.position;
        Vector3 FatherForword = Target.transform.right * WallSide * 0.9f;
        Vector3 AimPos = FatherPos + (FatherForword * WallScale);
        float LineLength = WallScale * 0.7f;
        Vector3 P1 = AimPos + Target.transform.up.normalized * LineLength;
        Vector3 P2 = AimPos - Target.transform.up.normalized * LineLength;
        float LineTime = Random.Range(0f, 1f);
        Vector3 LineNormal = P2 - P1;
        Vector3 SpawnPos = P1 + LineNormal * LineTime;
        posList.Add(SpawnPos);
        normalList.Add(FatherForword);

    }
    Vector2 GetSpawnPoint(int ColliderNum)
    {
        Vector2 ZoneSize = Boxs[ColliderNum].size;
        Vector2 zonePosition = Boxs[ColliderNum].transform.TransformPoint(Boxs[ColliderNum].offset);
        Vector2 spawnPosition = new Vector2(Random.Range(zonePosition.x - ZoneSize.x / 2f, zonePosition.x + ZoneSize.x / 2f),
            Random.Range(zonePosition.y - ZoneSize.y / 2f, zonePosition.y + ZoneSize.y / 2f));
        return spawnPosition;
    }
    IEnumerator SpawnEnemyInWaves()
    {
        if (WaveInterval == Waves.Count - 1)
        {
            Boss.SetActive(true);
            yield return null;
        }

        if (WaveInterval < Waves.Count - 1 )
        {
            //round 1 there is 4 kind of enemies
            int E1Num = Waves[WaveInterval].EnemyGroups[0].EnemyCount;
            int E2Num = Waves[WaveInterval].EnemyGroups[1].EnemyCount;
            int E3Num = Waves[WaveInterval].EnemyGroups[2].EnemyCount;
            int E4Num = Waves[WaveInterval].EnemyGroups[3].EnemyCount;
            List<Vector3> PosList1 = new List<Vector3>();
            List<Vector3> PosList2 = new List<Vector3>();
            List<Vector3> NormalList1 = new List<Vector3>();
            List<Vector3> NormalList2 = new List<Vector3>();
            if (E1Num != 0)
            {
                for (int i = 0; i < E1Num; i++)
                {
                    int LandCollider = Random.Range(0, 12);
                    GetSpawnPosOfEnemyLand1(LandCollider, PosList1, NormalList1);
                    GameObject instance = Instantiate(Waves[WaveInterval].EnemyGroups[0].EnemyPrefebs, PosList1[i], Quaternion.identity);
                    EnemyBase enemyBase = instance.GetComponent<EnemyBase>();
                    enemyBase.GrivityDir = NormalList1[i];
                }
            }
            if (E2Num != 0)
            {
                for (int i = 0; i < E2Num; i++)
                {
                    int LandCollider = Random.Range(0, 12);
                    GetSpawnPosOfEnemyLand1(LandCollider, PosList2, NormalList2);
                    GameObject instance = Instantiate(Waves[WaveInterval].EnemyGroups[1].EnemyPrefebs, PosList2[i], Quaternion.identity);
                    EnemyBase2 enemyBase2 = instance.GetComponent<EnemyBase2>();
                    enemyBase2.GrivityDir = NormalList2[i];
                }

            }
            if (E3Num != 0)
            {

                for (int i = 0; i < E3Num; i++)
                {
                    int FlyCollider = Random.Range(0, 5);
                    Vector2 SpawnPos = GetSpawnPoint(FlyCollider);

                    Instantiate(Waves[WaveInterval].EnemyGroups[2].EnemyPrefebs, SpawnPos, Quaternion.identity);
                }
            }
            if (E4Num != 0)
            {

                for (int i = 0; i < E4Num; i++)
                {
                    int FlyCollider = Random.Range(0, 5);
                    Vector2 SpawnPos = GetSpawnPoint(FlyCollider);

                    Instantiate(Waves[WaveInterval].EnemyGroups[3].EnemyPrefebs, SpawnPos, Quaternion.identity);
                }

            }
            WaveInterval += 1;
            yield return new WaitForSeconds(30f);
            StartCoroutine(SpawnEnemyInWaves());

        }

    }
}



