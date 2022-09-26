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
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Window_Graph : MonoBehaviour {

    [SerializeField] private Sprite[] markerSprite;
    private RectTransform graphContainer;
    [SerializeField] float iconScale = 4;
    [SerializeField] float xAxisFontSize = 15;



    private void Awake() {
        graphContainer =  GetComponent<RectTransform>();

        List<int> valueList = new List<int>() { 1,4,5,4,4,3,5 }; // LOAD
        ShowGraph(valueList);
    }

    private GameObject CreateCircle(Vector2 anchoredPosition) {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        
        gameObject.GetComponent<Image>().sprite = markerSprite[0];
        gameObject.transform.localScale *= iconScale;
        var rectTransform = gameObject.GetComponent<RectTransform>();
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
        var axisLabel = new GameObject($"Label {xPosition}");
        axisLabel.AddComponent<TextMeshProUGUI>();
        axisLabel.transform.SetParent(graphContainer);
        
        LayerMask uILayer = LayerMask.NameToLayer("UI");
        axisLabel.layer = uILayer;
        
        var axisLabelText = axisLabel.GetComponent<TMP_Text>(); 
        axisLabelText.horizontalAlignment = HorizontalAlignmentOptions.Center; 
        var axisLabelRectTransform = axisLabel.GetComponent<RectTransform>(); 
        axisLabelRectTransform.anchoredPosition = new Vector2(xPosition, 0);
        axisLabelRectTransform.anchorMax = new Vector2(0, 0);
        axisLabelRectTransform.anchorMin = new Vector2(0, 0);

        axisLabelRectTransform.sizeDelta = new Vector2(100, 70);
        axisLabelText.fontSize = xAxisFontSize;
        var dateManipulation = DateTime.Now;
        axisLabelText.SetText($"{dateManipulation.Day}/{dateManipulation.Month}");

 
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
