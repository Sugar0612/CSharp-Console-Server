﻿using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HttpServer.Core.CHttpServer;

namespace HttpServer.RunTime.Event
{
    public enum OperateType
    {
        NONE = 0, GET, ADD, REVISE, DELETE, SEARCH
    }

    public enum EventType
    {
        None = 0,
        UploadEvent,
        DownLoadEvent,
        CheckEvent,
        UserLoginEvent,
        RegisterEvent,
        GetProjInfo,
        GetEvent,
        UserEvent,
        MajorEvent,
        FacultyEvent,
        ClassEvent,
        ColumnsEvent,
        CourseEvent,
        ExamineEvent,
        ScoreEvent,
        ResEvent,
    }

    public abstract class BaseEvent
    {
        public virtual async void OnEvent(AsyncExpandPkg pkg) { await UniTask.Yield(); }
        public virtual async void GetInfoEvent(AsyncExpandPkg pkg) { await UniTask.Yield(); }
        public virtual async void AddEvent(AsyncExpandPkg pkg) { await UniTask.Yield(); }
        public virtual async void ReviseInfoEvent(AsyncExpandPkg pkg) { await UniTask.Yield(); }
        public virtual async void DeleteInfoEvent(AsyncExpandPkg pkg) { await UniTask.Yield(); }
        public virtual async void SearchInfoEvent(AsyncExpandPkg pkg) { await UniTask.Yield(); }
    }
}
