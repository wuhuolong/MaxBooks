#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using XUtils = XLua.XUtils;
    public class xcVoiceManagerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.VoiceManager), L, translator, 0, 20, 6, 4);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Init", _m_Init);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GenFileNameByFileId", _m_GenFileNameByFileId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GenFilePathByFileId", _m_GenFilePathByFileId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ReqAuthKey", _m_ReqAuthKey);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Update", _m_Update);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "isGCloudVoiceReady", _m_isGCloudVoiceReady);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "StartRecord", _m_StartRecord);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "StopRecord", _m_StopRecord);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UploadFile", _m_UploadFile);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "DownloadFile", _m_DownloadFile);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PlayReocrdFile", _m_PlayReocrdFile);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PlayOrDownload", _m_PlayOrDownload);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnlyPlayRecordFile", _m_OnlyPlayRecordFile);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "StopPlayRecordFile", _m_StopPlayRecordFile);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "StopAllPlayingRecordFiles", _m_StopAllPlayingRecordFiles);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SpeechToText", _m_SpeechToText);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetRecFileSecond", _m_GetRecFileSecond);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetRecFileSize", _m_GetRecFileSize);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsPlaying", _m_IsPlaying);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetQueueHeadFileId", _m_GetQueueHeadFileId);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsUnloading", _g_get_IsUnloading);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsUploadingOverTime", _g_get_IsUploadingOverTime);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsCanSendByGameLogic", _g_get_IsCanSendByGameLogic);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "VoiceEngine", _g_get_VoiceEngine);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mIsGCloudVoiceAuthKey", _g_get_mIsGCloudVoiceAuthKey);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "FilePathToFileId", _g_get_FilePathToFileId);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsUnloading", _s_set_IsUnloading);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsCanSendByGameLogic", _s_set_IsCanSendByGameLogic);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mIsGCloudVoiceAuthKey", _s_set_mIsGCloudVoiceAuthKey);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "FilePathToFileId", _s_set_FilePathToFileId);
            
			XUtils.EndObjectRegister(typeof(xc.VoiceManager), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.VoiceManager), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.VoiceManager));
			
			
			XUtils.EndClassRegister(typeof(xc.VoiceManager), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.VoiceManager __cl_gen_ret = new xc.VoiceManager();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.VoiceManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Init(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.VoiceManager __cl_gen_to_be_invoked = (xc.VoiceManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Init(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GenFileNameByFileId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.VoiceManager __cl_gen_to_be_invoked = (xc.VoiceManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string file_id = LuaAPI.lua_tostring(L, 2);
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.GenFileNameByFileId( file_id );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GenFilePathByFileId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.VoiceManager __cl_gen_to_be_invoked = (xc.VoiceManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string file_id = LuaAPI.lua_tostring(L, 2);
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.GenFilePathByFileId( file_id );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReqAuthKey(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.VoiceManager __cl_gen_to_be_invoked = (xc.VoiceManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ReqAuthKey(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Update(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.VoiceManager __cl_gen_to_be_invoked = (xc.VoiceManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Update(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_isGCloudVoiceReady(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.VoiceManager __cl_gen_to_be_invoked = (xc.VoiceManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.isGCloudVoiceReady(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StartRecord(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.VoiceManager __cl_gen_to_be_invoked = (xc.VoiceManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.StartRecord(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StopRecord(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.VoiceManager __cl_gen_to_be_invoked = (xc.VoiceManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.StopRecord(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UploadFile(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.VoiceManager __cl_gen_to_be_invoked = (xc.VoiceManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.UploadFile(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DownloadFile(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.VoiceManager __cl_gen_to_be_invoked = (xc.VoiceManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string file_id = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.DownloadFile( file_id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PlayReocrdFile(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.VoiceManager __cl_gen_to_be_invoked = (xc.VoiceManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string file_id = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.PlayReocrdFile( file_id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PlayOrDownload(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.VoiceManager __cl_gen_to_be_invoked = (xc.VoiceManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string file_id = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.PlayOrDownload( file_id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnlyPlayRecordFile(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.VoiceManager __cl_gen_to_be_invoked = (xc.VoiceManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string file_id = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.OnlyPlayRecordFile( file_id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StopPlayRecordFile(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.VoiceManager __cl_gen_to_be_invoked = (xc.VoiceManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.StopPlayRecordFile(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StopAllPlayingRecordFiles(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.VoiceManager __cl_gen_to_be_invoked = (xc.VoiceManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.StopAllPlayingRecordFiles(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SpeechToText(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.VoiceManager __cl_gen_to_be_invoked = (xc.VoiceManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string fileid = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.SpeechToText( fileid );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetRecFileSecond(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.VoiceManager __cl_gen_to_be_invoked = (xc.VoiceManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string fileid = LuaAPI.lua_tostring(L, 2);
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetRecFileSecond( fileid );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetRecFileSize(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.VoiceManager __cl_gen_to_be_invoked = (xc.VoiceManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string path = LuaAPI.lua_tostring(L, 2);
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetRecFileSize( path );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsPlaying(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.VoiceManager __cl_gen_to_be_invoked = (xc.VoiceManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsPlaying(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetQueueHeadFileId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.VoiceManager __cl_gen_to_be_invoked = (xc.VoiceManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.GetQueueHeadFileId(  );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsUnloading(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.VoiceManager __cl_gen_to_be_invoked = (xc.VoiceManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsUnloading);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsUploadingOverTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.VoiceManager __cl_gen_to_be_invoked = (xc.VoiceManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsUploadingOverTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsCanSendByGameLogic(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.VoiceManager __cl_gen_to_be_invoked = (xc.VoiceManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsCanSendByGameLogic);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_VoiceEngine(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.VoiceManager __cl_gen_to_be_invoked = (xc.VoiceManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.VoiceEngine);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mIsGCloudVoiceAuthKey(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.VoiceManager __cl_gen_to_be_invoked = (xc.VoiceManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.mIsGCloudVoiceAuthKey);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FilePathToFileId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.VoiceManager __cl_gen_to_be_invoked = (xc.VoiceManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.FilePathToFileId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsUnloading(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.VoiceManager __cl_gen_to_be_invoked = (xc.VoiceManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsUnloading = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsCanSendByGameLogic(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.VoiceManager __cl_gen_to_be_invoked = (xc.VoiceManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsCanSendByGameLogic = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mIsGCloudVoiceAuthKey(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.VoiceManager __cl_gen_to_be_invoked = (xc.VoiceManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mIsGCloudVoiceAuthKey = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FilePathToFileId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.VoiceManager __cl_gen_to_be_invoked = (xc.VoiceManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.FilePathToFileId = (System.Collections.Generic.Dictionary<string, string>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<string, string>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
