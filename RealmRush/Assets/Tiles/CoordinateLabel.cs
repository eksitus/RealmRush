using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabel : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;
    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] Color pathColor = new Color(1f, 0.5f, 0f);

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    GridManager gridManager;
    

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        DisplayCoordinates();
        gridManager = FindObjectOfType<GridManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
            label.enabled = true;
        }
        SetLaberColor();
        ToggleLabels();

    }

    void DisplayCoordinates()
    {
        float div = 10;
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x/div);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / div);
        
        label.text = $"{coordinates.x}, {coordinates.y}";
        

          
    }

    void UpdateObjectName()
    {
        transform.parent.name = $"({coordinates.x} , {coordinates.y})";
    }

    void SetLaberColor()
    {
        if (gridManager == null) {return;}

        Node node = gridManager.GetNode(coordinates);

        if (node == null)
        {
            return;
        }

        if (!node.isWalkable)
        {
            label.color = blockedColor;
        }
        else if (node.isPath)
        {
            label.color = pathColor;
        }
        else if (node.isExplored)
        {
            label.color = exploredColor;
        }
        else
        {
            label.color = defaultColor;
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
