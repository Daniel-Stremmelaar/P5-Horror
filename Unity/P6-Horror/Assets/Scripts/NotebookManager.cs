using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotebookManager : MonoBehaviour {
    [TextArea] public List<string> notebooks = new List<string>();
    public List<Font> fonts = new List<Font>();
    public Text text;
    private int i;
    private int n;

	// Use this for initialization
	void Start () {
        i = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            i++;
            if(i > notebooks.Count-1)
            {
                i = 0;
            }
            SetText(i);
        }
        if (Input.GetButtonDown("Submit"))
        {
            n++;
            if(n > fonts.Count - 1)
            {
                n = 0;
            }
            SetFont(n);
        }
	}

    public void SetText(int i)
    {
        text.text = notebooks[i];
    }

    public void SetFont(int n)
    {
        text.font = fonts[n];
    }
}
