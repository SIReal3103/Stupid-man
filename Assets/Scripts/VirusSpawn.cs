using ANTs.Template;
using UnityEngine;

public class VirusSpawn : MonoBehaviour
{
    public int minHeightFromPlayer;
    public int maxHeightFromPlayer;
    public Vector2 widthRange;

    public Transform playerTransform;

    public ANTsPool virusPool;

    private void Start()
    {
        InvokeRepeating("SpawnVirus", 0, 2);
    }

    void SpawnVirus()
    {
        int number = Random.Range(1, 4);

        for (int id = 0; id < number; id++)
        {
            GameObject virus = virusPool.GetPooledObject();
            bool belowPlayer = Random.Range(0, 100) < 50;

            Vector3 playerPostition = playerTransform.position;
            int heightBelowPlayer = -Random.Range(minHeightFromPlayer, maxHeightFromPlayer);

            if (belowPlayer) 
                virus.transform.position = playerPostition + new Vector3(0, heightBelowPlayer, 0);
            else
                virus.transform.position = playerPostition + new Vector3(Random.Range(widthRange.x, widthRange.y), heightBelowPlayer, 0);

            virus.GetComponent<HideAfterTime>().Hide(10);
        }
    }
}
