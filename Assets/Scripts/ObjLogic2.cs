using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjLogic2 : MonoBehaviour
{
    public int ObjId;
    public GameObject ScenarioLogic;

    private bool valid = false;
    public bool drownable = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        FindObjectOfType<ObjLogic_SceneB>().OnObjectClick(ObjId);
    }
}
