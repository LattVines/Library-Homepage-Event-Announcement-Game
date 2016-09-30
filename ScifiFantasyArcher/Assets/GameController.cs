using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    Player player;
    Words words;
    bool is_charging = false;
    public bool game_is_running = false;

    public Text score_text;//set in editor
    int score = 0;
    public GameObject reloaderbutton;//set in editor
    public GameObject titleScreen;//set in editor
    public GameObject facebookButton;//set in editor

    static GameController instance = null;

	void Awake()
    {
        
        instance = this;

        player = FindObjectOfType<Player>();
        words = FindObjectOfType<Words>();
    }

    public static GameController GetInstance()
    {
        return instance;
    }



    public void StartGamebutton()
    {
        player.BeginPlay();
        Destroy(titleScreen);
        game_is_running = true;
    }

    public void ReloadButton()
    {
        Application.LoadLevel(Application.loadedLevel);
    }


    public void FaceBookLinkButton()
    {
        Application.OpenURL("https://www.facebook.com/hplscifi/");
    }

    public void AddWord()
    {
        score++;
        score_text.text = "score " + score.ToString();
        if(score >= 3)
        {
            reloaderbutton.SetActive(true);
            facebookButton.SetActive(true);
        }
        words.AddWord();
    }

    void Update()
    {
        if(game_is_running)
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
