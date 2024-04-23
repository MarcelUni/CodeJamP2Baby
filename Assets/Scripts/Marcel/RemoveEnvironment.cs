using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveEnvironment : MonoBehaviour
{
    [SerializeField] private int distance = 10;
    [SerializeField] private GameObject Environment;
    private List<GameObject> RoadChunks = new List<GameObject>();

    void Start()
    {
        foreach (Transform child in Environment.transform)
        {
            RoadChunks.Add(child.gameObject);
        }

        RoadChunks.Sort((x, y) => x.transform.position.z.CompareTo(y.transform.position.z));
    }

    void Update()
    {
        if(RoadChunks.Count > 0)
        {
            if(RoadChunks[0].transform.position.z < transform.position.z - distance)
            {
                GameObject toRemove = RoadChunks[0];
                RoadChunks.RemoveAt(0);
                Destroy(toRemove);
            }
        }
    }


}


