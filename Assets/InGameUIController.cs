using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InGameUIController : MonoBehaviour {

    public static InGameUIController Instance;
    public ScoreDisplayController m_scoreController;
    public HealthBarController m_healthbarController;
    public BarrierButtonController m_barrierButtonController;

    void Awake()
    {
        Instance = this;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
