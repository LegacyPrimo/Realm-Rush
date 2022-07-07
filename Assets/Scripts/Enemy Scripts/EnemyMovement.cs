using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> enemyPath = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] private float enemySpeed;

    private Enemy enemy;

    // Start is called before the first frame update
    void OnEnable()
    {
        FindPathing();
        ReturnToStart();
        StartCoroutine(PrintWaypointName());
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void FindPathing()
    {
        enemyPath.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("EnemyPath");

        foreach (Transform child in parent.transform) 
        {
            Waypoint waypoint = child.GetComponent<Waypoint>();
            
            if (waypoint != null)
            enemyPath.Add(waypoint);
        }
    }

    private void ReturnToStart() 
    {
        transform.position = enemyPath[0].transform.position;
    }

    private void FinishPath() 
    {
        enemy.PenalizeCurrency();
        this.gameObject.SetActive(false);
    }

    private IEnumerator PrintWaypointName() 
    {
        foreach (Waypoint waypoint in enemyPath) 
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while (travelPercent < 1) 
            {
                travelPercent += Time.fixedDeltaTime * enemySpeed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }

        FinishPath();
    }
}
