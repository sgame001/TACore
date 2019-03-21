using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 场景 精灵，所有在3D 世界中显示的元素基类。 
/// </summary>
public class TASprite : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
        _Start();
    }
	
	// Update is called once per frame
	void Update () {
        _Update();
    }
    public virtual void _Init()
    {

    }
    /// <summary>
    /// 
    /// </summary>
    public virtual void _Start()
    {

    }

    public virtual void _Update()
    {

    }

    /// <summary>
    /// 释放 精灵
    /// </summary>
    public virtual void _ReleaseSelf()
    {
        //暂时先隐藏/销毁自己，之后要回收到对象池。
        Debug.Log("Release 回收 Bullet!!");
        Destroy(this.gameObject);
    }
}
