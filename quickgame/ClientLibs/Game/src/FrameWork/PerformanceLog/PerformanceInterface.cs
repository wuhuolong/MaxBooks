//#define PERFORMANCE_TEST

using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;

// NOTICE: Application must have write access to external storage
public class PerformanceInterface : MonoBehaviour {
#if (UNITY_ANDROID && PERFORMANCE_TEST)
    
    const string FILE_NAME_PREFIX = "UnityInfo";
    const int CLOSE_AFTER_XSECOND = 60;
    const int SAVE_TAG_LIST_WHEN_REACH = 2;
    const int STOP_WHEN_DISK_REMAIN = 200; // megabytes
    // only exist in unity 5.
    //const string BUNDLE_ID = Application.bundleIdentifier;
    const string BUNDLE_ID = "com.dbgame.darkx.trunk.qa";
        
    AndroidJavaClass jc;
    int saveCount = -1; // -1 for first time flag.
    Boolean isInit = false;
    DateTime profilerStartTime;
    
    public struct sceneTag {
        public float totalFps;
        public int count;
        
        public sceneTag(float fps) {
            totalFps = fps;
            count = 1;
        }
        
        // copy constructor
        private sceneTag(sceneTag tag) {
            totalFps = tag.totalFps;
            count = tag.count;
        }
        
        public static sceneTag updateTag(sceneTag tag, float fps) {
            sceneTag res = new sceneTag(tag);
            res.count++;
            res.totalFps = tag.totalFps + fps;
            return res;
        }
        
        public float getAvgFps() {
            if (count > 0 ) {
                return totalFps / count;
            } 
            else {
                return 0;
            }
        }
    }
    Dictionary<String, sceneTag> tagList = new Dictionary<String, sceneTag>();
    
    void Start () {
        jc = new AndroidJavaClass(BUNDLE_ID + ".PluginBroadcastReceiver");
        AndroidJavaObject activityContext = jc.GetStatic<AndroidJavaObject>("currentActivity");
        jc.CallStatic("createInstance");
        jc.Call("setContext", activityContext);
    }
    
    void Update () {
    }
    
    // DO NOT start the profiler manually in unity!
    // cause if so we need to sync the runnning state of the profiler in test tool!
    void startProfiler(String inFps) {
        if (!isInit) {
            InvokeRepeating("preventLongLogging", 60, 60);
            isInit = true;            
        }
        updateTagList(inFps);
        // For unify time across different file
        DateTime tempTime = DateTime.Now;
        if (Profiler.enabled == true) {
            // the profiler is currently running but new sampling request receive
            Debug.Log("FpsMonitor: New request receive when profiler already started");
        }
        else if (checkAvailableDisk())
        {
            Debug.Log("FpsMonitor: Running into script");
            profilerStartTime = tempTime;
            String currentTime = tempTime.ToString("yyyy-dd-M--HH-mm-ss");
            Application.CaptureScreenshot(getLogFileName(currentTime) + ".png");
            Profiler.logFile = Path.Combine(Const.persistentDataPath , 
                                            getLogFileName(currentTime)) + ".log";
            Profiler.enableBinaryLog = true;
            Profiler.enabled = true;
        }
    }

	public void getPlayerNum()
	{
		jc.Call("sendPlayerNum", GetActorCountInScreen());
	}
	
    public uint GetActorCountInScreen()
    {
        return xc.CullManager.Instance.ActorCount();
    }
    
    void stopProfiler() {
        Profiler.enabled = false;
    }
    
    string getLogFileName(String currentTime) {
        // prefix_appname_scenetag_time.log
        string fileName = FILE_NAME_PREFIX + "_" + 
            BUNDLE_ID + "_" +
            getSceneTagName() + "_" +
            currentTime;
        return fileName;
    }
    
    string getSceneTagName() {
        return SceneHelp.loadedLevelName;
    }
    
    void updateTagList(String inFps) {
        float fps;
        if (!float.TryParse(inFps, out fps)) {
            Debug.Log("FpsMonitor: receive error fps arg from java");
            fps = 0;
        }
        
        if (tagList.ContainsKey(getSceneTagName())) {
            sceneTag tag = sceneTag.updateTag(tagList[getSceneTagName()], fps);
            tagList[getSceneTagName()] = tag;
        } else {
            tagList.Add(getSceneTagName(), new sceneTag(fps));
        }
        
        saveSceneTagList();
    }
    
    void saveSceneTagList() {
        
        //save first time
        if(saveCount == -1) {
            save2Disk();
        }
        
        saveCount++;
        if (saveCount == SAVE_TAG_LIST_WHEN_REACH) {
            save2Disk();
            saveCount = 0;
        }
    }
    
    void save2Disk() {
        List<String> fileText = new List<String>();
        foreach (KeyValuePair<String, sceneTag> kv in tagList)
        {
            String line = kv.Key.ToString() + "|" +
                kv.Value.count.ToString() + "|" +
                    kv.Value.getAvgFps().ToString() + "\r\n";
            fileText.Add(line);
        }
        if (fileText.Count > 0)
        {
            // prefix_bundleID_phone_date.txt
            String fileName = jc.CallStatic<String>("getSDCardPath") + 
                FILE_NAME_PREFIX + "_" +
                BUNDLE_ID +
                SystemInfo.deviceModel + 
                ".txt";
            File.WriteAllLines(fileName, fileText.ToArray());                   
        }
    }
    
    // incase of the test tool die after it enable the profiler. close it manually
    // this may be buggy, cause we doesn't notify the test tool when profiler has been close
    // most safe way is to make a content provider for the test tool to query.
    // currently is ok for close.
    void preventLongLogging() {
        if (Profiler.enabled == true) {
            TimeSpan elapsed = DateTime.Now - profilerStartTime;
            
            if (elapsed.TotalSeconds >= CLOSE_AFTER_XSECOND)
            {
                Debug.Log("FpsMonitor: Record exceed 1 min force stop. date=" + profilerStartTime.ToString());
                stopProfiler();
            } 
            // user change cell phone time
            else if (elapsed.TotalSeconds < 0)
            {
                stopProfiler();
            }
        }
    }
    
    void OnApplicationQuit() {
        CancelInvoke();
        stopProfiler();
        save2Disk();
    }
    
    Boolean checkAvailableDisk() {
        Int32 freeSpace = jc.CallStatic<Int32>("freeSpace", true);
        if (freeSpace < STOP_WHEN_DISK_REMAIN) {
            Debug.Log("FpsMonitor: Disk almost full,Force stop logging!");
            return false;
        }
        return true;
    }    
#endif
}
