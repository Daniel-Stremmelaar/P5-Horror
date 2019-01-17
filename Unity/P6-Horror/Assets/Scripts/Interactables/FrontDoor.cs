using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrontDoor : Door {

    public Text gameEnd;
    public UIManager ui;

    public override void Interact()
    {
        if (unlocked == true)
        {
            source.PlayOneShot(clip);
            ui.DeathUI();
        }
    }
}
