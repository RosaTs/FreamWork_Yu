using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesLoad{

    //string gameObjPath = "Obj";


    /// <summary>
    /// 加载游戏物体
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public GameObject LoadGameObject(string path)
    {
        return Resources.Load<GameObject>(path);
    }
    
    /// <summary>
    /// 加载音频资源
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static AudioClip LoadAudioClip(string path)
    {
        return Resources.Load<AudioClip>(path);
    }

    /// <summary>
    /// 加载图片资源
    /// </summary>
    /// <param name="path">资源路径</param>
    /// <returns></returns>
    public static Sprite LoadSprite(string path)
    {
        return Resources.Load<Sprite>(path);
    }

    /// <summary>
    /// 实例化一个游戏物体
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static GameObject CreateObj(string path)
    {
        GameObject obj = Resources.Load<GameObject>(path);
        
        if (obj!=null)
        {
            Object.Instantiate(obj);
            return Object.Instantiate(obj);
        }
        else
        {
            Debug.LogError("路径错误");
            return null;
        }
    }
    
    public static GameObject CreateObj(string path,Vector3 posion,Quaternion quaternion)
    {
        GameObject obj = Resources.Load<GameObject>(path);
        GameObject obj1 = GameObject.Instantiate(obj);
        obj1.transform.position = posion;
        obj1.transform.rotation = quaternion;
        return obj;
    }

    /// <summary>
    /// 实例化游戏物体
    /// </summary>
    /// <param name="path">游戏物体路径</param>
    /// <param name="partner">生成到的根节点</param>
    /// <returns></returns>
    public static GameObject CreateObj(string path, Transform partner)
    {
        GameObject obj = Resources.Load<GameObject>(path);
        if (obj!=null)
        {
            GameObject obj1 = Object.Instantiate(obj, partner);
            return obj1;
        }
        else
        {
            Debug.LogError("路径错误");
            return null;
        }
    }

    /// <summary>
    /// 实例化UI
    /// </summary>
    /// <param name="path"></param>
    /// <param name="partner"></param>
    public static GameObject CreateUI(string path, Transform partner)
    {
        GameObject obj = Resources.Load<GameObject>(path);
        if (obj != null)
        {
            GameObject obj1 = Object.Instantiate(obj, partner);
            obj1.GetComponent<RectTransform>().localPosition = Vector3.zero;
            return obj1;
        }
        else
        {
            Debug.LogError("路径错误");
            return null;
        }
    }
}
