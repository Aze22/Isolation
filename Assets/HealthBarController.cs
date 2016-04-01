using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour {

    public Slider m_slider;
    public float m_damageLerpSpeed = 3;
    private float m_currentHealthValue = 100;
    private float m_targetSliderValue = 1f;
    private float m_lastSliderValue = 1f;
    private float m_currentLerpValue = 0f;

	// Use this for initialization
	void Start () {
        SetHealth(100);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(m_slider.value != m_targetSliderValue)
        {
            m_currentLerpValue += (Time.deltaTime * m_damageLerpSpeed);
            m_slider.value = Mathf.Lerp(m_lastSliderValue, m_targetSliderValue, m_currentLerpValue);
        }
	}

    public void SetHealth(float _newValue)
    {
        m_lastSliderValue = m_slider.value;
        m_currentHealthValue = _newValue;
        m_targetSliderValue = _newValue * 0.01f;
        m_currentLerpValue = 0f;
    }


}
