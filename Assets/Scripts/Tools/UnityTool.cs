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
    
    /// <summary>
    /// 解析所有类型的文本文件 包括json txt csv 等
    /// </summary>
    /// <param name="jsonFileName">文件名</param>
    /// <param name="lastname">后缀名</param>
    /// <returns></returns>
    public static string ReadTextFileToString(string jsonFileName,string lastname)
    {


        if (!Directory.Exists("TextFile"))
        {
            Directory.CreateDirectory("TextFile");  //创建文件夹
        }
        if (File.Exists("TextFile/" + jsonFileName + lastname))
        {
            FileInfo fileInfo = new FileInfo("TextFile/" + jsonFileName + lastname);
            StreamReader streamReader = fileInfo.OpenText();
            Debug.Log("文件读取成功");
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
    /// 将数据添加到末尾
    /// </summary>
    public static void WriteTextAddEnd(string FileName,string lastname,string data)
    {
        string path = "TextFile/" + FileName + lastname;
        if (!Directory.Exists("TextFile"))
         {
            Directory.CreateDirectory("TextFile");  //创建文件夹
        }

        if (File.Exists(path))
        {
            StreamWriter sw = new StreamWriter(path, true);
            sw.WriteLine(data);
            sw.Close();
        }

        else
        {
            FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);
            StreamWriter m_streamWriter = new StreamWriter(fs, Encoding.UTF8);   //UTF8格式写入
            //m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
            m_streamWriter.WriteLine(data);
            m_streamWriter.Flush();
            m_streamWriter.Close();
        }
    }
    /// <summary>
    /// 将数据写入文本文件
    /// </summary>
    /// <param name="jsonFileName"></param>
    /// <param name="lastname"></param>
    /// <param name="data"></param>
    public static void WriteTextToFile(string jsonFileName, string lastname,string data)
    {
        string path = "TextFile/" + jsonFileName + lastname;
        if (!Directory.Exists("TextFile"))
        {
            Directory.CreateDirectory("TextFile");  //创建文件夹
        }
        if (File.Exists(path))
        {
            Debug.Log("有文件修改成功");
            File.WriteAllText(path, data);
        }
        else
        {
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter m_streamWriter = new StreamWriter(fs, Encoding.UTF8);   //UTF8格式写入
            m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
            m_streamWriter.WriteLine(data);
            m_streamWriter.Flush();
            m_streamWriter.Close();
        }
    }

}
