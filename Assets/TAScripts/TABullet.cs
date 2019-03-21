using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// 飞行轨迹类型。
/// </summary>
public enum BulletTrackType
{
    /// <summary>
    /// 直线运动
    /// </summary>
    Line = 1,
    /// <summary>
    /// 曲线，默认贝塞尔曲线
    /// </summary>
    Curve = 2,
    /// <summary>
    /// LockTarget 追踪，锁定目标，实时更新轨迹
    /// </summary>
    Tracking = 3,
    /// <summary>
    /// 闪现，瞬移
    /// </summary>
    Blink = 4,

}
/// <summary>
/// 目标类型。
/// </summary>
public enum BulletTargetType
{
    /// <summary>
    /// 目标 GO
    /// </summary>
    T_GameObject = 1,
    /// <summary>
    /// 目标点
    /// </summary>
    T_Point = 2,
}



/// <summary>
/// 子弹/炮弹  基类
/// </summary>
public class TABullet : TASprite
{

    /// <summary>
    /// 子弹运行轨迹
    /// </summary>
    public BulletTrackType m_trackType;
    /// <summary>
    /// 飞行速度
    /// </summary>
    public float m_moveSpeed;

    /// <summary>
    /// 目标类型 Point or Go
    /// </summary>
    public BulletTargetType m_targetType;

    /// <summary>
    /// 始终朝向目标点。
    /// </summary>
    public bool m_isLookAt;

    //public Vector3 direction;

    /// <summary>
    /// 伤害值
    /// </summary>
    public float m_damage;

    /// <summary>
    /// 命中检测的触发范围 未使用物理碰撞检测，用距离检查。
    /// </summary>
    public float m_triggerRange = 0.1f;

    /// <summary>
    /// 命中后的爆炸特效。
    /// </summary>
    public GameObject m_explodeEffect;



    public GameObject m_TargetGo;
    public Vector3 m_targetPoint;
    public Vector3 m_startPoint;

    Vector3 m_endPoint;

    public void Fire(Vector3 _startPoint)
    {
        m_startPoint = _startPoint;
        this.transform.position = _startPoint;
        gameObject.SetActive(true);
        if (m_TargetGo != null)
        {
            m_endPoint = m_TargetGo.transform.position;
        }
        else
        {
            m_endPoint = m_targetPoint;
        }
        float distance = Vector3.Distance(m_startPoint, m_endPoint);

        float duration = m_moveSpeed <= 0 || distance == 0 ? 0 : distance / m_moveSpeed;
      
        var tween = this.transform.DOMove(m_endPoint, duration);
        tween.SetEase(Ease.Linear);
        tween.onComplete = () =>
        {
            Hit();
        };

        if (m_isLookAt)
        {   //需要朝向目标点。
            this.transform.LookAt(m_endPoint);
            if (m_trackType != BulletTrackType.Line)
            {
                //非直线运动需要在每次都设置一下
                tween.onUpdate = () =>
                {
                    this.transform.LookAt(m_endPoint);
                };
            }
        }
    }

    /// <summary>
    /// 命中目标/到达目标点。
    /// </summary>
    public void Hit()
    {
        Debug.Log("Bullet 命中！！！");
        //播放爆炸效果。
        if (m_explodeEffect != null)
        {
            Debug.Log("播放命中效果");
        }
        _ReleaseSelf();
    }



}
