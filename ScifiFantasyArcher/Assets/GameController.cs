using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    Player player;
    Words words;
    bool is_charging = false;

    static GameController instance = null;

	void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }


        player = FindObjectOfType<Player>();
        words = FindObjectOfType<Words>();
    }

    public static GameController GetInstance()
    {
        return instance;
    }


    public void AddWord()
    {
        words.AddWord();
    }

    void Update()
    {
        GetMouseClicks();
    }

    void GetMouseClicks()
    {
        if(Input.GetMouseButton(0) && !is_charging)
        {
            is_charging = true;
            //Debug.Log("starting routine");
            StartCoroutine(arrow_charger());
        }
    }


    IEnumerator arrow_charger()
    {
        float charge_time = 0f;
        while (Input.GetMouseButton(0))
        {
            charge_time += Time.deltaTime;
            //Debug.Log("charge loop ran");
            yield return null;
        }


        //Debug.Log("charge time was: " + charge_time);
        player.Shoot(Camera.main.ScreenToWorldPoint(Input.mousePosition), charge_time);


        //delay before allowing another shot
        yield return new WaitForSeconds(0.2f);
        is_charging = false;

        yield return null;
    }

}
