﻿using UnityEngine;

public class SpawnWithInput : MonoBehaviour
{
	public GameObject objectToSpawn;
	public float amountToSpawn = 1f;
	public float spawnDistance = 0f;
	public KeyCode spawnButton = KeyCode.Space;
	public bool spawnAsACircle = true;

	void Update()
	{
		if (Input.GetKeyDown(spawnButton))
			Spawn();
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
            var pencil = go.GetComponent<AutoMove>();
            if (transform.parent)
            {
                var player = transform.parent.GetComponent<MoveWithInput>();
                if (player)
                {
                    pencil.direction = player.lastHorizontalMovement;
                    pencil.isProjectile = true;
                }
            }
			go.transform.position = transform.position;


			amountSpawned++;
		}
	}
}
