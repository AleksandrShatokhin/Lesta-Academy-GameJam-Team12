using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Transform clickedObject = GetClickedObject();
            if (clickedObject?.GetComponent<FallingItem>() != null)
            {
                //Сюда можно добавить анимацию
                Destroy(clickedObject.gameObject);
            }
        }
    }

    private Transform GetClickedObject()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePosition2D = new Vector2(mousePosition.x, mousePosition.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePosition2D, Vector2.zero);
        Transform clickedObject = hit.transform;
        return clickedObject;
    }
}
