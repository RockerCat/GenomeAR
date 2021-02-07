using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonsManager : MonoBehaviour
{
    private GameObject hexagon0;
    public Hexagon HexagonPrefab;

    private float constX = 0.078f;
    private float constY = 0.131f;

    public void SetUserHexagon(string _name, string _url)
    {
        hexagon0 = Instantiate(HexagonPrefab.gameObject, transform.position, Quaternion.identity);
        hexagon0.transform.parent = this.transform;
        hexagon0.GetComponent<Hexagon>().itemType = "UserInfo";
        hexagon0.GetComponent<Hexagon>().SetHexagon(_name, _url);
    }

    public void SetMenuHexagons(string[] _itemList)
    {
        int aux = 0;
        int auxY = 1;
        for (int i = 0; i < _itemList.Length; i++)
        {
            GameObject hexagonNew = Instantiate(HexagonPrefab.gameObject, transform.position, Quaternion.identity);
            hexagonNew.transform.parent = this.transform;
            hexagonNew.GetComponent<Hexagon>().itemType = _itemList[i];
            hexagonNew.GetComponent<Hexagon>().SetHexagon(_itemList[i]);

            string temp = GetKind(i + 1);

            switch (temp)
            {
                case "A": hexagonNew.transform.position = new Vector3(hexagon0.transform.position.x + (constX * ((i + 1) - aux)), hexagon0.transform.position.y - (constY * auxY), hexagon0.transform.position.z); aux++; break;
                case "B": hexagonNew.transform.position = new Vector3(hexagon0.transform.position.x - (constX * ((i + 1) - aux)), hexagon0.transform.position.y - (constY * auxY), hexagon0.transform.position.z); aux++; break;
                case "C": hexagonNew.transform.position = new Vector3(hexagon0.transform.position.x + (constX * ((i + 1) - aux)), hexagon0.transform.position.y + (constY * auxY), hexagon0.transform.position.z); aux++; break;
                case "D": hexagonNew.transform.position = new Vector3(hexagon0.transform.position.x - (constX * ((i + 1) - aux)), hexagon0.transform.position.y + (constY * auxY), hexagon0.transform.position.z); break;
                case "E": hexagonNew.transform.position = new Vector3(hexagon0.transform.position.x + (constX * ((i + 1) - aux)), hexagon0.transform.position.y + (constY * 0), hexagon0.transform.position.z); aux++; break;
                case "F": hexagonNew.transform.position = new Vector3(hexagon0.transform.position.x - (constX * ((i + 1) - aux)), hexagon0.transform.position.y + (constY * 0), hexagon0.transform.position.z); break;
            }
        }
    }

    public void SetHexagons(JSONObject _itemList)
    {
        int aux = 0;
        int auxY = 1;
        for (int i = 0; i < _itemList.list.Count; i++)
            {
            GameObject hexagonNew = Instantiate(HexagonPrefab.gameObject, transform.position, Quaternion.identity);
            hexagonNew.transform.parent = this.transform;
            hexagonNew.GetComponent<Hexagon>().SetHexagon(_itemList[i].GetField("name").str);
            
            string temp = GetKind(i + 1);

            switch (temp)
            {
                case "A": hexagonNew.transform.position = new Vector3(hexagon0.transform.position.x + (constX * ((i + 1) - aux)), hexagon0.transform.position.y - (constY * auxY), hexagon0.transform.position.z);  aux++;  break;
                case "B": hexagonNew.transform.position = new Vector3(hexagon0.transform.position.x - (constX * ((i + 1) - aux)), hexagon0.transform.position.y - (constY * auxY), hexagon0.transform.position.z);  aux++;  break;
                case "C": hexagonNew.transform.position = new Vector3(hexagon0.transform.position.x + (constX * ((i + 1) - aux)), hexagon0.transform.position.y + (constY * auxY), hexagon0.transform.position.z);  aux++;  break;
                case "D": hexagonNew.transform.position = new Vector3(hexagon0.transform.position.x - (constX * ((i + 1) - aux)), hexagon0.transform.position.y + (constY * auxY), hexagon0.transform.position.z);          break;
                case "E": hexagonNew.transform.position = new Vector3(hexagon0.transform.position.x + (constX * ((i + 1) - aux)), hexagon0.transform.position.y + (constY * 0), hexagon0.transform.position.z);     aux++;  break;
                case "F": hexagonNew.transform.position = new Vector3(hexagon0.transform.position.x - (constX * ((i + 1) - aux)), hexagon0.transform.position.y + (constY * 0), hexagon0.transform.position.z);             break;
            }
        }
    }

    public void ClearHexagons()
    {
        foreach (Transform child in transform)
        {
            if(child.gameObject.GetComponent<Hexagon>())
            {
                if (child.gameObject.GetComponent<Hexagon>().itemType != "UserInfo")
                {
                    Destroy(child.gameObject);
                }
            }          
             
        }
    }

    private string GetKind(int pos)
    {
        int module = pos / 6;
        float divide = pos / 6f;

        float calc = divide - module;
        string to_return = "";
        
        switch (calc.ToString("F2"))
        {
            case "0.17": to_return = "A"; break;
            case "0.33": to_return = "B"; break;
            case "0.50": to_return = "C"; break;
            case "0.67": to_return = "D"; break;
            case "0.83": to_return = "E"; break;
            case "0.00": to_return = "F"; break;
        }
        return (to_return);
    }

}
