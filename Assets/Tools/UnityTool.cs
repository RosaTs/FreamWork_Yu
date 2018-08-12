/*
    工具类
    功能：查找物体
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

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



    /// <summary>
    /// 读取json返回string类型的内容
    /// </summary>
    /// <param name="jsonFileName">文件名</param>
    public static string ReadJsonToString(string jsonFileName)
    {
        if (!Directory.Exists("JsonFile"))
        {
            Directory.CreateDirectory("JsonFile");  //创建文件夹
        }
        if (File.Exists("JsonFile/" + jsonFileName + ".json"))
        {
            FileInfo fileInfo = new FileInfo("JsonFile/" + jsonFileName + ".json");
            StreamReader streamReader = fileInfo.OpenText();
            Debug.Log("Json文件读取成功");
            string str = streamReader.ReadToEnd();
            streamReader.Close();               //文件流释放
            streamReader.Dispose();
            return str;
        }
        else
        {
            Debug.Log("路径或名字错误！！");
            return default(string);
        }
    }

    /// <summary>
    ///写入Json数据到文件
    /// </summary>
    /// <param name="jsonFileName"></param>
    /// <param name="data"></param>
    public static void WriteStringToJson(string jsonFileName, string data)
    {
        if (!Directory.Exists("JsonFile"))
        {
            Directory.CreateDirectory("JsonFile");  //创建文件夹
        }
        if (File.Exists("JsonFile/" + jsonFileName + ".json"))
        {
            Debug.Log("有文件修改成功");
            File.WriteAllText("JsonFile/" + jsonFileName + ".json", data);
        }
        else
        {
            FileStream fs = new FileStream("JsonFile/" + jsonFileName + ".json", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter m_streamWriter = new StreamWriter(fs,Encoding.UTF8);   //UTF8格式写入
            m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
            m_streamWriter.WriteLine(data);
            m_streamWriter.Flush();
            m_streamWriter.Close();
        }
    }


}
