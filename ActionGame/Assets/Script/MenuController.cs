using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    #region 变量定义
    public Color purple;
    public SkinnedMeshRenderer headMeshRenderer;
    public SkinnedMeshRenderer handMeshRenderer;
    public SkinnedMeshRenderer[] bodyMeshRenderer;
    public Mesh[] headMesh;
    public Mesh[] handMesh;
    private Color[] bodyColor;

    private int headMeshIndex = 0;
    private int handMeshIndex = 0;
    private int bodyColorIndex = 0;

    #endregion

    #region 初始化

    void Start()
    {
        //不销毁从次组件
        DontDestroyOnLoad(this.gameObject);
        bodyColor = new Color[]{ Color.blue, Color.cyan, Color.green, purple, Color.red };
        InitMesh();
    }

    /// <summary>
    /// 初始化角色外观
    /// </summary>
    private void InitMesh()
    {
        headMeshIndex = PlayerPrefs.GetInt("headMeshIndex", 0);
        handMeshIndex = PlayerPrefs.GetInt("handMeshIndex", 0);
        bodyColorIndex = PlayerPrefs.GetInt("bodyColorIndex", 0);

        ChangeHeadMesh(headMesh[headMeshIndex]);
        ChangeHandMesh(handMesh[handMeshIndex]);
        ChangeBodyColor(bodyColor[bodyColorIndex]);
    }

    #endregion

    #region 按钮回调

    /// <summary>
    /// 修改头部形状（mesh）
    /// </summary>
    /// <param name="mesh"></param>
    private void ChangeHeadMesh(Mesh mesh)
    {
        headMeshRenderer.sharedMesh = mesh;
    }

    /// <summary>
    /// 修改手形状
    /// </summary>
    /// <param name="mesh"></param>
    private void ChangeHandMesh(Mesh mesh)
    {
        handMeshRenderer.sharedMesh = mesh;
    }

    /// <summary>
    /// 下一个头部形状
    /// </summary>
    public void OnHeadMeshNext()
    {
        headMeshIndex++;
        headMeshIndex %= headMesh.Length;
        ChangeHeadMesh(headMesh[headMeshIndex]);
    }

    /// <summary>
    /// 下一个手臂形状
    /// </summary>
    public void OnHandMeshNext()
    {
        handMeshIndex++;
        handMeshIndex %= handMesh.Length;
        ChangeHandMesh(handMesh[handMeshIndex]);
    }

    /// <summary>
    /// Blue按钮回调
    /// </summary>
    public void OnChangeColorBlue()
    {
        ChangeBodyColor(Color.blue);
    }

    /// <summary>
    /// Cyan按钮回调
    /// </summary>
    public void OnChangeColorCyan()
    {
        ChangeBodyColor(Color.cyan);
    }

    /// <summary>
    /// Green按钮回调
    /// </summary>
    public void OnChangeColorGreen()
    {
        ChangeBodyColor(Color.green);
    }

    /// <summary>
    /// Purple按钮回调
    /// </summary>
    public void OnChangeColorPurple()
    {
        ChangeBodyColor(purple);
    }

    /// <summary>
    /// Red按钮回调
    /// </summary>
    public void OnChangeColorRed()
    {
        ChangeBodyColor(Color.red);
    }

    /// <summary>
    /// Play 按钮回调
    /// </summary>
    public void OnPlay()
    {
        Save();
    }

    #endregion

    #region 改变BODY颜色 && 保存角色外观信息

    /// <summary>
    /// 修改角色整体颜色
    /// </summary>
    /// <param name="color"></param>
    private void ChangeBodyColor(Color color)
    {
        foreach (SkinnedMeshRenderer renderer in bodyMeshRenderer)
        {
            renderer.material.color = color;
        }

        for (int i = 0; i < bodyColor.Length; i++)
        {
            if (color.Equals(bodyColor[i]))
            {
                bodyColorIndex = i;
                break;
            }
        }
    }

    /// <summary>
    /// 保存角色外观信息
    /// </summary>
    private void Save()
    {
        PlayerPrefs.SetInt("headMeshIndex", headMeshIndex);
        PlayerPrefs.SetInt("handMeshIndex", handMeshIndex);
        PlayerPrefs.SetInt("bodyColorIndex", bodyColorIndex);
    }
    #endregion
}
