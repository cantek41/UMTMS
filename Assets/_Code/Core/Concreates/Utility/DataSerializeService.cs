using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Unity.Plastic.Newtonsoft.Json;
using Core.Component.Data;
using Core.Base;

public class DataSerializeService
{
    CompanentList list;

    public DataSerializeService(string jsonData)
    {
        Debug.Log(jsonData);
        //list =  JsonConvert.DeserializeObject<CompanentList>(jsonData);
    }


    public void setData2Companent(bool activeScenario = false)
    {
        foreach (var item in list.data)
        {

            // switch (Enum.Parse(typeof(EnumCompanentType), item.companentType))
            // {
            //     case EnumCompanentType.SWITCH:
            //         break;
            //     case EnumCompanentType.DOOR:
            //         break;
            //     case EnumCompanentType.COLORDISPLAY:
            //         break;
            //     case EnumCompanentType.TEXTDISPLAY:
            //         setTextData(item, activeScenario);
            //         break;
            //     case EnumCompanentType.ANALOGDISPLAY:
            //         break;
            //     case EnumCompanentType.VALVE:
            //         break;
            //     case EnumCompanentType.POT:
            //         break;
            //     case EnumCompanentType.BUTTON:
            //         break;
            //     case EnumCompanentType.SELECTOR:
            //         break;
            //     default:
            //         break;
            // }

        }
    }

    private void setHead(CompanentData companent, CompanentData item, bool activeScenario)
    {

        // companent.id = item.id;
        // companent.name = item.name;
        // companent.activeScenario = activeScenario;
        // companent.companentType = (EnumCompanentType)Enum.Parse(typeof(EnumCompanentType), item.companentType);
        // companent.behaviourType = (EnumBehaviourType)Enum.Parse(typeof(EnumBehaviourType), item.behaviourType);
    }


    private void setTextData(CompanentData item, bool activeScenario)
    {
        Debug.Log(item.name);

        // var companent = GameObject.Find(item.name).GetComponent<TextDisplay>();
        // companent.Data = ScriptableObject.CreateInstance<TextData>();
        // setHead(companent.Data, item, activeScenario);
        // companent.Data.value = item.features["value"].ToString();
        // companent.Data.activeScenario = activeScenario;
    }



}

[System.Serializable]
public class CompanentList
{
    public List<CompanentData> data;
}

[System.Serializable]
public class CompanentData
{
    public string name;
    public int id;
    public string behaviourType;
    public string companentType;
    public Dictionary<string, object> features = new Dictionary<string, object>();
}

