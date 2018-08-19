using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 单例模板练习
/// </summary>
public class Singleton<T> where T:new(){

    private static readonly T instance = new T();

    public static T Instance
    {
        get
        {
            return instance;
        }
    }
}
