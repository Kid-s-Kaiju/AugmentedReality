using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{

    GameObject IngameCanvas;
    GameObject PauseCanvas;
    Canvas Pausecnvs;
    Canvas Ingamecnvs;
    GameObject gun;
    Gun gn;

    public void PausedButton()
    {
        IngameCanvas = GameObject.Find("Ingame Canvas");
        PauseCanvas = GameObject.Find("Pause Canvas");
        Ingamecnvs = IngameCanvas.GetComponent<Canvas>();
        Pausecnvs = PauseCanvas.GetComponent<Canvas>();
        gun = GameObject.Find("Gun");
        gn = gun.GetComponent<Gun>();


        gn.canshoot = false;
        Pausecnvs.enabled = true;
        Ingamecnvs.enabled = false;
        
    }
}
