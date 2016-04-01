using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;

public class EnemiesController : MonoBehaviour {

    public float m_startSpawnRate = 10f;
    private float m_currentSpawnRate = 10f;
    private int m_killCount = 0;
    private int m_currentEnemiesCount = 0;
    private int m_currentEnemiesSpawned = 0;
    public AnimationCurve m_spawnRateEvolution;

    public List<EnemyBase> m_currentEnemies;
    public List<Object> m_enemyPrefabs;

    private Transform m_spawnPoint;
    
	// Use this for initialization
	void Start () {
        m_spawnPoint = transform.Find("Spawnpoint");
        m_currentEnemies = new List<EnemyBase>();
        m_enemyPrefabs = new List<Object>();

        EnemyBase[] allEnemies = Resources.FindObjectsOfTypeAll<EnemyBase>();

        for (int i = 0; i < allEnemies.Length; i++)
        {
            m_enemyPrefabs.Add(allEnemies[i]);
        }

        StartCoroutine("SpawnEnemiesRoutine");
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private IEnumerator SpawnEnemiesRoutine()
    {
        yield return new WaitForSeconds(0.5f);

        while (true)
        {
            SpawnEnemy();

            float delayUntilNextSpawn = 1f;
            delayUntilNextSpawn = (60f / m_currentSpawnRate);

            yield return new WaitForSeconds(delayUntilNextSpawn);
        }
    }

    public void SpawnEnemy()
    {
        if (m_enemyPrefabs.Count > 0)
        {
            EnemyBase newEnemy = Instantiate(m_enemyPrefabs[0], m_spawnPoint.position, m_spawnPoint.rotation) as EnemyBase;
            newEnemy.m_onKill.AddListener( () => OnEnemyKilled(newEnemy) );
            newEnemy.transform.parent = transform;
            m_currentEnemies.Add(newEnemy);
            m_currentEnemiesSpawned++;
            m_currentEnemiesCount++;
        }
    }

    public void OnEnemyKilled(EnemyBase _enemyKilled)
    {
        m_currentEnemies.Remove(_enemyKilled);
        m_killCount++;
        SetSpawnRate( m_currentSpawnRate + (m_spawnRateEvolution.Evaluate(((float) m_killCount) / 100)) * 100);
        m_currentEnemiesCount--;
    }

    public void SetSpawnRate(float _newSpawnRate)
    {
        m_currentSpawnRate = _newSpawnRate;
        Debug.Log("New Spawn Rate : " + m_currentSpawnRate);
    }
}
