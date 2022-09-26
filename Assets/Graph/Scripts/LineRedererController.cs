using UnityEngine;

public class LineRedererController : MonoBehaviour
{
    private Vector2[] points;
    private LineRenderer lr;

    private void Awake()
    {
        lr = GetComponent < LineRenderer>();
    }


    public void SetUpAndDrawLines(Vector2[] points)
    {
        lr.positionCount = points.Length;
        this.points = points;
        
        DrawLines();
    }

    private void DrawLines()
    {
        for (int i = 0; i < points.Length; i++)
        {
            lr.SetPosition(i, points[i]);
        }
    }
}
