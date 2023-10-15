using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickObject : MonoBehaviour
{
    public GameObject mainCamera;
    public EventSystem eventsystem;

    public Ray ray;
    public Ray rayItem;
    public RaycastHit hit;
    public GameObject selectedGameObject;

    public string standName;

    // Start is called before the first frame update
    void Start()
    {
        standName = "centerN";
        eventsystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //左クリック
        if (Input.GetMouseButtonUp(0))
        {
            if (eventsystem.currentSelectedGameObject == null)
            {
                searchRoom(); 
            }
            else
            { 
                switch (eventsystem.currentSelectedGameObject.name)
                {
                    case "turnLBtn":
                        turnL();
                        break;
                }
            }
        }
    }

    public void turnL()
    {
        switch (standName)
        {
            case "centerN":
                GameObject.Find("mainCamera").transform.rotation = Quaternion.Euler(0, 270, 0);
                GameObject.Find("mainCamera").transform.position = new Vector3(-1, 7, -20);
                standName = "centerW";
                break;
            case "centerW":
                GameObject.Find("mainCamera").transform.rotation = Quaternion.Euler(0, 180, 0);
                GameObject.Find("mainCamera").transform.position = new Vector3(-1, 7, -20);
                standName = "centerS";
                break;
            case "centerS":
                GameObject.Find("mainCamera").transform.rotation = Quaternion.Euler(0, 90, 0);
                GameObject.Find("mainCamera").transform.position = new Vector3(-5, 7, -20);
                standName = "centerE";
                break;
            case "centerE":
                GameObject.Find("mainCamera").transform.rotation = Quaternion.Euler(0, 0, 0);
                GameObject.Find("mainCamera").transform.position = new Vector3(-6, 7, -26);
                standName = "centerN";
                break;
        }
    }

    public void searchRoom()
    {
        selectedGameObject = null;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 10000000, 1 << 8))
        {
            selectedGameObject = hit.collider.gameObject;
            switch (selectedGameObject.name)
            {
                case "redSwitch":
                    Debug.Log("レッドスイッチを押した");
                    break;
            }
        }
    }
}
