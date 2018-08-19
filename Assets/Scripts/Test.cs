using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System.Drawing;
using MySql.Data.MySqlClient;
public class Test : MonoBehaviour {
  
    // Use this for initialization
    void Start () {
        string connetStr = "server=127.0.0.1;port=3306;user=root;password=root; database=myfirstsql;";
        // server=127.0.0.1/localhost 代表本机，端口号port默认是3306可以不写
        MySqlConnection conn = new MySqlConnection(connetStr);
        try
        {
            conn.Open();//打开通道，建立连接，可能出现异常,使用try catch语句
            print("已经建立连接");
            //在这里使用代码对数据库进行增删查改
        }
        catch (MySqlException ex)
        {
            print(ex.Message);
        }
        finally
        {
            conn.Close();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
