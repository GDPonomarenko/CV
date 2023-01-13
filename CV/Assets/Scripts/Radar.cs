using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    public Transform player;
    public List<Transform> prefabs;
    public GameObject selectedPrefab;
    public Transform redPoint;
    private float pointInRadarX, pointInRadarZ;

    void FixedUpdate()
    {
        pointInRadarX = (player.position.x - prefabs[SetMinDistance()].position.x)/60;
        pointInRadarZ = (player.position.z - prefabs[SetMinDistance()].position.z)/60;
        redPoint.localPosition = new Vector3(pointInRadarZ, -pointInRadarX, -0.36f);

        if (prefabs.Count == 0) {
            Debug.Log("AllPrefabsFind");
        }


    }

    public int SetMinDistance() {
        float minDistance = Vector3.Distance(player.position, prefabs[0].position);
        int minIndex=0;
        for (int x =0; x< prefabs.Count; x++) {
            if (Vector3.Distance(player.position, prefabs[x].position)< minDistance) {
                minDistance = Vector3.Distance(player.position, prefabs[x].position);
                minIndex = x;
            }
        }
        return minIndex;
    }
}
