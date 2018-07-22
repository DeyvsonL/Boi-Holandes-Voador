using System;
using System.Collections.Generic;
using UnityEngine;

public class PeopleManager : MonoBehaviour {

    [SerializeField]
    private List<GameObject> spots;

    [SerializeField]
    private List<GameObject> personPrefabs;

    [SerializeField]
    private List<Vector2> spawnIntervals;

    [SerializeField]
    private List<int> timeIntervals;

    private Vector2 currentSpawnInterval;
    private int currentTimeIntervalIndex;

    private float Counter;
    private float NextSpawn;

    private float totalTime;

	// Use this for initialization
	void Start () {
        currentSpawnInterval = spawnIntervals[currentTimeIntervalIndex];
        NextSpawn = UnityEngine.Random.Range(currentSpawnInterval.x, currentSpawnInterval.y);
	}
	
	// Update is called once per frame
	void Update () {
        Counter += Time.deltaTime;
        totalTime += Time.deltaTime;
        if (totalTime > timeIntervals[currentTimeIntervalIndex])
        {
            currentTimeIntervalIndex = Math.Min(currentTimeIntervalIndex+1, spawnIntervals.Count-1);
            currentSpawnInterval = spawnIntervals[currentTimeIntervalIndex];
        }
        if (NextSpawn > Counter) return;
        Counter = 0;
        var positionIndex = UnityEngine.Random.Range(0, spots.Count);
        var position = spots[positionIndex].transform;
        var prefabIndex = UnityEngine.Random.Range(0, personPrefabs.Count);
        var person = Instantiate(personPrefabs[prefabIndex], position.position, position.rotation);
        NextSpawn = UnityEngine.Random.Range(currentSpawnInterval.x, currentSpawnInterval.y);
		Destroy(person, 25);

    }
}
