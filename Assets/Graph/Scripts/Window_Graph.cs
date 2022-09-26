using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Window_Graph : MonoBehaviour
{

    [SerializeField] private GameObject marker;
    [Header("Graph axis scaling")]
    [SerializeField]float yCompression ;
    [SerializeField] private float xCompression;
    
    [Header("GFX")]
    [SerializeField] private Sprite[] markerSprite;
    private RectTransform graphContainer;
    [SerializeField] float iconScale = 4;
    [SerializeField] float xAxisFontSize = 15;
    [SerializeField] private List<float> valueList = new List<float>(); //TODO:  LOAD HERE
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
        lr.SetUpAndDrawLines(pointLineList.ToArray());
    }

    private GameObject CreateCircle(Vector2 anchoredPosition) {
        
        GameObject gameObject = Instantiate(marker,Vector3.zero, Quaternion.identity);
        
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

    private void ShowGraph(List<float> valueList) {
        float graphHeight = graphContainer.sizeDelta.y;

        for (int i = 0; i < valueList.Count; i++) {
            float xPosition = xCompression + i * xCompression;
            float yPosition = (valueList[i] / yCompression) * graphHeight;
            GameObject markerGameObject = CreateCircle(new Vector2(xPosition, yPosition));

            var markerImage = markerGameObject.GetComponent<Image>(); 
            markerImage.sprite = GetSprite(valueList[i]);
            markerImage.color = GetColor(valueList[i]);

            
            var timeNow = DateTime.Now;
            string manipulatedTime ="";
            if (SceneManager.GetActiveScene().name.Contains("Day"))
            {
                manipulatedTime = timeNow.ToShortTimeString();

            }
            else
            {
                manipulatedTime = $"{timeNow.Day}/{timeNow.Month}";
            }
            AddLabelsXAxis(xPosition, manipulatedTime);
            
            
        }
                    
        
    }

    private void AddLabelsXAxis(float xPosition, string labelText)
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

        axisLabelRectTransform.sizeDelta = new Vector2(70, 20);
        axisLabelText.fontSize = xAxisFontSize;
        
        var dateManipulation = DateTime.Now;
        axisLabelText.SetText(labelText);

 
    }

    private Sprite GetSprite(float value)
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
    private Color GetColor(float value)
    {
        switch (value)
        {
            case <= 1:
                return Color.red;
            case <= 2:
                return new Color32(255, 150, 0,255);
            case <= 3:
                return Color.yellow;
            case <= 4:
                return new Color32(51, 204, 51,255);
            case <= 5:
                return new Color32(0, 153, 51,255);
        }

        return Color.magenta;
    }
}
