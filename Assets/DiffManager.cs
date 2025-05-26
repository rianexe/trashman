using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DiffManager : MonoBehaviour
{ 
    [SerializeField] private GameObject Diff;
    public int DiffNum;
    public GameObject texto;

    public void SumDiff(){
        if (DiffNum < 2) 
        DiffNum++;
    }

    public void SubDiff(){
        if (DiffNum > 0) 
        DiffNum--;
    }

    void Start()
    {
        DiffNum = 1;
        
    }

    void Update()
    {
        texto.GetComponent<Text>().text = DiffNum.ToString();

        if (DiffNum == 0){
           
            Diff.GetComponent<SpawnerDefault>().obstacleSpeed = 5f;
            Diff.GetComponent<SpawnerDefault>().obstacleSpawnTime = 1.5f;
      
        }

        if (DiffNum == 1){
       
            Diff.GetComponent<SpawnerDefault>().obstacleSpeed = 10f;
            Diff.GetComponent<SpawnerDefault>().obstacleSpawnTime = 1.5f;
      
        }

        if (DiffNum == 2){
         
            Diff.GetComponent<SpawnerDefault>().obstacleSpeed = 20f;
            Diff.GetComponent<SpawnerDefault>().obstacleSpawnTime = 0.7f;
           
        }
    }
}
