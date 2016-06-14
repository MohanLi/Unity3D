using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {

    public float exitTime = 2;
	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, exitTime);
	}
	
}
