using UnityEngine;
using System.Collections;

public class SFXController : MonoBehaviour {
	


	public void PlaySFX(AudioClip clip)
	{
		audio.PlayOneShot(clip);
	}



	public void  PlaySFX(params AudioClip[] clips)
	{
		int rand_index = Random.Range(0, clips.Length);
		audio.PlayOneShot(clips[rand_index]);

	}



}


/*
 * 
 * 
 *  this design was working but just wasn't very good. I watched a tutorial to find a better
 * design. And frankly, I'm not sure why I was trying to do it this way
 * 
[System.Serializable]
public class SFX__Locking_UNIT {
	public AudioClip clip; //the clip that will get played
	bool is_allowed = true; //the bool lock to prevent playing it too fast



	//provide the audio_Src that will play the clip
	public void PlayOneShotClip(AudioSource audio_src, SFXController invoke_Callback, string callback_name)
	{
		if(is_allowed){
			is_allowed = false;
			invoke_Callback.Invoke(callback_name, clip.length );
			audio_src.PlayOneShot(clip);
		}

	}
	public void UnlockClip(){
		is_allowed = true;
	}

}


*/