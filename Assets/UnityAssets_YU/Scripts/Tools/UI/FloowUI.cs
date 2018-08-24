
using UnityEngine;
/// <summary>
/// 追踪3d游戏物体 可以由物体远近缩放物体大小 挂在3d物体身上
/// </summary>
/// 
public class FloowUI : MonoBehaviour {
    public RectTransform rectBloodPos;
    private Transform cam;

    public int offstex;
    public int offsety = 150;       //y轴偏移量
    float mid = 1;
    float dis;
    private void Start()
    {
        cam = GameObject.Find("Main Camera").transform;
        mid = dis;
    }
    // Update is called once per frame
    void Update()
    {
        dis = Vector3.Distance(cam.position,transform.position);
        rectBloodPos.sizeDelta = new Vector2(297.4f*(4/dis), 50* (4 / dis));
        //get ScreenPoint...Important
        Vector2 vec2 = Camera.main.WorldToScreenPoint(transform.position);

        rectBloodPos.anchoredPosition = new Vector2(vec2.x - Screen.width / 2 + 0, vec2.y - Screen.height / 2 + offsety* (4 / dis));//控制偏移量
    }
}
