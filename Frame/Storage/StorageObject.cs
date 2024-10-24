﻿using HttpServer.Frame.Helper;
using HttpServer.Frame.Tools;
using LitJson;

namespace HttpServer.Frame.Storage
{
    internal class StorageObject
    {
        public List<ResourcesInfo> rsCheck = new List<ResourcesInfo>();
        public List<UserInfo> usersInfo = new List<UserInfo>();
        public List<FacultyInfo> faculiesInfo = new List<FacultyInfo>();
        public List<MajorInfo> majorInfo = new List<MajorInfo>();
        public List<ClassInfo> classesInfo = new List<ClassInfo>();
        public List<ColumnsInfo> columnsInfo = new List<ColumnsInfo>();
        public List<CourseInfo> courseInfo = new List<CourseInfo>();
        public List<ExamineInfo> examineesInfo = new List<ExamineInfo>();
        public List<ScoreInfo> scoresInfo = new List<ScoreInfo>();
        public List<SoftwareInfo> softwareInfo = new List<SoftwareInfo>();

        public void Init()
        {
            HardDisk2Memory(PathAPI.STORAGE_USER, out usersInfo);
            HardDisk2Memory(PathAPI.STORAGE_RESOURCE, out rsCheck);
            HardDisk2Memory(PathAPI.STORAGE_FACULTY, out faculiesInfo);
            HardDisk2Memory(PathAPI.STORAGE_MAJOR, out majorInfo);
            HardDisk2Memory(PathAPI.STORAGE_CLASS, out classesInfo);
            HardDisk2Memory(PathAPI.STORAGE_COLUMNS, out columnsInfo);
            HardDisk2Memory(PathAPI.STORAGE_COURSE, out courseInfo);
            HardDisk2Memory(PathAPI.STORAGE_EXAMINE, out examineesInfo);
            HardDisk2Memory(PathAPI.STORAGE_SCORE, out scoresInfo);
            HardDisk2Memory(PathAPI.STORAGE_SOFTWARE, out softwareInfo);
        }

        public void Save()
        {
            Memory2HardDisk(PathAPI.STORAGE_USER, usersInfo);
            Memory2HardDisk(PathAPI.STORAGE_RESOURCE, rsCheck);
            Memory2HardDisk(PathAPI.STORAGE_FACULTY, faculiesInfo);
            Memory2HardDisk(PathAPI.STORAGE_MAJOR, majorInfo);
            Memory2HardDisk(PathAPI.STORAGE_CLASS, classesInfo);
            Memory2HardDisk(PathAPI.STORAGE_COLUMNS, columnsInfo);
            Memory2HardDisk(PathAPI.STORAGE_COURSE, courseInfo);
            Memory2HardDisk(PathAPI.STORAGE_EXAMINE, examineesInfo);
            Memory2HardDisk(PathAPI.STORAGE_SCORE, scoresInfo);
            Memory2HardDisk(PathAPI.STORAGE_SOFTWARE, softwareInfo);
        }

        private void HardDisk2Memory<T>(string filePath, out List<T> targetList)
        {
            string jsonString = FileHelper.ReadTextFile(filePath);
            if (jsonString.Count() == 0)
            {
                targetList = new List<T>();
                return;
            }
            
            targetList = JsonMapper.ToObject<List<T>>(jsonString);
        }

        private void Memory2HardDisk<T>(string savePath, List<T> saveList)
        {
            if (saveList == null) return;
            string json = JsonMapper.ToJson(saveList);
            Console.WriteLine($"{savePath}: {json}");
            FileHelper.WriteTextFile(savePath, json);
        }
    }
}
