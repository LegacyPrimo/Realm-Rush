using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabel : MonoBehaviour
{
    [SerializeField] private Color defaultColor = Color.white;
    [SerializeField] private Color blockedColor = Color.gray;

    private TextMeshPro labelGrid;
    private Vector2Int coordinateVector = new Vector2Int();
    private Waypoint waypoint;

    private void Awake()
    {
        labelGrid = GetComponent<TextMeshPro>();
        waypoint = GetComponentInParent<Waypoint>();

        labelGrid.enabled = false;
        DisplayCoordinates();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!Application.isPlaying) 
        {
            DisplayCoordinates();
            UpdateObjectName();
        }   

        SetLabelColor();
        ToggleLabels();
    }

    private void ToggleLabels() 
    {
        if (Input.GetKeyDown(KeyCode.C)) 
        {
            labelGrid.enabled = !labelGrid.IsActive();
        }
    }

    private void DisplayCoordinates() 
    {
        #if UNITY_EDITOR
        coordinateVector.x = Mathf.RoundToInt(transform.parent.position.x / EditorSnapSettings.move.x);
        coordinateVector.y = Mathf.RoundToInt(transform.parent.position.z / EditorSnapSettings.move.z);
        #endif

        labelGrid.text = coordinateVector.x + "," + coordinateVector.y;
    }

    private void SetLabelColor() 
    {
        if (waypoint.IsPlaceable)
        {
            labelGrid.color = defaultColor;
        }
        else 
        {
            labelGrid.color = blockedColor;
        }
    }

    private void UpdateObjectName() 
    {
        transform.parent.name = coordinateVector.ToString();
    }
}
