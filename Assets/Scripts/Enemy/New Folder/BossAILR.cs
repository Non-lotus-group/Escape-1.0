using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAILR : MonoBehaviour
{
    public float AttackValue;
    public GameObject Bullet;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FirShotgun());
    }

    // Update is called once per frame
    void Update() { }

    IEnumerator FirShotgun()
    {
        Vector3 bulletDir = transform.right; //由于资源的原因，我们这边的发射方向为物体的Up轴方向
        Quaternion leftRota = Quaternion.AngleAxis(-30, Vector3.forward);
        Quaternion RightRota = Quaternion.AngleAxis(30, Vector3.forward); //使用四元数制造2个旋转，分别是绕Z轴朝左右旋转30度
        for (int i = 0; i < 10; i++) //散弹发射次数
        {
            for (int j = 0; j < 9; j++) //一次发射3颗子弹
            {
                switch (j)
                {
                    case 0:
                        CreatBullet(bulletDir, transform.position); //发射第一颗子弹，方向不需要进行旋转。参数为子弹运动方向与生成位置，函数实现未列出。
                        break;
                    case 1:
                        bulletDir = RightRota * bulletDir; //第一个方向子弹发射完毕，旋转方向到下一个发射方向
                        CreatBullet(bulletDir, transform.position); //调用生成子弹函数，参数为发射方向与生成位置。
                        break;
                    case 2:
                        bulletDir = leftRota * (leftRota * bulletDir); //右边方向发射完毕，得向左边旋转2次相同的角度才能到达下一个发射方向
                        CreatBullet(bulletDir, transform.position);
                        bulletDir = RightRota * bulletDir; //一轮发射完毕，重新向右边旋转回去，方便下一波使用
                        break;
                    case 3:
                        bulletDir = RightRota * (RightRota * bulletDir); //左边方向发射完毕，得向右边旋转2次相同的角度才能到达下一个发射方向
                        CreatBullet(bulletDir, transform.position); //发射第一颗子弹，方向不需要进行旋转。参数为子弹运动方向与生成位置，函数实现未列出。
                        bulletDir = leftRota * bulletDir;
                        break;
                }
            }
            yield return new WaitForSeconds(0.1f); //协程延时0.5秒进行下一波发射
        }
        StartCoroutine(FirShotgun());
    }

    void CreatBullet(Vector3 Dir, Vector3 Pos)
    {
        GameObject Inst = GameObject.Instantiate(Bullet, Pos, Quaternion.identity);
        Inst.GetComponent<Rigidbody2D>().AddForce(Dir*2f, ForceMode2D.Impulse);
        Inst.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        Inst.GetComponent<EnemyBullet>().Attack = 10f;
    }
}
