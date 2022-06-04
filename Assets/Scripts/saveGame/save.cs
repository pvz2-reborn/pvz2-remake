using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace CustomSaveLoadSystem
{
    public class SaveAndLoadSystem
    {
        /// <summary>
        /// 默认保存的相对路径
        /// </summary>
        private static string savePath = "SaveData";

        /// <summary>
        /// 报存数据
        /// </summary>
        /// <param name="saveObject">要保存的对象</param>
        /// <param name="name">要存入的文件名</param>
        public static void Save(object saveObject, string name = "save")
        {
            //创建文件夹
            string folderPath = System.IO.Path.Combine(Application.dataPath, savePath); //文件夹路径
            System.IO.Directory.CreateDirectory(folderPath);

            //创建一个空白文件
            string fileName = name + ".json";                                           //文件名
            string filePath = System.IO.Path.Combine(folderPath, fileName);             //文件路径
            System.IO.File.Create(filePath).Dispose();

            //序列化
            string str_json = JsonConvert.SerializeObject(saveObject);

            //写入文件
            System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath);
            sw.Write(str_json);
            sw.Close();

            //确认保存
            if (System.IO.File.Exists(filePath))
                Debug.Log("保存成功");
            else
                Debug.Log("保存失败");
        }

        /// <summary>
        /// 取出存储的数据
        /// </summary>
        /// <typeparam name="T">取出类型</typeparam>
        /// <param name="loadObject">将取出数据放入</param>
        /// <param name="name">文件名</param>
        /// <returns>返回是否能够读取成功</returns>
        public static bool Load<T>(out T loadObject, string name = "save")
        {
            //找出文件路径
            string folderPath = System.IO.Path.Combine(Application.dataPath, savePath); //文件夹路径
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
                Debug.Log("成功读取");
                return true;
            }
            Debug.Log("读取失败");
            return false;
        }
    }
    public struct SerializeableVector2
    {

        public SerializeableVector2(Vector2 vec)
        {
            this.x = vec.x;
            this.y = vec.y;
        }

        public double x;
        public double y;
        public Vector2 ToVector2()
        {
            return new Vector2((float)x, (float)y);
        }
    }
}
