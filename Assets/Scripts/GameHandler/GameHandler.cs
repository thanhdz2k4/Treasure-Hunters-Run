using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    [SerializeField]
    SpawnMap spawnMap;

    [SerializeField]
    EnemyHandler enemyHandler;

    [SerializeField]
    UIHandler UiHandler;

    [SerializeField]
    Transform player;

    [SerializeField]
    Transform Cam;

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
        SpawnMapAndEnemy();
        ResetGame();
        FallGame();
    }

    private void FallGame()
    {
        
        if(player.transform.localPosition.x + xBound < Cam.position.x || player.transform.localPosition.y + yBound< Cam.position.y)
        {
            UiHandler.FallGameScreen();
        }
    }



    public void GetPositionToSpawnEnemy(Transform pos)
    {
        GameObject newObj = enemyHandler.GetPositionToSpawnEnemy(pos);  
        newObj.transform.SetParent(pos);
    }

    // Update is called once per frame
    

    private void SpawnMapAndEnemy()
    {
        Transform pos = spawnMap.MakeMap();
        if(pos != null)
        {
            Transform child = pos.Find("PositionSpawnEnemy");
            if(child != null)
            {
                GetPositionToSpawnEnemy(child);
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
        if(Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            VelocityHandler.Instance.ResetData();
        }
        //VelocityHandler.Instance.ResetData();
        
    }

    


}
