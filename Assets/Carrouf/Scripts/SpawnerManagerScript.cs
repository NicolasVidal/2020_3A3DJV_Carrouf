using UnityEngine;

namespace Carrouf.Scripts
{
    public class SpawnerManagerScript : MonoBehaviour
    {
        [SerializeField]
        private Transform spawnerRootTransform;
        
        [SerializeField]
        private GameObject ballPrefab;

        [Range(0.1f, 3f)]
        [SerializeField]
        private float minSpawnDelay;

        [Range(0.5f, 5f)]
        [SerializeField]
        private float maxSpawnDelay;

        private float lastSpawnTime;
        private float? nextSpawnDelay;

        private void Update()
        {
            if (!nextSpawnDelay.HasValue)
            {
                nextSpawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
            }

            if (!(Time.time - lastSpawnTime >= nextSpawnDelay))
            {
                return;
            }
            
            Instantiate(ballPrefab, spawnerRootTransform.position, Quaternion.identity);
            lastSpawnTime = Time.time;
            nextSpawnDelay = null;
        }
    }
}