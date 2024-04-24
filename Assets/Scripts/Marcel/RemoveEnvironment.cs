using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveEnvironment : MonoBehaviour
{
    [SerializeField] private int removeDistance = 10;
    [SerializeField] private int activateDistance = 10;
    [SerializeField] private GameObject Environment;
    private List<GameObject> RoadChunks = new List<GameObject>();
    private List<GameObject> inactiveChunks = new List<GameObject>();

    void Start()
    {
        foreach (Transform child in Environment.transform)
        {
            RoadChunks.Add(child.gameObject);
            inactiveChunks.Add(child.gameObject);
            child.gameObject.SetActive(false);
        }

        RoadChunks.Sort((x, y) => x.transform.position.z.CompareTo(y.transform.position.z));
        inactiveChunks.Sort((x, y) => x.transform.position.z.CompareTo(y.transform.position.z));

        if(inactiveChunks.Count > 0)
        {
            if(inactiveChunks[0].transform.position.z < transform.position.z + activateDistance)
            {
                inactiveChunks[0].SetActive(true);
                inactiveChunks.RemoveAt(0);
            }
        }

    }

    void Update()
    {
        if(RoadChunks.Count > 0)
        {
            if(RoadChunks[0].transform.position.z < transform.position.z - removeDistance)
            {
                GameObject toRemove = RoadChunks[0];
                RoadChunks.RemoveAt(0);
                Destroy(toRemove);
            }

            if(inactiveChunks.Count > 0)
            {
                if(inactiveChunks[0].transform.position.z < transform.position.z + activateDistance)
                {
                    inactiveChunks[0].SetActive(true);
                    inactiveChunks.RemoveAt(0);
                }
            }
        }
    }
}


