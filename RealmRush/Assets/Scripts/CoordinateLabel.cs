using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways] 
public class CoordinateLabel : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color changedColor = Color.grey;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    Waypoint waypoint;

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        DisplayCoordinates();
        waypoint = GetComponentInParent<Waypoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
        ColorCoordinates();
        ToggleLabels();

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

    void ColorCoordinates()
    {
        if (waypoint.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = changedColor;
        }
    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

}
