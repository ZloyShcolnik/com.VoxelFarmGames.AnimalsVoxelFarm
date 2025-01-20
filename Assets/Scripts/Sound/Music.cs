using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    [SerializeField] private GameObject music;
    [SerializeField] private Image imageToggleMusic;
    
    private Color defaultColor;
    private Color disabledColor = new Color32(166, 166, 166, 255);
    private bool canPlay = true;

    private void Start()
    {
        defaultColor = imageToggleMusic.color;
       // music = FindObjectOfType<MusicController>().gameObject;
    }

    public void OnOffMusic()
    {
        SoundManager.instance.Play("Button");
        canPlay = !canPlay;

        if (canPlay)
        {
            MusicController.instance.gameObject.SetActive(true);
            imageToggleMusic.color = defaultColor;
        }
        else
        {
            MusicController.instance.gameObject.SetActive(false);
            imageToggleMusic.color = disabledColor;
        }
    }
}
