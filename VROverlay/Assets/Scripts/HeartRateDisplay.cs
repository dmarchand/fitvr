using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartRateDisplay : MonoBehaviour {
	public string HeartRate;
	public string UserId;

	public DD_DataDiagram Graph;

	public Text HeartRateText, UserIdText;

	private GameObject line;
	private int instanceCount = 0;
	
	void Awake() {
		//line = Graph.AddLine("hr", Color.white);
	}
	void Update () {
		HeartRateText.text = HeartRate;
		UserIdText.text = UserId;
	}

	public void AddHeartRate(int heartRate) {
		//Graph.InputPoint(line, new Vector2(instanceCount, heartRate));
		HeartRate = heartRate.ToString();
		instanceCount++;
	}
}
