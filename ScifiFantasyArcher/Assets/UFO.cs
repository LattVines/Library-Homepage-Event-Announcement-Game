using UnityEngine;
using System.Collections;

public class UFO : MonoBehaviour {

    public AudioClip[] sfx_clinks;

    bool destroyable = false;


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Arrow")
        { 
                audio.PlayOneShot(sfx_clinks[Random.Range(0, sfx_clinks.Length)]);
                destroyable = true;
        }
    }


    void OnBecameInvisible()
    {
        if(destroyable)
            Destroy(this.transform.root.gameObject);
    }


}
