using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class JSHandler : MonoBehaviour
{
    public static JSHandler Instance = null;
    private void Awake()
    {
        Instance = this;
    }

    [DllImport("__Internal")]
    private static extern void JS_EnterGoodsDetailPage(string name, string id);


    private void Start()
    {
    }

    public void EnterGoodsDetailPage(string name, string id)
    {
        //UIHandler.Instance.text.text = "EnterGoodsDetailPage = " + name + id;

        JS_EnterGoodsDetailPage(name, id);
    }

    public void CallFromJS(string data)
    {
        UIHandler.Instance.DebugText("CallFromJS = " + data);
    }
}
