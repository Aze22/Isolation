using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private float m_health = 100f;
    public static PlayerController Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        HealCompletely();
    }

    public void SetHealth(float _newValue)
    {
        m_health = _newValue;
        UpdateHealthBar();
    }

    public void Damage(float _amount)
    {
        m_health -= _amount;
        UpdateHealthBar();
    }

    public void HealCompletely()
    {
        m_health = 100f;
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        InGameUIController.Instance.m_healthbarController.SetHealth(m_health);
    }
}
