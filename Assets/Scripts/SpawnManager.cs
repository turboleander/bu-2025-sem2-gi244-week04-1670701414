using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            float PosSpawnIndex = Random.Range(-10f,10f);
            if (animalPrefabs[animalIndex] != null)
            {
                Instantiate(animalPrefabs[animalIndex], new Vector3(PosSpawnIndex, 0, 20), Quaternion.Euler(0, 180, 0));
            }
            else
            {
                Debug.LogWarning($"null prefab at index {animalIndex}");
            }
        }
    }
}
