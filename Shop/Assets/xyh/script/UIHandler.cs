using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public static UIHandler Instance = null;
    private void Awake()
    {
        Instance = this;
    }

    public Text text;
    public Button btn;


    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(() =>
        {
            JSHandler.Instance.EnterGoodsDetailPage("SunPrune", "10001");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DebugText(string content)
    {
        text.text = content;
    }
}
