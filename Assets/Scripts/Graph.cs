using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab = default;
    [SerializeField, Range(10, 100)]
    int resolution = 10;

    //[SerializeField, Range(0, 2)]
    [SerializeField]
    FunctionLibrary.FunctionName function = default;

    Transform[] points;

    void Awake()
    {
        Transform point = default;
        float step = 2f / resolution;
        var scale = Vector3.one * step;
        var position = Vector3.zero;
        points = new Transform[resolution];
        for (int i = 0; i < points.Length; i++)
        {
            point = Instantiate(pointPrefab);
            position.x = (i+0.5f)*step-1f;
            //position.y = position.x * position.x * position.x;
            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);
            points[i] = point;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FunctionLibrary.Function f = FunctionLibrary.GetFunction(function);
        float time = Time.time;
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            //if (function==0)
            //{
            //    position.y = FunctionLibrary.Wave(position.x, time);
            //}
            //else if(function==1)
            //{
            //    position.y = FunctionLibrary.MultiWave(position.x, time);
            //}
            //else
            //{
            //    position.y = FunctionLibrary.Ripple(position.x, time);
            //}
            position.y = f(position.x, time);
            point.localPosition = position;
        }
    }
}
