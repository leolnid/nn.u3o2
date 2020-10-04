using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    public bool IsExpanding = false;

    public float SizeIncreaseSpeed = 1.009f;
    public float SizeDecreaseSpeed = 1.000f;

    public float MaxSize = 3;
    public float MinSize = 0.1f;

    public UnityEvent blowEvent;
    public ParticleSystem ps;

    public void Start()
    {
        StartCoroutine(_ManageBaloonSize());
        ps = GetComponent<ParticleSystem>();
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
        while (transform.localScale.x > MinSize && transform.localScale.x < MaxSize)
        {
            if (IsExpanding)
            {
                transform.localScale *= SizeIncreaseSpeed;
            }
            else
            {
                transform.localScale /= SizeDecreaseSpeed;
            }

            yield return new WaitForFixedUpdate();
        }
        
        Destroy(transform.GetChild(0).gameObject);
        ps.Play();
        yield return new WaitForSeconds(1);

        blowEvent.Invoke();
        Destroy(transform.parent.gameObject);
        yield break;
    }
}