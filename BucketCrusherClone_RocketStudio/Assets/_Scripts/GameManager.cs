using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] SawBreaker sawBreaker;
    [SerializeField] int maxBlock;
    [SerializeField] GameObject winCanvas;
    bool isWin;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(sawBreaker.GetListCount() >= maxBlock)
        {
            Win();
        }
    }

    void Win()
    {
        isWin = true;
        winCanvas.SetActive(true);
    }

    public void ResetGame()
    {
        sawBreaker.ClearListCount();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public bool IsWin()
    {
        return isWin;
    }
}
