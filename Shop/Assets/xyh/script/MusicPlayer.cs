using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer Instance = null;
    private void Awake()
    {
        Instance = this;

        source = Camera.main.GetComponent<AudioSource>();
    }

    private AudioSource source;

    public MusicButton ui;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBg(bool on)
    {
        ui.Music(on);

        if (on)
        {
            source.Play();
        }
        else
        {
            source.Pause();
        }
    }

    public void OnSwitch(bool state)
    {
        PlayBg(state);
    }
}
