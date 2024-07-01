using UnityEngine;
using static Unity.PlasticSCM.Editor.WebApi.CredentialsResponse;
using UnityEngine.UIElements;

public class BuilderManager : MonoBehaviour
{
    public static BuilderManager Instance;

    public GameObject magicTowerPrefab;
    public GameObject windmillPrefab;
    public GameObject stoneWallPrefab;

    public GameObject placePrefab;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool TryBuildTower(Vector3 position, string towerType, GameObject placeGameobject)
    {
        GameObject prefabToInstantiate = null;

        switch (towerType)
        {
            case "MagicTower":
                prefabToInstantiate = magicTowerPrefab;
                break;
            case "Windmill":
                prefabToInstantiate = windmillPrefab;
                break;
            case "StoneWall":
                prefabToInstantiate = stoneWallPrefab;
                break;
            default:
                Debug.LogError("Invalid tower type!");
                return false;
        }

        Building buildingComponent = prefabToInstantiate.GetComponent<Building>();

        if (GameManager.Instance.SpendPoints(buildingComponent.cost))
        {
            GameObject tower = Instantiate(prefabToInstantiate, position, Quaternion.identity);
            tower.GetComponent<Building>().placeGameobject = placeGameobject;
            return true;
        }
        else
        {
            Debug.Log("Not enough points!");
            return false;
        }
    }

    public void DemolishBuilding(GameObject building, GameObject place)
    {
        /*Instantiate(placePrefab, building.transform.position, Quaternion.identity);*/
        place.SetActive(true);
        Destroy(building);
    }
}