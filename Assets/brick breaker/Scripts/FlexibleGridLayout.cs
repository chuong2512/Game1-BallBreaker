using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlexibleGridLayout : MonoBehaviour {


	void Start () {
        float width = this.gameObject.GetComponent<RectTransform>().rect.width;
		Vector2 newSize = new Vector2(width / 3 - 5, width / 3 - 5);
		this.gameObject.GetComponent<GridLayoutGroup>().cellSize = newSize;
		GetComponent<RectTransform> ().offsetMin = new Vector2 (0, width - (width * 2.2f));
	}
}
