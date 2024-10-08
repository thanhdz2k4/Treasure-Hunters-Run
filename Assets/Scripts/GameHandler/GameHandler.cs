using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    [SerializeField]
    Factory[] factories;

    private List<GameObject> createProducts = new List<GameObject>();

    [SerializeField]
    SpawnMap spawnMap;

    [SerializeField]
    EnemyHandler enemyHandler;

    [SerializeField]
    UIHandler UiHandler;


    [SerializeField]
    Transform player;

    [SerializeField]
    Transform PlayerBoost;

    [SerializeField]
    Transform grid;

    [SerializeField]
    float xBound;

    [SerializeField]
    float yBound;



    private void Start()
    {
        //distanceMove = PlayerPrefs.GetFloat("Distance");
        player = GameObject.Find("Player").transform;
        grid = GameObject.Find("Grid").transform;
    }

    void Update()
    {
        SpawnProcs();
        FallGame();
    }

    private void FallGame()
    {

        if (player.transform.localPosition.x  < xBound || player.transform.localPosition.y < yBound)
        {
            UiHandler.FallGameScreen();
            
            VelocityHandler.Instance.Pause();
        }

        if (PlayerBoost.transform.localPosition.x < xBound || PlayerBoost.transform.localPosition.y < yBound)
        {
            UiHandler.FallGameScreen();
            
            VelocityHandler.Instance.Pause();
        }
    }


   



    public void GetPositionToSpawnEnemy(Transform pos)
    {
        GameObject newObj = enemyHandler.GetPositionToSpawnEnemy(pos);  
        newObj.transform.SetParent(pos);
    }

    // Update is called once per frame
    

    private void SpawnProcs()
    {
        Transform pos = spawnMap.MakeMap();
        if(pos != null)
        {
            Transform child = pos.Find("PositionSpawnEnemy");
            Transform postionSpawnCoin = pos.Find("PositionSpawnCoin");
            if(child != null)
            {
                GetPositionToSpawnEnemy(child);
                
            }

            if(postionSpawnCoin != null)
            {
                GetProductFromFactory(0, postionSpawnCoin);
            }
           
        }
    }

    private void GetProductFromFactory(int index, Transform positionToSpawn)
    {
        if(index < factories.Length)
        {
            Factory selectedFactory = factories[index];
            IProduct product = selectedFactory.GetProduct(positionToSpawn);
            if(product is Component component)
            {
                createProducts.Add(component.gameObject);
            }
        }
        
    }

    public void PauseGame()
    {
        SetActiveMonobehaviorOfChild(false);
        VelocityHandler.Instance.Pause();
    }

    public void ResumeGame()
    {
        if(VelocityHandler.Instance.currentDistance > 0) {
            SetActiveMonobehaviorOfChild(true);
            VelocityHandler.Instance.Continue();
        }
      
    }

    private void SetActiveMonobehaviorOfChild(bool isActive)
    {
        foreach (Transform child in this.grid.transform)
        {
            MoveBehind moveBehind = child.GetComponent<MoveBehind>();
            if (moveBehind != null)
            {
                moveBehind.enabled = isActive; // Enable the MoveBehind component
            }
        }
    }

    public void ResetGame()
    {
        VelocityHandler.Instance.ResetData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SaveSystem.Instance.ResetData();
    }

    


}
