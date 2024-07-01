using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;
using System.Linq;

public class TowerPlace : MonoBehaviour
{
    public SerializableDictionary<string, bool> compatibleTypes = new SerializableDictionary<string, bool>();

    private void Awake()
    {
        if (compatibleTypes.Count == 0)
        {
            compatibleTypes["MagicTower"] = false;
            compatibleTypes["Windmill"] = false;
            compatibleTypes["StoneWall"] = false;
        }
    }

    /*public List<string> compatibleTypes = new List<string>();
    public bool magicTower = false;
    public bool stoneWall = false;
    public bool windmill = false;*/

    public void BuildTower(string towerType)
    {
        if (compatibleTypes.ContainsKey(towerType) && compatibleTypes[towerType])
        {
            
            Vector3 position = transform.position;
            if(BuilderManager.Instance.TryBuildTower(position, towerType, gameObject))
            {
                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Couldn't build the building.");
            }
        }
    }
}