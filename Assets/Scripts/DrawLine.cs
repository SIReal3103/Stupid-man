using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ANTs.Template;

public class DrawLine : MonoBehaviour
{
    public ANTsPool LinePool;
   
    public List<Vector2> mousePostition;

    private GameObject currentDrawingLine;
    private EdgeCollider2D edgeCollider;
    private LineRenderer lineRender;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateLine();
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = GetMousePostition();
            if ((mousePos - mousePostition[mousePostition.Count - 1]).sqrMagnitude > 0.1f)
                UpdateLine(mousePos);
        }
    }

    void CreateLine()
    {
        currentDrawingLine = LinePool.GetPooledObject();
        lineRender = currentDrawingLine.GetComponent<LineRenderer>();
        edgeCollider = currentDrawingLine.GetComponent<EdgeCollider2D>();
        lineRender.positionCount = 0;

        mousePostition.Clear();

        UpdateLine(GetMousePostition());
    }

    void UpdateLine(Vector2 postition)
    {
        mousePostition.Add(postition);
        lineRender.positionCount++;
        lineRender.SetPosition(lineRender.positionCount - 1, postition);
        edgeCollider.points = mousePostition.ToArray();
    }

    Vector3 GetMousePostition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
