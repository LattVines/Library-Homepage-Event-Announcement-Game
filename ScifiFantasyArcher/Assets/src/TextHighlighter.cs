using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextHighlighter : MonoBehaviour {

    public Color on_color, off_color;//SET IN EDITOR
    Text text_obj;
    /*
     * A call to OnMouseEnter occurs on the first frame the 
     * mouse is over the object. OnMouseOver is then called each frame until the mouse moves away, at which point OnMouseExit is c
     */

    void Awake()
    {
        
        text_obj = GetComponent<Text>();
    }

     
    public void EventOnMouseEnter()
    {
       
        text_obj.color = on_color;
    }

    public void EventOnMouseExit()
    {
       
        text_obj.color = off_color;
    }


}
