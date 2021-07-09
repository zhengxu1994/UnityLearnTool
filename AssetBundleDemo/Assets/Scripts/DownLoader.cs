using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

namespace ZFramework
{
    /// <summary>
    /// 下载资源 ，支持断点续传
    /// </summary>
    public class DownLoader
    {
        /// <summary>
        /// 一个载单元
        /// </summary>
        public class DownloadUnit
        {
            public string downUrl;
            public string savePath;

            public DownloadUnit(string url, string path)
            {
                this.downUrl = url;
                this.savePath = path;
            }
        }

        const int oneReadLen = 16384;//一次读取长度 16kb

        const int ReadWriteTimeOut = 2 * 1000;//超时等待时间

        const int TimeOutWait = 5 * 1000;//超时等待时间

        const int MaxTryTime = 3;

        /// <summary>
        /// 批量下载
        /// </summary>
        /// <param name="list"></param>
        /// <param name="callback"></param>
        public static void BatchDownLoad(List<DownloadUnit> list,System.Action<long,long,DownloadUnit>callback)
        {
            
        }

        /// <summary>
        /// 单个下载
        /// </summary>
        /// <param name="downUnit"></param>
        /// <param name="callback"></param>
        /// <param name="errorCallback"></param>
        public static void SingleDownload(DownloadUnit downUnit, System.Action<long, long> callback, System.Action<DownloadUnit> errorCallback = null)
        {

        }

        // <summary>
        /// 下载
        /// </summary>
        /// <param name="downList"></param>
        /// <param name="callback"></param>
        static void download(List<DownloadUnit> downList, System.Action<long, long, DownloadUnit> callback, System.Action<DownloadUnit> errorCallback = null)
        {
            // 计算所有要下载的文件大小
            long totalSize = 0;
            long oneSize = 0;
            DownloadUnit unit;
            int i = 0;
            for (i = 0; i < downList.Count; i++)
            {
                unit = downList[i];
                oneSize = GetWebFileSize(unit.downUrl);
                totalSize += oneSize;
            }

            long currentSize = 0;
            i = 0;
            int count = downList.Count;
            for (i = 0; i < count; i++)
            {
                unit = downList[i];
                long currentFileSize = 0;
                download(unit, (long _currentSize, long _fileSize) => {
                    currentFileSize = _currentSize;
                    long tempCurrentSize = currentSize + currentFileSize;
                    Debug.LogFormat("i = {0}，tempCurrentSize = {1}， _fileSize = {2}，currentSize = {3}， totalSize = {4}",
                        i, tempCurrentSize, _fileSize, currentSize, totalSize);
                    if (callback != null) callback(tempCurrentSize, totalSize, unit);
                }, (DownloadUnit _unit) => {
                    if (errorCallback != null) errorCallback(_unit);
                });
                currentSize += currentFileSize;

                Debug.Log("finishe one: i = " + i);
            }
        }


        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="downUnit"></param>
        /// <param name="callback"></param>
        static void download(DownloadUnit downUnit, System.Action<long, long> callback, System.Action<DownloadUnit> errorCallback = null)
        {
            //打开上次下载的文件
            long startPos = 0;
            string tempFile = downUnit.savePath + ".temp";
            FileStream fs = null;
            //如果有该文件则读取文件字节长度 如果不完整，那么从当前长度开始下载
            if (File.Exists(tempFile))
            {
                fs = File.OpenWrite(tempFile);
                startPos = fs.Length;
                fs.Seek(startPos, SeekOrigin.Current); //移动文件流中的当前指针

            }
            else
            {
                //没有就创建
                string direName = Path.GetDirectoryName(tempFile);
                if (!Directory.Exists(direName)) Directory.CreateDirectory(direName);
                fs = new FileStream(tempFile, FileMode.Create);
            }

            // 下载逻辑
            HttpWebRequest request = null;
            WebResponse respone = null;
            Stream ns = null;
            try
            {
                request = WebRequest.Create(downUnit.downUrl) as HttpWebRequest;
                request.ReadWriteTimeout = ReadWriteTimeOut;
                request.Timeout = TimeOutWait;
                if (startPos > 0) request.AddRange((int)startPos);  //设置Range值，断点续传
                                                                    //向服务器请求，获得服务器回应数据流
                respone = request.GetResponse();
                ns = respone.GetResponseStream();
                long totalSize = respone.ContentLength;
                long curSize = startPos;
                if (curSize == totalSize)
                {
                    fs.Flush();
                    fs.Close();
                    fs = null;
                    if (File.Exists(downUnit.savePath)) File.Delete(downUnit.savePath);
                    File.Move(tempFile, downUnit.savePath);
                    if (callback != null) callback(curSize, totalSize);
                }
                else
                {
                    byte[] bytes = new byte[oneReadLen];
                    int readSize = ns.Read(bytes, 0, oneReadLen); // 读取第一份数据
                    while (readSize > 0)
                    {
                        fs.Write(bytes, 0, readSize);       // 将下载到的数据写入临时文件
                        curSize += readSize;

                        // 判断是否下载完成
                        // 下载完成将temp文件，改成正式文件
                        if (curSize == totalSize)
                        {
                            fs.Flush();
                            fs.Close();
                            fs = null;
                            if (File.Exists(downUnit.savePath)) File.Delete(downUnit.savePath);
                            File.Move(tempFile, downUnit.savePath);
                        }

                        // 回调一下
                        if (callback != null) callback(curSize, totalSize);
                        // 往下继续读取
                        readSize = ns.Read(bytes, 0, oneReadLen);
                    }
                }
            }
            catch (WebException ex)
            {
                if (errorCallback != null)
                {
                    errorCallback(downUnit);
                    Debug.Log("下载出错：" + ex.Message);
                }
            }
            finally
            {
                if (fs != null)
                {
                    fs.Flush();
                    fs.Close();
                    fs = null;
                }
                if (ns != null) ns.Close();
                if (respone != null) respone.Close();
                if (request != null) request.Abort();
            }
        }


        /// <summary>
        /// 获取计算网络文件的大小
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static long GetWebFileSize(string url)
        {
            HttpWebRequest request = null;
            WebResponse respone = null;
            long length = 0;
            try
            {
                request = WebRequest.Create(url) as HttpWebRequest;
                request.Timeout = TimeOutWait;
                request.ReadWriteTimeout = ReadWriteTimeOut;
                //向服务器请求，获得服务器回应数据流
                respone = request.GetResponse();
                length = respone.ContentLength;
            }
            catch (WebException e)
            {
                throw e;
            }
            finally
            {
                if (respone != null) respone.Close();
                if (request != null) request.Abort();
            }
            return length;
        }
    }
}
