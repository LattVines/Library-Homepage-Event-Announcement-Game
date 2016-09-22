using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Words : MonoBehaviour {


    public Text[] words;//set in editor

    int word_counter = 0;

    void Awake()
    {
        foreach(Text obj in words)
        {
            obj.gameObject.SetActive(false);
        }
    }


    public void AddWord()
    {
        if(word_counter < words.Length)
        {
            words[word_counter].gameObject.SetActive(true);
            word_counter++;
        }
    }


}
