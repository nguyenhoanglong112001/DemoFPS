using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoFade : MonoBehaviour
{
    public float visibleDuration;
    public float fadingDuration;
    public CanvasGroup group;

    private float startTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Show()
    {
        startTime = Time.time;
        group.alpha = 1f;
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        float eslapedTime = Time.time - startTime;
        if (eslapedTime < visibleDuration)
        {
            return;
        }
        eslapedTime -= visibleDuration;
        if(eslapedTime < fadingDuration)
        {
            group.alpha = 1f - eslapedTime / fadingDuration;
        }
        else
        {
            Hide();
        }
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
