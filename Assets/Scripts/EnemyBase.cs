using UnityEngine;
using System.Collections;

public class EnemyBase : MonoBehaviour {

    public float m_baseSpeed = 5f;
    public bool m_hackable = true;
    private float m_levelSpeedMultiplier = 1f;
    private float m_externalEffectSpeedMultiplier = 1f;

    void OnEnable()
    {

    }

    public void Init()
    {

    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, transform.position.y - (Time.deltaTime * m_baseSpeed * m_levelSpeedMultiplier * m_externalEffectSpeedMultiplier), transform.position.z);
	}
}
