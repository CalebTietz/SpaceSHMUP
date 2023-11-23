using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    static private Main S; // Singleton

    [Header("Inscribed")]
    public GameObject[] prefabEnemies;
    public float enemySpawnsPerSec = 0.5f;
    public float enemyInsetDefault = 1.5f;

    private BoundsCheck boundsCheck;

    void Awake()
    {
        S = this;

        boundsCheck = GetComponent<BoundsCheck>();

        Invoke(nameof(SpawnEnemy), 1f / enemySpawnsPerSec);
    }

    public void SpawnEnemy()
    {
        int index = Random.Range(0, prefabEnemies.Length);

        GameObject go = Instantiate<GameObject>(prefabEnemies[index]);

        float enemyInset = enemyInsetDefault;

        if(go.GetComponent<BoundsCheck>() != null)
        {
            enemyInset = Mathf.Abs(go.GetComponent<BoundsCheck>().radius);
        }

        Vector3 pos = Vector3.zero;
        float xMin = -boundsCheck.camWidth + enemyInset;
        float xMax = boundsCheck.camWidth - enemyInset;
        pos.x = Random.Range(xMin, xMax);
        pos.y = boundsCheck.camHeight + enemyInset;
        go.transform.position = pos;

        Invoke(nameof(SpawnEnemy), 1f / enemySpawnsPerSec);
    }

}
