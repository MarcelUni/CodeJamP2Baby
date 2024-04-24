using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnvironment : MonoBehaviour
{
    private float addToZ = 0;
    private float addToZHospital = 15f;
    private float lastZ = 0;
    private int smallHouseLength = 0;
    private int bigHouseLenght = 0;
    private bool bigCity = false;
    private List<GameObject> RoadChunks = new List<GameObject>();

    [SerializeField] private int instantiateDistance = -100;
    [SerializeField] private List<GameObject> smallHouses = new List<GameObject>();
    [SerializeField] private List<GameObject> bigHouses = new List<GameObject>();
    [SerializeField] private float bigHouseThreshold = 250;
    [SerializeField] private float removeDistance = 25;
    [SerializeField] private GameObject environment;
    [SerializeField] private GameManager gameManager;

    [SerializeField] private GameObject hospitalPrefab;

    void Start()
    {
        foreach(Transform child in environment.transform)
        {
            Destroy(child.gameObject);
        }

        bigCity = false;
        lastZ = transform.position.z;

        addToZ = 23.83068f; // The distance between the chunks
        

        smallHouseLength = smallHouses.Count;
        bigHouseLenght = bigHouses.Count;
    }

    void Update()
    {
        if(transform.position.z > bigHouseThreshold)
        {
            bigCity = true;
        }
        
        if(bigHouses.Count == 0)
            bigCity = false;

        if(transform.position.z - lastZ > instantiateDistance && gameManager._player.transform.position.z != gameManager.winDistance)
        {
            Vector3 position = new Vector3(0.6f, 0, lastZ + addToZ);

            GameObject prefabtoInstantiate;

            if(bigCity)
                prefabtoInstantiate = bigHouses[Random.Range(0, bigHouseLenght)];
            
            else
                prefabtoInstantiate = smallHouses[Random.Range(0, smallHouseLength)];
            
            GameObject newChunk = Instantiate(prefabtoInstantiate, position, Quaternion.identity);
            newChunk.transform.parent = environment.transform;
            RoadChunks.Add(newChunk);
            lastZ = newChunk.transform.position.z;
        }
        

        RemoveChunks();
    }

    private void RemoveChunks()
    {
        if(RoadChunks.Count == 0)
            return;

        if(RoadChunks[0].transform.position.z < transform.position.z - removeDistance)
        {
            GameObject toRemove = RoadChunks[0];
            RoadChunks.RemoveAt(0);
            Destroy(toRemove);
        }
    }

    public void SpawnHospital()
    {
        Vector3 position = new Vector3(-0.6f, -3.64f, lastZ + addToZHospital);

        GameObject HospitalInstantiate = hospitalPrefab;

        GameObject newChunk = Instantiate(HospitalInstantiate, position, Quaternion.identity);
        GameObject spawnedChunk = Instantiate(HospitalInstantiate, position, Quaternion.Euler(0f, 180f, 0f));
        newChunk.transform.parent = environment.transform;
        RoadChunks.Add(newChunk);
        lastZ = newChunk.transform.position.z;
    }

}
