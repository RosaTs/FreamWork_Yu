/*
    工具类
    功能：查找物体
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityTool : MonoBehaviour {

    /// <summary>
    /// 通过名字查找子物体
    /// </summary>
    /// <param name="parent">自身</param>
    /// <param name="childName"></param>
    /// <returns></returns>
    public static GameObject FindGameObject(GameObject parent, string childName)
    {
        if (parent.name == childName)
        {
            return parent;
        }
        if (parent.transform.childCount < 1)
        {
            return null;
        }
        GameObject obj = null;
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            GameObject go = parent.transform.GetChild(i).gameObject;
            obj = FindGameObject(go, childName);
            if (obj != null)
            {
                break;
            }
        }
        return obj;
    }

    

}
