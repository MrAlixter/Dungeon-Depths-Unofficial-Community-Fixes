using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
	void Start () {
        Master.instance.staticMap[(int)transform.position.x, (int)transform.position.y] = this.gameObject;
    }
}
