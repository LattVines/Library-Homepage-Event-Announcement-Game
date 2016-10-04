using UnityEngine;
using System.Collections;

public class DestroyIfNotVisible : MonoBehaviour {



	void Update () {
       // if (!this.renderer.isVisible) Destroy(this.transform.root.gameObject);
      
	}

    void OnBecameInvisible()
    {
        Destroy(this.transform.root.gameObject);
    }
}
