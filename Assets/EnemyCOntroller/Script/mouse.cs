using UnityEngine;

public class mouse: MonoBehaviour
{
    public GUIStyle guiStyle; // GUI样式
    public Texture2D cursorTexture; // 光标纹理
    public Vector2 cursorHotspot; // 光标热点

    void Start()
    {
        // 隐藏系统光标
        Cursor.visible = false;
    }

    void OnGUI()
    {
        // 获取鼠标位置
        Vector2 mousePosition = Event.current.mousePosition;
        mousePosition.y = Screen.height - mousePosition.y; // 将y坐标转换为屏幕坐标系

        // 显示鼠标位置
        GUI.Label(new Rect(mousePosition.x + 10f, mousePosition.y - 10f, 100f, 20f), "Mouse: (" + mousePosition.x + ", " + mousePosition.y + ")", guiStyle);

        // 显示移动的点
        GUI.DrawTexture(new Rect(mousePosition.x - cursorHotspot.x, mousePosition.y - cursorHotspot.y, cursorTexture.width, cursorTexture.height), cursorTexture);
    }

    void OnDestroy()
    {
        // 恢复系统光标
        Cursor.visible = true;
    }
}
