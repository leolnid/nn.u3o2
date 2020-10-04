using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInteractor : MonoBehaviour
{
  BallController last;

  void Start()
  {

  }

  void FixedUpdate()
  {
    print(last);
    RaycastHit hit;
    Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

    if (Physics.Raycast(ray, out hit))
    {
      last = hit.transform.parent.gameObject.GetComponent<BallController>();

      if (last != null)
      {
        last.StartExpanding();
      }
    }
    else
    {
      if (last != null)
      {
        last.StartShrinking();
      }

      last = null;
    }
  }
}
