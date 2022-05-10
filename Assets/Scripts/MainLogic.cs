using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLogic : MonoBehaviour
{
    public GameObject StartWindow;

	public GameObject scenario1Object;

    public GameObject curObject;

    public Transform[] ImageTargets;

    void Start()
    {
        //Старт пока уберем
        //StartWindow.SetActive(true);
    }

    public void StartClicked()
    {
        StartWindow.SetActive(false);
    }

    public void ScenarioSelected(int id)
    {
        Debug.Log(id);

        Destroy(curObject);
        curObject = null;

        string objectName = "Scenario" + (id + 1);
        GameObject prefabObject = Resources.Load<GameObject>(objectName);
        curObject = Instantiate(prefabObject, ImageTargets[id]);     //подрузка контента из папки ресурсов

        switch (id)
        {
            case 0:
                curObject.SendMessage("ScenarioStart");
                break;
        }
    }
}
