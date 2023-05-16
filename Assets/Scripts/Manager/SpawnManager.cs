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
        public int SpawnCount;
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
            //GetLandSpawnPos();
            RollTime = 0;
        }

    }

    ArrayList GetSpawnPosOfEnemyLand1(int ColliderNum)//get landEnemy's spawn pos
    {
        //WallNum = Random.Range(0, 12);
        Collider2D Target = Walls[WallNum].GetComponent<Collider2D>();
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
        ArrayList SpawnInfo = new ArrayList
                {
                    SpawnPos,
                    FatherForword
                };

        return SpawnInfo;
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
        //round 1 there is 4 kind of enemies
        int LandCollider = Random.Range(0, 12);
        int FlyCollider = Random.Range(0, 6);
        int E1Num = Waves[WaveInterval].EnemyGroups[0].EnemyCount;
        int E2Num = Waves[WaveInterval].EnemyGroups[1].EnemyCount;
        int E3Num = Waves[WaveInterval].EnemyGroups[2].EnemyCount;
        int E4Num = Waves[WaveInterval].EnemyGroups[3].EnemyCount;
        ArrayList E1List = new ArrayList();
        ArrayList E2List = new ArrayList();
        ArrayList E3List = new ArrayList();
        ArrayList E4List = new ArrayList();
        if (E1Num != 0)
        {
            for (int i = 0; i < E1Num; i++)
            {
                E1List.Add(GetSpawnPosOfEnemyLand1(LandCollider));
            }
            for (int i = 0; i < E1Num; i++)
            {
                GameObject instance = Instantiate(Waves[WaveInterval].EnemyGroups[0].EnemyPrefebs, E1List[i].SpawnInfo.SpawnPos, Quaternion.identity);
                EnemyBase enemyBase = instance.GetComponent<EnemyBase>();
                enemyBase.GrivityDir = E1List[i].s
            }
        }
        if (E2Num != 0)
        {
            for (int i = 0; i < E2Num; i++)
            {
                ArrayList SpawnInfo = GetSpawnPosOfEnemyLand1(LandCollider);
                E2List.Add(SpawnInfo);
            }
        }
        if (E3Num != 0)
        {
            for (int i = 0; i < E3Num; i++)
            {
                Vector2 SpawnPos = GetSpawnPoint(FlyCollider);

                E3List.Add(SpawnPos);
            }
        }
        if (E4Num != 0)
        {
            for (int i = 0; i < E4Num; i++)
            {
                Vector2 SpawnPos = GetSpawnPoint(FlyCollider);

                E4List.Add(SpawnPos);
            }
        }

        yield return new WaitForSeconds(30f);
        StartCoroutine(SpawnEnemyInWaves());
    }
}



