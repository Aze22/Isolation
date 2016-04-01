using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class EnemyBase : MonoBehaviour {

    public float m_baseSpeed = 5f;
    public bool m_hackable = true;
    public int healthPoints = 1;
    public float m_baseDamage = 10f;

    private bool m_isHackableInstance = false;

    private float m_levelSpeedMultiplier = 1f;
    private float m_externalEffectSpeedMultiplier = 1f;
    private float m_damageMultiplier = 1f;

    public UnityEvent m_onSpawn;
    public UnityEvent m_onKill;

    void OnEnable()
    {
        Init();

        if (m_onSpawn != null)
            m_onSpawn.Invoke();
    }

    public void Init()
    {
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, transform.position.y - (Time.deltaTime * m_baseSpeed * m_levelSpeedMultiplier * m_externalEffectSpeedMultiplier), transform.position.z);
	}

    public void SetLevelSpeedMultiplier(float _newSpeed)
    {
        m_levelSpeedMultiplier = _newSpeed;
    }

    public void SetDamageMultiplier(float _newValue)
    {
        m_damageMultiplier = _newValue;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent != null && other.transform.parent.name == "Limit")
        {
            OnTouchLimit();
        }
    }

    public void OnTouchLimit()
    {
        DamagePlayer();
        Kill();
    }

    public void DamagePlayer()
    {
        PlayerController.Instance.Damage(m_baseDamage * m_damageMultiplier);
    }

    public void Kill()
    {
        if (m_onKill != null)
            m_onKill.Invoke();

        Destroy(this.gameObject);
    }
}
