using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways] 
public class CoordinateLabel : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        DisplayCoordinates();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        } 
    }

    void DisplayCoordinates()
    {
        float divX = UnityEditor.EditorSnapSettings.move.x;
        float divY = UnityEditor.EditorSnapSettings.move.z;
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x/divX);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / divY);
        
        label.text = $"{coordinates.x}, {coordinates.y}";
        

          
    }

    void UpdateObjectName()
    {
        transform.parent.name = $"({coordinates.x} , {coordinates.y})";
    }

}
