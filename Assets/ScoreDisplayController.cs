using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreDisplayController : MonoBehaviour {

    public Text m_text;

    private int m_currentScoreValue = 0;

	// Use this for initialization
	void Start () {
        SetScore(0);
	}
	
	// Update is called once per frame
	void Update () {

	
	}

    public void SetScore(int _newValue)
    {
        m_currentScoreValue = _newValue;
        m_text.text = m_currentScoreValue.ToString();
    }
}
