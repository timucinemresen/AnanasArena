using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    public GameObject prefab;
    public Transform[] tf;
    public static bool IsStageFinished;

    void Start () {
        tf = new Transform[8];
        ComponentFunction();

        FirstSpawn();
        InvokeRepeating("SpawnUpdate", 5, 5);
        IsStageFinished = false;
	}
	
	void Update () {
        FunctionCancelInvoke();
        FinishedStage();
    }

    // Başlangıçtaki 8 kişinin spawn olmasını sağlar.
    void FirstSpawn()
    {
        for (int i = 0; i < tf.Length; i++)
        {
            Instantiate(prefab, new Vector3(tf[i].transform.position.x, 1, tf[i].transform.position.z), Quaternion.identity);
        }
        ArmySizeDetector.armySizeCounter = ArmySizeDetector.minArmySize;
    }

    // InvokeRepeating için clone üretir ve kişi sayısını düzenler.
    void SpawnUpdate()
    {
        float x = Random.Range(-29f, 26f);
        float z = Random.Range(-26f, 18f);
        Instantiate(prefab, new Vector3(x, 1, z), Quaternion.identity);
        ArmySizeDetector.armySizeCounter++;
    }

    // Sahadaki kişi sayısı olması gerekene ulaşınca InvokeRepeating iptal eder.
    void FunctionCancelInvoke()
    {
        if(ArmySizeDetector.armySizeCounter==ArmySizeDetector.maxArmySize)
            CancelInvoke();
    }

    void FinishedStage()
    {
        if (StageDetector.IsStageClear == true)
        {
            gameObject.AddComponent<SpawnEnemy>();
            Destroy(this);
        }
    }

    void ComponentFunction()
    {
        prefab = gameObject.GetComponent<ForSpawnPrefab>().prefab;

        for (int i = 0; i < 8; i++)
        {
            tf[i] = gameObject.GetComponent<ForSpawnPrefab>().tf[i];
        }
    }
}
