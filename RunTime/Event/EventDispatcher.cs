﻿using HttpServer.Frame.Http;
using HttpServer.Frame.Tools;

namespace HttpServer.RunTime.Event
{
    internal class EventDispatcher
    {
        private Dictionary<string, Action<BaseEvent, AsyncExpandPkg>> MethodDic = new Dictionary<string, Action<BaseEvent, AsyncExpandPkg>>()
        {
            {"GET", (_event, pkg) => _event.GetInfoEvent(pkg) },
            {"ADD", (_event, pkg) => _event.AddEvent(pkg) },
            {"REVISE", (_event, pkg) => _event.ReviseInfoEvent(pkg) },
            {"DELETE", (_event, pkg) => _event.DeleteInfoEvent(pkg) },
            {"SEARCH", (_event, pkg) => _event.SearchInfoEvent(pkg) },
            {"NONE", (_event, pkg) => _event.OnEvent(pkg) },
        };

        public void Dispatcher(params object[] objs)
        {
            AsyncExpandPkg pkg = objs[0] as AsyncExpandPkg;
            if (pkg == null) return;

            string operateType = pkg.messPkg.operate_type;
            string eventType = pkg.messPkg.event_type;
            BaseEvent @event = Tools.CreateObject<BaseEvent>(eventType);
            // Console.WriteLine($"Dispatcher: {operateType} || {eventType}");

            Action<BaseEvent, AsyncExpandPkg> action;
            MethodDic.TryGetValue(operateType, out action);
            action(@event, pkg);
        }
    }
}
