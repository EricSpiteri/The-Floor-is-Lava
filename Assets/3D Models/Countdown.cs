using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class Countdown : MonoBehaviour
{
    public TextMeshProUGUI CountdownText;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    public void UpdateCountdownText(float timer)
    {
        CountdownText.text = "Crumble in:" + timer.ToString("0");
    }

    // Update is called once per frame
}
