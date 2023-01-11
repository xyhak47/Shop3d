using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    public Sprite s_on;
    public Sprite s_off;

    private bool music_on = false;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            music_on = !music_on;
            MusicPlayer.Instance.OnSwitch(music_on);
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Music(bool on)
    {
        music_on = on;
        GetComponent<Image>().sprite = on ? s_on : s_off;
    }
}
