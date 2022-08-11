using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{

    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f,5f)] float speed = 1f;


    void Start()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());


    }

    void FindPath()
    {
        path.Clear();

        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");
        foreach (GameObject waypoint in waypoints)
        {
            path.Add(waypoint.GetComponent<Waypoint>());
        }

    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPos);

            while (travelPercent < 1)
            {
                transform.position = Vector3.Lerp(startPos, endPos, travelPercent);
                travelPercent += speed * Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

        }

        Destroy(gameObject);
    }


}
