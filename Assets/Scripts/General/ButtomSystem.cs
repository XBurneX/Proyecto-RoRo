using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtomSystem : MonoBehaviour
{
    public GameObject someButton;
    GameObject currentButton;
    EventSystem eventSystem;
    void Start()
    {
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        //GameObject buttonObj = GameObject.Find("Play");
        //buttonObj.GetComponent<Button>().onClick.AddListener(() => { currentButton = buttonObj; });
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            eventSystem.SetSelectedGameObject(someButton);
        }
    }
}
