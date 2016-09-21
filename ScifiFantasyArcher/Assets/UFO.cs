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

            if (!destroyable)
            {
                //before setting destroyable allow the
                //word to be added. This prevents
                //adding more than one word from a multi-collision with a 
                //ufo and arrow. It happened sometimes
                GameController.GetInstance().AddWord();
            }
            destroyable = true;
        }
    }


    void OnBecameInvisible()
    {
        if(destroyable)
            Destroy(this.transform.root.gameObject);
    }


}
