using UnityEngine;
using System.Collections;

public class Words : MonoBehaviour {


    public GameObject[] words;//set in editor

    int word_counter = 0;

    void Awake()
    {
        foreach(GameObject obj in words)
        {
            obj.SetActive(false);
        }
    }


    public void AddWord()
    {
        if(word_counter < words.Length)
        {
            words[word_counter].SetActive(true);
            word_counter++;
        }
    }


}
