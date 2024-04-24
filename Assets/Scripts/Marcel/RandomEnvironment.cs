using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnvironment : MonoBehaviour
{

    [SerializeField] private int removeDistance = 10;
    [SerializeField] private int activateDistance = 100;
    [SerializeField] private List<GameObject> smallHouses = new List<GameObject>();
    [SerializeField] private List<GameObject> bigHouses = new List<GameObject>();
    [SerializeField] private float bigHouseThreshold = 250;

    private List<GameObject> RoadChunks = new List<GameObject>();

    private float addToZ = 0;
    private float lastZ = 0;

    private int smallHouseLength = 0;
    private int bigHouseLenght = 0;

    private bool bigCity = false;

    // Start is called before the first frame update
    void Start()
    {
        bigCity = false;
        lastZ = transform.position.z;
        addToZ = 2.383068f; // The distance between the chunks

        smallHouseLength = smallHouses.Count;
        bigHouseLenght = bigHouses.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > bigHouseThreshold)
        {
            bigCity = true;
        }

        if(transform.position.z > lastZ + addToZ)
        {
            lastZ = transform.position.z;
            InstantiateChunk(new Vector3(0, 0, lastZ));
        }

    }

    private void InstantiateChunk(Vector3 position)
    {
        
    }

}
