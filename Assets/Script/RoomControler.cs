using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
public class RoomControler : MonoBehaviour
{
    public TMP_Dropdown dropDownRoom;
    public Sprite sprite;
    public string[] roomNames;
    public GameObject linRender;
    public Transform parentObject; // Reference to the parent GameObject
    public Transform[] points;
    public CalculatePath calculatePath;
    public int roomNumper;
    public DynamicCamera Camera;

    private void Start()
    {
        // Get all child GameObjects from the parent and store them in the array
        points = new Transform[parentObject.childCount];

        for (int i = 0; i < parentObject.childCount; i++)
        {
            points[i] = parentObject.GetChild(i).transform;
        }
        // Initialize the roomNames array with the same length as points
        roomNames = new string[points.Length];

        for (int i = 0; i < points.Length; i++)
        {
            roomNames[i] = points[i].name;
        }
        dropDownRoom.options.Clear();

        // Create a list of OptionData for the dropdown
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
        //options.Add(new TMP_Dropdown.OptionData("Rooms", sprite, Color.white));
        for (int i = 0;i < roomNames.Length; i++) 
        {
            options.Add(new TMP_Dropdown.OptionData(roomNames[i], sprite,Color.white));
        }

        dropDownRoom.AddOptions(options);
    }
    public void Room()
    {
        roomNumper=dropDownRoom.value;
        linRender.SetActive(true);
        calculatePath.destinationObject = points[roomNumper];
        Camera.EndPoint= points[roomNumper];
    }
}

