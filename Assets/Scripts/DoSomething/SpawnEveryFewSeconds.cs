﻿using UnityEngine;

public class SpawnEveryFewSeconds : MonoBehaviour
{
	public GameObject objectToSpawn;
	public float amountToSpawn = 1f;
	public float spawnDistance = 0f;
	public bool spawnAsACircle = true;
    public bool shouldSpawn = true;
    public float time = 3f;

	void Update()
	{
        time -= Time.deltaTime;

		if (time <= 0)
        {
            time = 3f;
			Spawn();
        }
	}

	void Spawn()
	{
		int amountSpawned = 0;
		while (amountSpawned < amountToSpawn)
		{
			Vector3 offset = Vector3.zero;

			if (spawnAsACircle)
				offset = Random.insideUnitCircle * spawnDistance;
			else
				offset.x = Random.Range(-spawnDistance, spawnDistance);

			var go = Instantiate(objectToSpawn);
			go.transform.position = transform.position;


			amountSpawned++;
		}
	}
}
