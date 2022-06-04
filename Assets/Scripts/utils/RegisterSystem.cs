using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

using Plant;

public class RegisterSystem : MonoBehaviour
{
    public class MainConfig {
        public string version {get; set; }
        public string plantConfig {get; set; }
    }
    public MainConfig mainConfig = new MainConfig();

    public class PlantTypeList {
        public string version {get; set; }
        public string name;
    }
    public List<PlantTypeList> PlantLists;

    private static string configPath = "Config";
    public string config;

    public static bool LoadConfig<T>(out T loadObject, string name = "config", string Path = "Config")
    {
        //读取配置文件
        string folderPath = System.IO.Path.Combine(Application.dataPath, Path); //配置文件夹路径
        string fileName = name + ".json";                                           //文件名
        string filePath = System.IO.Path.Combine(folderPath, fileName);             //文件路径
        loadObject = default;

        if (System.IO.File.Exists(filePath))
        {
            //读取文件
            System.IO.StreamReader sr = new System.IO.StreamReader(filePath);
            string str_json = sr.ReadToEnd();
            sr.Close();
            //反序列化
            loadObject = JsonConvert.DeserializeObject<T>(str_json);
            Debug.Log("成功读取Config");
            return true;
        }
        Debug.Log("Config读取失败");
        return false;
    }
    //public string plants;
    List <basePlant> plants = new List<basePlant>();
    basePlant plant = new basePlant();

    public void RegisterPlantType () {
        //读取主配置文件
        LoadConfig<MainConfig>(out mainConfig);
        //读取植物主配置文件

        //读取植物配置文件

        LoadConfig<basePlant>(out plant, "peashooter", System.IO.Path.Combine(configPath, mainConfig.plantConfig));
        Debug.Log (plant.HP);
        plants.Add(plant);
        Debug.Log (plants[0].HP);
    }

    void Start()
    {
        RegisterPlantType();
    }
    void Update()
    {
        
    }
}
