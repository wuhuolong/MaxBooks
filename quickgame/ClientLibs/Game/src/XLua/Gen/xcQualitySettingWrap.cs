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
    public class xcQualitySettingWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.QualitySetting), L, translator, 0, 1, 1, 1);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetDirty", _m_SetDirty);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "OnGLChanged", _g_get_OnGLChanged);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "OnGLChanged", _s_set_OnGLChanged);
            
			XUtils.EndObjectRegister(typeof(xc.QualitySetting), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.QualitySetting), L, __CreateInstance, 8, 10, 8);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetMaxPlayerProcessCount", _m_GetMaxPlayerProcessCount_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "DeviceAdaptation", _m_DeviceAdaptation_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetAdviceGraphicLevel", _m_GetAdviceGraphicLevel_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "SetSceneGL", _m_SetSceneGL_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CheckAvatarCapacity", _m_CheckAvatarCapacity_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "SkipTimeline", _m_SkipTimeline_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsVeryLowIPhone", _m_IsVeryLowIPhone_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.QualitySetting));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "AdviceMaxPlayerCount", _g_get_AdviceMaxPlayerCount);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "HighMaxPlayerCount", _g_get_HighMaxPlayerCount);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "MaxPlayerCount", _g_get_MaxPlayerCount);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "GraphicLevel", _g_get_GraphicLevel);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "MaxPlayerLow", _g_get_MaxPlayerLow);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "MaxPlayerMid", _g_get_MaxPlayerMid);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "MaxPlayerHigh", _g_get_MaxPlayerHigh);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "MaxPlayerProcessLow", _g_get_MaxPlayerProcessLow);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "MaxPlayerProcessMid", _g_get_MaxPlayerProcessMid);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "MaxPlayerProcessHigh", _g_get_MaxPlayerProcessHigh);
            
			XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "MaxPlayerCount", _s_set_MaxPlayerCount);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "GraphicLevel", _s_set_GraphicLevel);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "MaxPlayerLow", _s_set_MaxPlayerLow);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "MaxPlayerMid", _s_set_MaxPlayerMid);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "MaxPlayerHigh", _s_set_MaxPlayerHigh);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "MaxPlayerProcessLow", _s_set_MaxPlayerProcessLow);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "MaxPlayerProcessMid", _s_set_MaxPlayerProcessMid);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "MaxPlayerProcessHigh", _s_set_MaxPlayerProcessHigh);
            
			XUtils.EndClassRegister(typeof(xc.QualitySetting), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.QualitySetting __cl_gen_ret = new xc.QualitySetting();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.QualitySetting constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMaxPlayerProcessCount_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                        uint __cl_gen_ret = xc.QualitySetting.GetMaxPlayerProcessCount(  );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DeviceAdaptation_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    xc.QualitySetting.DeviceAdaptation(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAdviceGraphicLevel_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                        int __cl_gen_ret = xc.QualitySetting.GetAdviceGraphicLevel(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetSceneGL_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.EGraphLevel level;translator.Get(L, 1, out level);
                    
                    xc.QualitySetting.SetSceneGL( level );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetDirty(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.QualitySetting __cl_gen_to_be_invoked = (xc.QualitySetting)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.SetDirty(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckAvatarCapacity_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    Actor actor = (Actor)translator.GetObject(L, 1, typeof(Actor));
                    xc.DBAvatarPart.BODY_PART body_part;translator.Get(L, 2, out body_part);
                    uint equip_id = LuaAPI.xlua_touint(L, 3);
                    
                        uint __cl_gen_ret = xc.QualitySetting.CheckAvatarCapacity( actor, body_part, equip_id );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SkipTimeline_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint minMemory = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.QualitySetting.SkipTimeline( minMemory );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsVeryLowIPhone_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = xc.QualitySetting.IsVeryLowIPhone(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AdviceMaxPlayerCount(RealStatePtr L)
        {
            
            try {
			    LuaAPI.xlua_pushuint(L, xc.QualitySetting.AdviceMaxPlayerCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HighMaxPlayerCount(RealStatePtr L)
        {
            
            try {
			    LuaAPI.xlua_pushuint(L, xc.QualitySetting.HighMaxPlayerCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaxPlayerCount(RealStatePtr L)
        {
            
            try {
			    LuaAPI.xlua_pushuint(L, xc.QualitySetting.MaxPlayerCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GraphicLevel(RealStatePtr L)
        {
            
            try {
			    LuaAPI.xlua_pushinteger(L, xc.QualitySetting.GraphicLevel);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OnGLChanged(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.QualitySetting __cl_gen_to_be_invoked = (xc.QualitySetting)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.OnGLChanged);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaxPlayerLow(RealStatePtr L)
        {
            
            try {
			    LuaAPI.xlua_pushuint(L, xc.QualitySetting.MaxPlayerLow);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaxPlayerMid(RealStatePtr L)
        {
            
            try {
			    LuaAPI.xlua_pushuint(L, xc.QualitySetting.MaxPlayerMid);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaxPlayerHigh(RealStatePtr L)
        {
            
            try {
			    LuaAPI.xlua_pushuint(L, xc.QualitySetting.MaxPlayerHigh);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaxPlayerProcessLow(RealStatePtr L)
        {
            
            try {
			    LuaAPI.xlua_pushuint(L, xc.QualitySetting.MaxPlayerProcessLow);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaxPlayerProcessMid(RealStatePtr L)
        {
            
            try {
			    LuaAPI.xlua_pushuint(L, xc.QualitySetting.MaxPlayerProcessMid);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaxPlayerProcessHigh(RealStatePtr L)
        {
            
            try {
			    LuaAPI.xlua_pushuint(L, xc.QualitySetting.MaxPlayerProcessHigh);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MaxPlayerCount(RealStatePtr L)
        {
            
            try {
			    xc.QualitySetting.MaxPlayerCount = LuaAPI.xlua_touint(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_GraphicLevel(RealStatePtr L)
        {
            
            try {
			    xc.QualitySetting.GraphicLevel = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OnGLChanged(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.QualitySetting __cl_gen_to_be_invoked = (xc.QualitySetting)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.OnGLChanged = translator.GetDelegate<xc.QualitySetting.OnGraphicLevelChange>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MaxPlayerLow(RealStatePtr L)
        {
            
            try {
			    xc.QualitySetting.MaxPlayerLow = LuaAPI.xlua_touint(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MaxPlayerMid(RealStatePtr L)
        {
            
            try {
			    xc.QualitySetting.MaxPlayerMid = LuaAPI.xlua_touint(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MaxPlayerHigh(RealStatePtr L)
        {
            
            try {
			    xc.QualitySetting.MaxPlayerHigh = LuaAPI.xlua_touint(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MaxPlayerProcessLow(RealStatePtr L)
        {
            
            try {
			    xc.QualitySetting.MaxPlayerProcessLow = LuaAPI.xlua_touint(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MaxPlayerProcessMid(RealStatePtr L)
        {
            
            try {
			    xc.QualitySetting.MaxPlayerProcessMid = LuaAPI.xlua_touint(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MaxPlayerProcessHigh(RealStatePtr L)
        {
            
            try {
			    xc.QualitySetting.MaxPlayerProcessHigh = LuaAPI.xlua_touint(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
