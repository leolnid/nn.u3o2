using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInteractor : MonoBehaviour
{
    public BallController last;

    void Start()
    {
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out hit))
        {
            last = hit.transform.parent.gameObject.GetComponent<BallController>();

            if (last)
                last.StartExpanding();
        }
        else
        {
            if (last)
                last.StartShrinking();

            last = null;
        }
    }
}