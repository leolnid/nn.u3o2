using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
  public bool IsExpanding = false;

  public float SizeIncreaseSpeed = 1.009f;
  public float SizeDecreaseSpeed = 1.005f;

  public float MaxSize = 3;
  public float MinSize = 0.1f;

  public void Start()
  {
    StartCoroutine(_ManageBaloonSize());
  }

  public void StartExpanding()
  {
    IsExpanding = true;
  }

  public void StartShrinking()
  {
    IsExpanding = false;
  }

  private IEnumerator _ManageBaloonSize()
  {
    while (transform.localScale.x > MinSize)
    {
      if (IsExpanding)
      {
        if (transform.localScale.x < MaxSize)
          transform.localScale *= SizeIncreaseSpeed;
      }
      else
      {
        transform.localScale /= SizeIncreaseSpeed;
      }

      yield return new WaitForFixedUpdate();
    }

    Destroy(gameObject);
  }
}
