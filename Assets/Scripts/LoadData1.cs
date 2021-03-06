using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class LoadData1 : MonoBehaviour
{
    //public Street street;
    //public Street streetleaving;
    List<List<int>> dataLines = new List<List<int>>();
    PathFinder pathFinder;
    public GameObject pathFinderObj;
    // Start is called before the first frame update
    void Start()
    {
        pathFinder = pathFinderObj.GetComponent<PathFinder>();
        readfile();
        //printData();
        StartCoroutine(importData("45.Duong14"));
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.B))
        {
            foreach (Street b in pathFinder.graphData.allStreets)
            {
                if (b.Name == "hvt1")
                {
                    Debug.Log(b.center.ID);
                }
            }
            //foreach (Node a in graphData.centers)
            //{
            //    Debug.Log(a.pathDistance + "   :    " + a.ID);

            //}
            // SpawnRealtime(13);
        }
    }
    IEnumerator importData(string nameStr)
    {
        StartCoroutine(pathFinder.Spawn(dataLines[0][0], nameStr, 0));
        StartCoroutine(pathFinder.Spawn(dataLines[0][1], nameStr, 1));
        StartCoroutine(pathFinder.Spawn(dataLines[0][2], nameStr, 2));
        yield return new WaitForSeconds(6);
        StartCoroutine(pathFinder.Spawn(dataLines[0][3], nameStr, 3));

        // pathFinder.spawCarInStreet("hvt", "hvt2", 0);
        // street.spawns[0] = dataLines[0][2];
    }
    private void readfile()
    {
        string pathTxt = Application.dataPath + "/Data/45.txt";
        List<string> fileLines = File.ReadAllLines(pathTxt).ToList();
        foreach(string line in fileLines)
        {
            ParseFile(line);
        }
    }
    void ParseFile(string path)
    {
        char[] separators = { ',', ';', '|',' ' };
        string[] strValues = path.Split(separators);
        List<int> intValues = new List<int>();
        foreach (string str in strValues)
        {
            int val = 0;
            if (int.TryParse(str, out val))
                intValues.Add(val);
        }
        dataLines.Add(intValues);
    }
    void printData()
    {
        for(int i = 0; i < dataLines.Count; i++)
        {
            for(int j = 0; j < dataLines[i].Count; j++)
            {
                Debug.Log(dataLines[i][j]);
            }
        }
    }
}
