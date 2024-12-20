
using HttpServer.Core;
using HttpServer.Frame.Helper;
using HttpServer.Frame.Http;
using HttpServer.Frame.Tools;
using HttpServer.RunTime.Event;
using LitJson;
using static HttpServer.Core.CHttpServer;

public class DownLoadEvent : BaseEvent
{
    public override async void OnEvent(AsyncExpandPkg expand_pkg) 
    {
        if (expand_pkg.messPkg.ret != null) 
        {
            FileReqPkg pkg = JsonMapper.ToObject<FileReqPkg>(expand_pkg.messPkg.ret);
            string rela = pkg.relaPath;

            string[] split_str = rela.Split('\\');
            string name = split_str[split_str.Length - 1];
            string path = $"{FPath.STORAGE_ROOT_PATH}\\Data\\{pkg.relaPath}";

            DataSendPkg data = new DataSendPkg()
            { 
                fileName = name,
                relativePath = rela,
                fileData = await Tools.File2Bytes(path)
            };

            string str_data = await JsonHelper.AsyncToJson(data);
            httpMethod.HttpSendAsync(expand_pkg.Context, str_data, EventType.DownLoadEvent, OperateType.NONE);
        }
    }
}

/// <summary>
/// 文件请求包
/// </summary>
public class FileReqPkg
{
    public string relaPath;
}

public class DataSendPkg
{
    public string fileName;
    public string relativePath; // 相对路径
    public byte[] fileData;
}

