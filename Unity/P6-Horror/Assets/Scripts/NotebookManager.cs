using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotebookManager : MonoBehaviour {
    [TextArea] public List<string> notebooks = new List<string>();
    public List<bool> found = new List<bool>();
    //public List<Font> fonts = new List<Font>();
    public Font f;
    public Text text;
    public List<string> months = new List<string>();
    private int i;
    private int n;
    private string s;
    private int day;
    private int correction;
    private bool show;

	// Use this for initialization
	void Start () {
        i = 0;
        text.text = "...";
        SetFont();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            foreach(bool b in found)
            {
                if(b == true)
                {
                    show = true;
                }
            }
            if(show == true)
            {
                i++;
                if (i > notebooks.Count - 1)
                {
                    i = 0;
                }
                SetText(i);
                SetFont();
            }
        }
        /*if (Input.GetButtonDown("Submit"))
        {
            n++;
            if(n > fonts.Count - 1)
            {
                n = 0;
            }
            SetFont(n);
        }*/
	}

    public void SetText(int i)
    {
        if(found[i] == true)
        {
            text.text = notebooks[i];
            if (i == 9)
            {
                SetDate();
            }
        }
    }

    public void SetFont()
    {
        text.font = f;
        text.fontStyle = FontStyle.BoldAndItalic;
    }

    public void SetDate()
    {
        //set day text
        if (System.DateTime.Now.Day < 10)
        {
            day = System.DateTime.Now.Day;
        }
        if (System.DateTime.Now.Day > 10 && System.DateTime.Now.Day < 20)
        {
            day = System.DateTime.Now.Day - 10;
            correction = 10;
        }
        if (System.DateTime.Now.Day > 20 && System.DateTime.Now.Day < 30)
        {
            day = System.DateTime.Now.Day - 20;
            correction = 20;
        }
        if (System.DateTime.Now.Day > 30)
        {
            day = System.DateTime.Now.Day - 30;
            correction = 30;
        }
        if (day == 1)
        {
            s = (correction / 10).ToString() + "1st of ";
        }
        if (day == 2)
        {
            s = (correction / 10).ToString() + "2nd of ";
        }
        if (day == 3)
        {
            s = (correction / 10).ToString() + "3rd of ";
        }
        if (day > 3)
        {
            s = (correction / 10).ToString() + day.ToString() + "th of ";
        }

        //set month text
        s = s + months[System.DateTime.Now.Month - 1] + " ";

        //set year text
        s = s + System.DateTime.Now.Year.ToString() + ", Crystal Lake - New Jersey";

        text.text = text.text.Replace("???", s);
    }
}
