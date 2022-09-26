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

    [Header("Graph axis scaling")]
    [SerializeField]float yCompression = 7;
    [SerializeField] float xCompression = 130;
    [Header("GFX")]
    [SerializeField] private Sprite[] markerSprite;
    private RectTransform graphContainer;
    [SerializeField] float iconScale = 4;
    [SerializeField] float xAxisFontSize = 15;
    [SerializeField] private List<int> valueList = new List<int>(); //TODO:  LOAD HERE
    private List<Vector2> pointLineList = new List<Vector2>();
    private List<Vector2> verticalLineList = new List<Vector2>();
    private LineRedererController lr => FindObjectOfType<LineRedererController>();


    private void Awake()
    {
        graphContainer =  GetComponent<RectTransform>();
        ShowGraph(valueList);
        
    }

    private void Start()
    {
        lr.SetUpLine(pointLineList.ToArray());
    }

    private GameObject CreateCircle(Vector2 anchoredPosition) {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        
        gameObject.transform.SetParent(graphContainer, false);
        lr.transform.SetParent(graphContainer, true);
        pointLineList.Add(anchoredPosition);
        
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

        GameObject lastCircleGameObject = null;
        for (int i = 0; i < valueList.Count; i++) {
            float xPosition = xCompression + i * xCompression;
            float yPosition = (valueList[i] / yCompression) * graphHeight;
            GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition));
            
            circleGameObject.GetComponent<Image>().sprite = GetSprite(valueList[i]);
            
            AddLabelsXAxis(xPosition);
            
            
        }
                    
        
    }

    private void AddLabelsXAxis(float xPosition)
    {
        var axisLabel = new GameObject($"Label {xPosition}");
        axisLabel.AddComponent<TextMeshProUGUI>();
        axisLabel.transform.SetParent(graphContainer);
        
        var axisLabelText = axisLabel.GetComponent<TMP_Text>(); 
        axisLabelText.horizontalAlignment = HorizontalAlignmentOptions.Center; 
        var axisLabelRectTransform = axisLabel.GetComponent<RectTransform>(); 
        axisLabelRectTransform.anchoredPosition = new Vector2(xPosition, 0);
        verticalLineList.Add(new Vector2(xPosition,0));
        axisLabelRectTransform.anchorMax = new Vector2(0, 0);
        axisLabelRectTransform.anchorMin = new Vector2(0, 0);

        axisLabelRectTransform.sizeDelta = new Vector2(30, 20);
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
}
