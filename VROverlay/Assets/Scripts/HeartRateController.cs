using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;

public class HeartRateController : MonoBehaviour {

	public string EndpointUri;
	public GameObject HeartPrefab;

	private Dictionary<string, HeartRateDisplay> HeartRateDisplays = new Dictionary<string, HeartRateDisplay>();

	void Start () {
		StartCoroutine(DoHeartRate());
	}
	

	IEnumerator DoHeartRate() {
		while(true) {
			string fullRequest = string.Format("{0}/latest", EndpointUri);
            UnityWebRequest request = UnityWebRequest.Get(fullRequest);

            Debug.Log("Requesting: " + fullRequest);
            yield return request.SendWebRequest();

            if(request.isNetworkError || request.isHttpError) {
                Debug.Log(request.error);
                Debug.Log(request.downloadHandler.text);
            }
            else {
                string text = request.downloadHandler.text;

                var json = JSON.Parse(text);
				Debug.Log(json);
				foreach(string key in json.Keys) {
					if(!HeartRateDisplays.ContainsKey(key)) {
						CreateHeartRateDisplay(key);
					} else {
						HeartRateDisplays[key].AddHeartRate(json[key]);
					}
				}
            }
			yield return new WaitForSeconds(1f);
		}
	}

	void CreateHeartRateDisplay(string userId) {
		var display = Instantiate(HeartPrefab).GetComponent<HeartRateDisplay>();
		display.UserId = userId;
		display.HeartRate = "---";

		HeartRateDisplays.Add(userId, display);

		display.transform.parent = transform;
	}
}
