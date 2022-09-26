/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Window_Graph : MonoBehaviour {

    [SerializeField] private Sprite[] markerSprite;
    [SerializeField] private Sprite debugSprite;
    private RectTransform graphContainer;

    private void Awake() {
        graphContainer =  GetComponent<RectTransform>();

        List<int> valueList = new List<int>() { 1,4,5,4,4,3,5 }; // 
        ShowGraph(valueList);
    }

    private GameObject CreateCircle(Vector2 anchoredPosition) {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        
        gameObject.GetComponent<Image>().sprite = markerSprite[0];
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(11, 11);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        return gameObject;
    }

    private void ShowGraph(List<int> valueList) {
        float graphHeight = graphContainer.sizeDelta.y;
        float yMaximum = 10;
        float xSize = 130;

        GameObject lastCircleGameObject = null;
        for (int i = 0; i < valueList.Count; i++) {
            float xPosition = xSize + i * xSize;
            float yPosition = (valueList[i] / yMaximum) * graphHeight;
            GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition));
            circleGameObject.GetComponent<Image>().sprite = GetSprite(valueList[i]);
            
            AddLabelsXAxis(xPosition);
            
            if (lastCircleGameObject != null) {
               
                // CreateDotConnection(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);
                DrawLine();
            }
            lastCircleGameObject = circleGameObject;
        }
    }

    private void AddLabelsXAxis(float xPosition)
    {
        var xText = new GameObject($"Text at {xPosition}" , typeof(Image));
        xText.transform.SetParent(graphContainer);
        var xTextRectTransform = xText.GetComponent<RectTransform>();
        xTextRectTransform.anchoredPosition = new Vector2(xPosition, 0);
        xTextRectTransform.anchorMax = new Vector2(0, 0);
        xTextRectTransform.anchorMin = new Vector2(0, 0);
        xTextRectTransform.sizeDelta = new Vector2(11, 11);
        xText.GetComponent<Image>().sprite = debugSprite;
    }

    private Sprite GetSprite(int value)
    {
        switch (value)
        {
            case <= 1:
                return markerSprite[0];
            case <= 2:
                return markerSprite[1];
            case <= 3:
                return markerSprite[2];
            case <= 4:
                return markerSprite[3];
            case <= 5:
                return markerSprite[4];
        }

        return null;
    }

    private void CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB) {
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = new Color(1,1,1, .5f);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 dir = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, 3f);
        rectTransform.anchoredPosition = dotPositionA + dir * distance * .5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(dir));
    }

    private void DrawLine()
    {
        
    }
    
    private float GetAngleFromVectorFloat(Vector3 dir) {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }

}
