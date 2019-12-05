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
    public class xcAudioManagerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.AudioManager), L, translator, 0, 24, 0, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Reset", _m_Reset);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "InitMixer", _m_InitMixer);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetAudioMixerGroup", _m_GetAudioMixerGroup);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "BindAudio", _m_BindAudio);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "StopBattleSFX", _m_StopBattleSFX);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GCTimerUpdate", _m_GCTimerUpdate);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "DestroySFX", _m_DestroySFX);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PlayBattleSFX", _m_PlayBattleSFX);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "LoadSFXAudio", _m_LoadSFXAudio);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PlayAudio", _m_PlayAudio);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "StopAuidoClip", _m_StopAuidoClip);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "StopLoopAudio", _m_StopLoopAudio);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetClip", _m_SetClip);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PauseMusic", _m_PauseMusic);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "KillMusic", _m_KillMusic);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetMusicVolume", _m_SetMusicVolume);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "TransferMusic", _m_TransferMusic);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "TransferOut", _m_TransferOut);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PauseSFX", _m_PauseSFX);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetSFXVolume", _m_SetSFXVolume);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnSelectUI", _m_OnSelectUI);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PlayAudio_dynamic_out", _m_PlayAudio_dynamic_out);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "StopAudio_dynamic", _m_StopAudio_dynamic);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CheckSFXValid", _m_CheckSFXValid);
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.AudioManager), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.AudioManager), L, __CreateInstance, 2, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetSFXSoundType", _m_GetSFXSoundType_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.AudioManager));
			
			
			XUtils.EndClassRegister(typeof(xc.AudioManager), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.AudioManager __cl_gen_ret = new xc.AudioManager();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.AudioManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Reset(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AudioManager __cl_gen_to_be_invoked = (xc.AudioManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Reset(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InitMixer(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AudioManager __cl_gen_to_be_invoked = (xc.AudioManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.Audio.AudioMixer mixer = (UnityEngine.Audio.AudioMixer)translator.GetObject(L, 2, typeof(UnityEngine.Audio.AudioMixer));
                    
                    __cl_gen_to_be_invoked.InitMixer( mixer );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAudioMixerGroup(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AudioManager __cl_gen_to_be_invoked = (xc.AudioManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    
                        UnityEngine.Audio.AudioMixerGroup __cl_gen_ret = __cl_gen_to_be_invoked.GetAudioMixerGroup( name );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BindAudio(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AudioManager __cl_gen_to_be_invoked = (xc.AudioManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.GameObject bind_node = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
                    string res_path = LuaAPI.lua_tostring(L, 3);
                    bool is_loop = LuaAPI.lua_toboolean(L, 4);
                    
                    __cl_gen_to_be_invoked.BindAudio( bind_node, res_path, is_loop );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StopBattleSFX(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AudioManager __cl_gen_to_be_invoked = (xc.AudioManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.StopBattleSFX( id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GCTimerUpdate(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AudioManager __cl_gen_to_be_invoked = (xc.AudioManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    float remainTime = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    __cl_gen_to_be_invoked.GCTimerUpdate( remainTime );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DestroySFX(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AudioManager __cl_gen_to_be_invoked = (xc.AudioManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    float delayTime = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    __cl_gen_to_be_invoked.DestroySFX( id, delayTime );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.DestroySFX( id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.AudioManager.DestroySFX!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PlayBattleSFX(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AudioManager __cl_gen_to_be_invoked = (xc.AudioManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<xc.SoundType>(L, 3)) 
                {
                    string res_path = LuaAPI.lua_tostring(L, 2);
                    xc.SoundType type;translator.Get(L, 3, out type);
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.PlayBattleSFX( res_path, type );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& translator.Assignable<UnityEngine.AudioClip>(L, 2)&& translator.Assignable<xc.SoundType>(L, 3)) 
                {
                    UnityEngine.AudioClip clip = (UnityEngine.AudioClip)translator.GetObject(L, 2, typeof(UnityEngine.AudioClip));
                    xc.SoundType type;translator.Get(L, 3, out type);
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.PlayBattleSFX( clip, type );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.AudioManager.PlayBattleSFX!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadSFXAudio(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AudioManager __cl_gen_to_be_invoked = (xc.AudioManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 6&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<xc.SoundType>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<UnityEngine.Events.UnityAction<UnityEngine.AudioClip>>(L, 5)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 6)) 
                {
                    string res_path = LuaAPI.lua_tostring(L, 2);
                    xc.SoundType type;translator.Get(L, 3, out type);
                    uint id = LuaAPI.xlua_touint(L, 4);
                    UnityEngine.Events.UnityAction<UnityEngine.AudioClip> callback = translator.GetDelegate<UnityEngine.Events.UnityAction<UnityEngine.AudioClip>>(L, 5);
                    bool autoDestroy = LuaAPI.lua_toboolean(L, 6);
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.LoadSFXAudio( res_path, type, id, callback, autoDestroy );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 5&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<xc.SoundType>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<UnityEngine.Events.UnityAction<UnityEngine.AudioClip>>(L, 5)) 
                {
                    string res_path = LuaAPI.lua_tostring(L, 2);
                    xc.SoundType type;translator.Get(L, 3, out type);
                    uint id = LuaAPI.xlua_touint(L, 4);
                    UnityEngine.Events.UnityAction<UnityEngine.AudioClip> callback = translator.GetDelegate<UnityEngine.Events.UnityAction<UnityEngine.AudioClip>>(L, 5);
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.LoadSFXAudio( res_path, type, id, callback );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<xc.SoundType>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    string res_path = LuaAPI.lua_tostring(L, 2);
                    xc.SoundType type;translator.Get(L, 3, out type);
                    uint id = LuaAPI.xlua_touint(L, 4);
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.LoadSFXAudio( res_path, type, id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.AudioManager.LoadSFXAudio!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PlayAudio(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AudioManager __cl_gen_to_be_invoked = (xc.AudioManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& translator.Assignable<UnityEngine.AudioClip>(L, 2)&& translator.Assignable<UnityEngine.Events.UnityAction>(L, 3)) 
                {
                    UnityEngine.AudioClip clip = (UnityEngine.AudioClip)translator.GetObject(L, 2, typeof(UnityEngine.AudioClip));
                    UnityEngine.Events.UnityAction cbFunc = translator.GetDelegate<UnityEngine.Events.UnityAction>(L, 3);
                    
                    __cl_gen_to_be_invoked.PlayAudio( clip, cbFunc );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 4&& translator.Assignable<UnityEngine.AudioClip>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Events.UnityAction>(L, 4)) 
                {
                    UnityEngine.AudioClip clip = (UnityEngine.AudioClip)translator.GetObject(L, 2, typeof(UnityEngine.AudioClip));
                    bool is_loop = LuaAPI.lua_toboolean(L, 3);
                    UnityEngine.Events.UnityAction cbFunc = translator.GetDelegate<UnityEngine.Events.UnityAction>(L, 4);
                    
                    __cl_gen_to_be_invoked.PlayAudio( clip, is_loop, cbFunc );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& translator.Assignable<UnityEngine.AudioClip>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.AudioClip clip = (UnityEngine.AudioClip)translator.GetObject(L, 2, typeof(UnityEngine.AudioClip));
                    bool is_loop = LuaAPI.lua_toboolean(L, 3);
                    
                    __cl_gen_to_be_invoked.PlayAudio( clip, is_loop );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<UnityEngine.AudioClip>(L, 2)) 
                {
                    UnityEngine.AudioClip clip = (UnityEngine.AudioClip)translator.GetObject(L, 2, typeof(UnityEngine.AudioClip));
                    
                    __cl_gen_to_be_invoked.PlayAudio( clip );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.AudioManager.PlayAudio!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StopAuidoClip(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AudioManager __cl_gen_to_be_invoked = (xc.AudioManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.StopAuidoClip(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StopLoopAudio(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AudioManager __cl_gen_to_be_invoked = (xc.AudioManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string clip_name = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.StopLoopAudio( clip_name );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetClip(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AudioManager __cl_gen_to_be_invoked = (xc.AudioManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.AudioClip audio = (UnityEngine.AudioClip)translator.GetObject(L, 2, typeof(UnityEngine.AudioClip));
                    xc.BackGroundType type;translator.Get(L, 3, out type);
                    
                    __cl_gen_to_be_invoked.SetClip( audio, type );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PauseMusic(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AudioManager __cl_gen_to_be_invoked = (xc.AudioManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool pause = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.PauseMusic( pause );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_KillMusic(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AudioManager __cl_gen_to_be_invoked = (xc.AudioManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.KillMusic(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetMusicVolume(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AudioManager __cl_gen_to_be_invoked = (xc.AudioManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    float volume = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    __cl_gen_to_be_invoked.SetMusicVolume( volume );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TransferMusic(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AudioManager __cl_gen_to_be_invoked = (xc.AudioManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string resName = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.TransferMusic( resName );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TransferOut(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AudioManager __cl_gen_to_be_invoked = (xc.AudioManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.TransferOut(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PauseSFX(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AudioManager __cl_gen_to_be_invoked = (xc.AudioManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool pause = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.PauseSFX( pause );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetSFXVolume(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AudioManager __cl_gen_to_be_invoked = (xc.AudioManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    float volume = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    __cl_gen_to_be_invoked.SetSFXVolume( volume );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnSelectUI(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AudioManager __cl_gen_to_be_invoked = (xc.AudioManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.UI.Selectable select_ui = (UnityEngine.UI.Selectable)translator.GetObject(L, 2, typeof(UnityEngine.UI.Selectable));
                    string sprite_name = LuaAPI.lua_tostring(L, 3);
                    string check_sprite_name = LuaAPI.lua_tostring(L, 4);
                    
                    __cl_gen_to_be_invoked.OnSelectUI( select_ui, sprite_name, check_sprite_name );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PlayAudio_dynamic_out(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AudioManager __cl_gen_to_be_invoked = (xc.AudioManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<xc.AudioManager.DynamicAudioParam>(L, 2)) 
                {
                    xc.AudioManager.DynamicAudioParam param = (xc.AudioManager.DynamicAudioParam)translator.GetObject(L, 2, typeof(xc.AudioManager.DynamicAudioParam));
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.PlayAudio_dynamic_out( param );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    string sound_path = LuaAPI.lua_tostring(L, 2);
                    bool is_loop = LuaAPI.lua_toboolean(L, 3);
                    float volume = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.PlayAudio_dynamic_out( sound_path, is_loop, volume );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.AudioManager.PlayAudio_dynamic_out!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StopAudio_dynamic(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AudioManager __cl_gen_to_be_invoked = (xc.AudioManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint unique_id = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.StopAudio_dynamic( unique_id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckSFXValid(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AudioManager __cl_gen_to_be_invoked = (xc.AudioManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.CheckSFXValid( id );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSFXSoundType_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    Actor actor = (Actor)translator.GetObject(L, 1, typeof(Actor));
                    
                        xc.SoundType __cl_gen_ret = xc.AudioManager.GetSFXSoundType( actor );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
