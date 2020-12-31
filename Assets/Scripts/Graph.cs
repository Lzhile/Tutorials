using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab = default;

    void Awake()
    {
        Transform point = default;
        int length = 10;
        for (int i = 0; i < length; i++)
        {
            point = Instantiate(pointPrefab);
            point.localPosition = Vector3.right * i;
            point.localScale = Vector3.one / 5f;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
