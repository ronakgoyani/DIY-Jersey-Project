using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextWriterEffect : MonoBehaviour
{
    private TextMeshProUGUI uiText;
    private string textToWrite;
    private int charIndex;
    private float timePerChar;
    private float timer;

    public void AddWriter(TextMeshProUGUI uiText, string textToWrite, float timerPerChar)
    {
        this.uiText = uiText;
        this.textToWrite = textToWrite;
        this.timePerChar = timerPerChar;
        charIndex = 0;
    }

    private void Update()
    {
        if(uiText != null)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer += timePerChar;
                charIndex++;
                uiText.text = textToWrite.Substring(0, charIndex);

                if(charIndex >= textToWrite.Length)
                {
                    uiText = null;
                    return;
                }
            }
        }
    }
}