﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrontDoor : Door {

    public Text gameEnd;
    private UIManager ui;

    private void Awake()
    {
        ui = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
    }

    public override void Interact()
    {
        if (unlocked == true)
        {
            source.PlayOneShot(clip);
            ui.DeathUI();
        }
    }
}
