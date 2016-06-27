using UnityEngine;
using System.Collections;

public class PlayerIcon : MonoBehaviour {
    private Transform playerIcon;

	void Start () {
        playerIcon = MiniMap._instance.GetPlayerIcon();
	}
	
	void Update () {
        float y = transform.eulerAngles.y;
        playerIcon.eulerAngles = new Vector3(0, 0, -y);
	}
}
