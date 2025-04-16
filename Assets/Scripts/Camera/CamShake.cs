using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    public float duration = 1f;
    public AnimationCurve curve;
    public bool start = false;

    Vector3 startPos;
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (start)
        //{
        //    startPos = transform.position;
        //    start = false;
        //    StartCoroutine(Shaking());
        //}
    }

    public IEnumerator Shaking()
    {
        startPos = transform.position;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime/duration);
            transform.position = startPos + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = startPos;
    }
}
