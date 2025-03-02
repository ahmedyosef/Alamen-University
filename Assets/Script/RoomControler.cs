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
    public Transform parentObjectOfRoom; // Reference to the parent GameObject
    public Transform[] Roompoints;
    public CalculatePath calculatePath;
    public int roomNumper;
    public DynamicCamera Camera;

    public TMP_Dropdown dropDownServices;
    public Transform parentObjectOfServices; // Reference to the parent GameObject
    public Transform[] servicespoints;
    public string[] servicesNames;

    private void Start()
    {
        roomData();
        servicesData();
    }
    public void roomData()
    {
        // Get all child GameObjects from the parent and store them in the array
        Roompoints = new Transform[parentObjectOfRoom.childCount];

        for (int i = 0; i < parentObjectOfRoom.childCount; i++)
        {
            Roompoints[i] = parentObjectOfRoom.GetChild(i).transform;
        }
        // Initialize the roomNames array with the same length as points
        roomNames = new string[Roompoints.Length];

        for (int i = 0; i < Roompoints.Length; i++)
        {
            roomNames[i] = Roompoints[i].name;
        }
        dropDownRoom.options.Clear();

        // Create a list of OptionData for the dropdown
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
        //options.Add(new TMP_Dropdown.OptionData("Rooms", sprite, Color.white));
        for (int i = 0; i < roomNames.Length; i++)
        {
            options.Add(new TMP_Dropdown.OptionData(roomNames[i], sprite, Color.white));
        }

        dropDownRoom.AddOptions(options);
    }
    public void Room()
    {
        dropDownServices.value = 0;
        roomNumper= dropDownRoom.value;
        linRender.SetActive(true);
        calculatePath.destinationObject = Roompoints[roomNumper];
        Camera.EndPoint= Roompoints[roomNumper];
    }

    void servicesData()
    {
        // Get all child GameObjects from the parent and store them in the array
        servicespoints = new Transform[parentObjectOfServices.childCount];

        for (int i = 0; i < parentObjectOfServices.childCount; i++)
        {
            servicespoints[i] = parentObjectOfServices.GetChild(i).transform;
        }
        // Initialize the servicesNames array with the same length as points
        servicesNames = new string[servicespoints.Length];

        for (int i = 0; i < servicespoints.Length; i++)
        {
            servicesNames[i] = servicespoints[i].name;
        }
        dropDownServices.options.Clear();

        // Create a list of OptionData for the dropdown
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
        //options.Add(new TMP_Dropdown.OptionData("Rooms", sprite, Color.white));
        for (int i = 0; i < servicesNames.Length; i++)
        {
            options.Add(new TMP_Dropdown.OptionData(servicesNames[i], sprite, Color.white));
        }

        dropDownServices.AddOptions(options);
    }
    public void Services()
    {
        dropDownRoom.value = 0;
        roomNumper = dropDownServices.value;
        linRender.SetActive(true);
        calculatePath.destinationObject = servicespoints[roomNumper];
        Camera.EndPoint = servicespoints[roomNumper];
    }
}

