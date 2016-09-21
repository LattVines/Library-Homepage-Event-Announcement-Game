using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public GameObject arrow_obj;//SET IN EDITOR
    public AudioClip[] sfxs_shoot;//SET IN EDITOR
    public Transform shoot_point;//SET IN EDITOR
    Animator anim;
    public AnimationClip shoot_clip_for_time;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public float scaler = 10f;



    Vector3 click_pos;
    float charge_time;
    public void Shoot(Vector3 click_pos, float charge_time)
    {
        this.click_pos = click_pos;
        this.charge_time = charge_time;
        anim.SetTrigger("shoot");
        Invoke("TriggerActualShoot", shoot_clip_for_time.length);


    }



    //need to sync the animation for shooting with the actual
    //shoot
    public void TriggerActualShoot()
    {
        click_pos = new Vector3(click_pos.x, click_pos.y, 0f);
        GameObject arrow = Instantiate(arrow_obj, shoot_point.position, Quaternion.identity) as GameObject;
        ApplyArrowForce(arrow.rigidbody2D, click_pos, charge_time);
        audio.PlayOneShot(sfxs_shoot[Random.RandomRange(0, sfxs_shoot.Length)]);
        
    }

    public void ApplyArrowForce(Rigidbody2D rigbod, Vector3 aim, float charge_time)
    {
        Vector3 applied_force;




        //handle rotation toward the target
        float rotation_angle = AngleBetweenVector2(shoot_point.position, aim);
        rigbod.transform.eulerAngles = new Vector3(0f, 0f, rotation_angle);
        //---------------------

        if (aim.x <= shoot_point.position.x) applied_force = Vector3.zero;
        else
        {
            
            charge_time = (charge_time + 1f) * scaler;
            charge_time = Mathf.Clamp(charge_time, 0, 30f);
            //Debug.Log("shoot_point: " + shoot_point.position);
            //Debug.Log("aim: " + aim);
            //Debug.Log("calculated: " + Vector3.MoveTowards(shoot_point.position, aim, float.MaxValue));
            Vector3 direction = aim - shoot_point.position;
            applied_force = charge_time * direction;
        }

        rigbod.AddForce( applied_force,  ForceMode2D.Impulse );
    }


    private float AngleBetweenVector2(Vector3 vec1, Vector3 vec2)
    {
        Vector2 diference = vec2 - vec1;
        float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
        return Vector2.Angle(Vector2.right, diference) * sign;
    }

}
