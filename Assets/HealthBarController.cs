using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour {

    public Slider m_slider;
    private int m_currentHealthValue = 100;

	// Use this for initialization
	void Start () {
        SetHealth(100);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetHealth(int _newValue)
    {
        m_currentHealthValue = _newValue;
        m_slider.value = (float) (_newValue ) * 0.01f;
    }
}
