using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource soundPlayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerControls.Grounded==false){soundPlayer.Play();}
    }

}