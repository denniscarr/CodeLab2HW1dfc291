using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour {

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mousey mousey");

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null) Debug.Log(hit.collider.name);
            
            if (hit.collider != null && hit.collider.GetComponent<Ball>() != null)
            {
                hit.collider.GetComponent<Ball>().GetClickedOn();
            }
        }
    }
}
