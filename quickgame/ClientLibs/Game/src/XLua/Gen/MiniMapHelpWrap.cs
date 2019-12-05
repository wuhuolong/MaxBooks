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
    public class MiniMapHelpWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(MiniMapHelp), L, translator, 0, 0, 0, 0);
			
			
			
			
			
			XUtils.EndObjectRegister(typeof(MiniMapHelp), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(MiniMapHelp), L, __CreateInstance, 6, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetInstanceAllNormalMonster", _m_GetInstanceAllNormalMonster_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetInstanceAllNpc", _m_GetInstanceAllNpc_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsCanOpenMinimap", _m_IsCanOpenMinimap_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "isMapOpen", _m_isMapOpen_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetInstanceAllTrasnspot", _m_GetInstanceAllTrasnspot_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(MiniMapHelp));
			
			
			XUtils.EndClassRegister(typeof(MiniMapHelp), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					MiniMapHelp __cl_gen_ret = new MiniMapHelp();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to MiniMapHelp constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetInstanceAllNormalMonster_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint instance_id = LuaAPI.xlua_touint(L, 1);
                    
                        System.Collections.Generic.List<MiniMapPointInfo> __cl_gen_ret = MiniMapHelp.GetInstanceAllNormalMonster( instance_id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetInstanceAllNpc_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint instance_id = LuaAPI.xlua_touint(L, 1);
                    
                        System.Collections.Generic.List<MiniMapPointInfo> __cl_gen_ret = MiniMapHelp.GetInstanceAllNpc( instance_id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsCanOpenMinimap_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = MiniMapHelp.IsCanOpenMinimap(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_isMapOpen_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint mapid = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = MiniMapHelp.isMapOpen( mapid );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetInstanceAllTrasnspot_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint instance_id = LuaAPI.xlua_touint(L, 1);
                    
                        System.Collections.Generic.List<MiniMapPointInfo> __cl_gen_ret = MiniMapHelp.GetInstanceAllTrasnspot( instance_id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
