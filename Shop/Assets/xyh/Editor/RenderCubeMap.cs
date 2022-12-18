using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RenderCubeMap : ScriptableWizard
{
    public Transform renderTrans;
    public Cubemap cubemap;

    [MenuItem("Tools/CreateCubemap")]
    static void CreateCubemap()
    {
        //"Create Cubemap"�Ǵ򿪵Ĵ�������"Create"�ǰ�ť�������ʱ����OnWizardCreate()����
        ScriptableWizard.DisplayWizard<RenderCubeMap>("Create Cubemap", "Create");//����
    }

    private void OnWizardUpdate()//���򵼻��������и������������ݵ�ʱ�����
    {
        helpString = "ѡ����Ⱦλ�ò���ȷ����Ҫ���õ�cubemap";
        isValid = renderTrans != null && cubemap != null;//isValidΪtrue��ʱ�򣬡�Create����ť���ܵ��
    }

    private void OnWizardCreate()//���������ťʱ����
    {
        GameObject go = new GameObject();
        go.transform.position = renderTrans.position;
        Camera camera = go.AddComponent<Camera>();
        camera.RenderToCubemap(cubemap);//�û��ṩ��Cubemap���ݸ�RenderToCubemap��������������ͼƬ
        DestroyImmediate(go);//�����ݻ�go
    }
}

