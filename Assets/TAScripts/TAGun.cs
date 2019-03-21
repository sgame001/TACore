using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
/// <summary>
/// 枪炮 等 发射 Bullet 使用
/// </summary>
public class TAGun : TASprite {

    public GameObject targetGo;

    /// <summary>
    /// 射击点
    /// </summary>
    public Transform m_firePoint;

    public TABullet bullet;
    /// <summary>
    /// 射击枪口特效
    /// </summary>
    public GameObject m_fireEffect;
    /// <summary>
    /// 射击间隔。
    /// </summary>
    public float m_shootInterval;
    /// <summary>
    /// 无限子弹，无需换弹夹
    /// </summary>
    public bool WANRLTW = true;
    /// <summary>
    /// 装填弹夹耗时
    /// </summary>
    public float m_reloadTime = 0;
    /// <summary>
    /// 弹夹容量上限
    /// </summary>
    public int m_capacityMax = 0;
    /// <summary>
    /// 初始弹夹容量
    /// </summary>
    public int m_capacityInit = 0;


    [Button(ButtonSizes.Large), GUIColor(0, 1, 0)]
    private void TestShoot()
    {
        FindTarget();
    }


    public override void _Update()
    {
        base._Update();
      

    }



    /// <summary>
    /// 查找目标。
    /// </summary>
    public void FindTarget()
    {
        if (targetGo != null)
        {

            DoFire();
        }
    }

    /// <summary>
    /// 开火。
    /// </summary>
    public void DoFire()
    {
        if (bullet == null) return;

        var go = GameObject.Instantiate(bullet.gameObject);
        var b = go.GetComponent<TABullet>();

        b.Fire(m_firePoint.position);
    }
}
