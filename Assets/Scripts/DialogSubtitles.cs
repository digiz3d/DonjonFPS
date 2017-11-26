using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSubtitles : MonoBehaviour {

    public Text SubtitlesUI;
    private float subtitlesCooldown = 0f;
    	
	// Update is called once per frame
	void Update () {
        subtitlesCooldown -= Time.deltaTime;
        if (subtitlesCooldown <= 0f) {
            SubtitlesUI.gameObject.SetActive(false);
        }
	}

    public void Display(string sentence)
    {
        if (SubtitlesUI == null)
        {
            return;
        }
        SubtitlesUI.gameObject.SetActive(true);
        SubtitlesUI.text = sentence;
        subtitlesCooldown = sentence.Length / 5f;
    }
}
