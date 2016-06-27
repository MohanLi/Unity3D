using UnityEngine;
using System.Collections;

public class PlayerDress : MonoBehaviour
{
    public SkinnedMeshRenderer headRenderer;
    public SkinnedMeshRenderer handRenderer;

    public SkinnedMeshRenderer[] bodyMesh;
    
    void Start()
    {
        InitDress();
    }

    void InitDress()
    {
        MenuController menuController = MenuController._instance;
        int headMeshIndex = PlayerPrefs.GetInt("headMeshIndex");
        int handMeshIndex = PlayerPrefs.GetInt("handMeshIndex");
        int bodyColorIndex = PlayerPrefs.GetInt("bodyColorIndex");

        Debug.Log("---------------------------");
        Debug.Log(menuController.bodyColor[bodyColorIndex]);

        headRenderer.sharedMesh = menuController.headMesh[headMeshIndex];
        handRenderer.sharedMesh = menuController.handMesh[handMeshIndex];

        foreach (SkinnedMeshRenderer meshRenderer in bodyMesh)
        {
            meshRenderer.material.color = menuController.bodyColor[bodyColorIndex];
        }
    }
}
