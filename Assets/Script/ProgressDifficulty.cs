using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressDifficulty : MonoBehaviour
{
    public Slider slider;
    float progress = 0;
    float timeCollector = 0;
    float timeDiminisher = 10;

    void Update()
    {
        if(slider.value == 1)
        {
            timeCollector = 0;
        }
        timeCollector += Time.deltaTime / timeDiminisher;
        progress = timeCollector;
        slider.value = progress;
    }
}
