using System.IO;
using UnityEngine;

public class DataReader : MonoBehaviour
{
    public string fileName = "data.txt"; // Name of the text file
    private string[] roomData; // Array to hold the data

    void Start()
    {
        ReadDataFromFile();
    }

    void ReadDataFromFile()
    {
        // Get the path to the text file
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);

        // Check if the file exists
        if (File.Exists(filePath))
        {
            // Read all lines from the file and store them in the array
            roomData = File.ReadAllLines(filePath);

            // Print the data to the console (for debugging)
            foreach (string room in roomData)
            {
                Debug.Log(room);
            }
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
        }
    }
}