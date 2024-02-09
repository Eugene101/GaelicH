using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RivalsController : MonoBehaviour
{
    public GameObject[] rivalPrefabs;
    public string[] names;
    public float[] speed;
    public RuntimeAnimatorController[] rivalsControllers;
    public float[] enemyShootAccuracy;
    public float[] enemyRechargeTime;
    public float[] tendencyToShoot;
    public float[] starsRating;
    public Sprite[] rivalAvatars;
    public Quaternion[] rot;
    public Transform[] dots;
    public TextAsset csvFile;
    List<int> forMenu = new List<int>();
    public GameObject barbell;
    
    //public RuntimeAnimatorController sittingAnim;
    //public RuntimeAnimatorController standingAnim;
    //public RuntimeAnimatorController fitnessAnim;
    //[SerializeField] public float[] enemyShootAccuracy;
    //[SerializeField] public float[] enemyRechargeTime;
    //[SerializeField] public float[] enemyTendencyToShoot;

    //List<float> enemySpeed = new List<float>();

    //private int[] rate;
    //private int[] starsNo;
    // Start is called before the first frame update

    public static RivalsController Singleton { get; set; }

    void Awake()
    {
        if (!Singleton)
        {
            Singleton = this;
            DontDestroyOnLoad(this);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Destroy(this);
        }
    }
    void Start()
    {
        LoadCSVFile(csvFile);
        InstantiateRivals();

    }

    private void LoadCSVFile(TextAsset csv)
    {
        string[] lines = csv.text.Split('\n'); // Split the file into lines
        speed = new float[rivalPrefabs.Length];
        enemyShootAccuracy = new float[rivalPrefabs.Length];
        enemyRechargeTime = new float[rivalPrefabs.Length];
        tendencyToShoot = new float[rivalPrefabs.Length];
        starsRating = new float[rivalPrefabs.Length];

        for (int i = 0; i < rivalPrefabs.Length; i++)
        {
            forMenu.Add(i);
            string[] values = lines[i].Split(','); // Split the line into values

            // Parse the values into the appropriate arrays
            float speedValue, accuracyValue, rechargeTimeValue, tendencyValue, ratingStarsValue;
            if (float.TryParse(values[0], out speedValue))
            {
                speed[i] = speedValue;
            }
            if (values.Length > 1 && float.TryParse(values[1], out accuracyValue))
            {
                enemyShootAccuracy[i] = accuracyValue;
            }
            if (values.Length > 2 && float.TryParse(values[2], out rechargeTimeValue))
            {
                enemyRechargeTime[i] = rechargeTimeValue;
            }
            if (values.Length > 3 && float.TryParse(values[3], out tendencyValue))
            {
                tendencyToShoot[i] = tendencyValue;
            }
            if (values.Length > 4 && float.TryParse(values[4], out ratingStarsValue))
            {
                starsRating[i] = ratingStarsValue;
            }
            //print("name: " + names[i] + " enemySpeed: " + Speed[i] + " enemyShootAccuracy: " + enemyShootAccuracy[i] + " enemyRechargeTime: " + enemyRechargeTime[i] + " enemyTendencyToShoot: " + TendencyToShoot[i]);
        }
    }

    void InstantiateRivals()
    {
        for (int i = 0; i < dots.Length; i++)
        {
            int num;
            do
            {
                num = Random.Range(0, forMenu.Count);
            } while (!forMenu.Contains(num));

            print("num= " + num);
            Vector3 pos = dots[i].transform.position;
            //Quaternion rot = Quaternion.Euler(0f, 90f, 0f);
            GameObject rival = Instantiate(rivalPrefabs[num], pos, rot[i]);
            var anim = rival.gameObject.GetComponent<Animator>();
            anim.runtimeAnimatorController = rivalsControllers[i];
            rival.AddComponent<MenuAnimatorController>();
            forMenu.Remove(num);
            if (i == dots.Length - 1)
            {
                print("eofc " + i);
                rival.name = "GymMan";
            }
        }

        BarbellsAdd();
    }

    void BarbellsAdd()
    {
        GameObject GymMan = GameObject.Find("GymMan");
        Transform LeftHand;
        Transform RightHand;
        Vector3 shift;

        LeftHand = FindChildRecursive(GymMan.transform, "LeftHand");
        RightHand = FindChildRecursive(GymMan.transform, "RightHand");
        shift = new Vector3(0f, 0.061f, 0f);
        Quaternion rot = new Quaternion(0f, 90f, 0f,0);
        GameObject LeftBarbel = Instantiate(barbell, LeftHand.transform.position-shift, transform.rotation);
        GameObject RightBarbel = Instantiate(barbell, RightHand.transform.position - shift, transform.rotation);
        LeftBarbel.transform.SetParent(LeftHand);
        RightBarbel.transform.SetParent(RightHand);
    }

    private Transform FindChildRecursive(Transform parent, string name)
    {
        Transform child = parent.Find(name);
        if (child != null)
        {
            return child;
        }

        for (int i = 0; i < parent.childCount; i++)
        {
            child = FindChildRecursive(parent.GetChild(i), name);
            if (child != null)
            {
                return child;
            }
        }
        return null;
    }
}

