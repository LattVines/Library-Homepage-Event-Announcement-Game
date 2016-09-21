using UnityEngine;
using System.Collections;

public class DestroyWithTime : MonoBehaviour {

	public float delay = 3f;

	// Use this for initialization
	void Start () {
		Destroy(this.gameObject, delay);
	}
	

}
