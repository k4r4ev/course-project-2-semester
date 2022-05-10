using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//using System.Linq;

//using Vuforia;

namespace SkyInnovations {

	static public class Utilities {

		static public void clearListOfGameObjects(List<GameObject> list) {
			if (list != null) {
				list.ForEach(delegate (GameObject go) {
					//Debug.Log(go.name);
					GameObject.Destroy(go);
				});

				list.Clear();
			}
		}

		static public void clearDictionaryOfGameObjects(Dictionary<string, GameObject> dict) {
			if (dict != null) {
				foreach (string key in dict.Keys) {
					GameObject.Destroy(dict[key]);
				}

				dict.Clear();
			}
		}

		static public bool IsPointerOverUIObject() {
			PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
			eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			List<RaycastResult> results = new List<RaycastResult>();
			EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
			return results.Count > 0;
		}

	}

}
