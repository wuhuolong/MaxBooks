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
    public class xcDungeonLevelManagerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.Dungeon.LevelManager), L, translator, 0, 4, 2, 2);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetAreaOpen", _m_SetAreaOpen);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetAreaClose", _m_SetAreaClose);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "LoadLevelFile", _m_LoadLevelFile);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "LoadLevelFileTemporary", _m_LoadLevelFileTemporary);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AreaExclude", _g_get_AreaExclude);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsLoadingNavmeshFile", _g_get_IsLoadingNavmeshFile);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "AreaExclude", _s_set_AreaExclude);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsLoadingNavmeshFile", _s_set_IsLoadingNavmeshFile);
            
			XUtils.EndObjectRegister(typeof(xc.Dungeon.LevelManager), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.Dungeon.LevelManager), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.Dungeon.LevelManager));
			
			
			XUtils.EndClassRegister(typeof(xc.Dungeon.LevelManager), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.Dungeon.LevelManager __cl_gen_ret = new xc.Dungeon.LevelManager();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Dungeon.LevelManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAreaOpen(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.LevelManager __cl_gen_to_be_invoked = (xc.Dungeon.LevelManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int flag = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.SetAreaOpen( flag );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAreaClose(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.LevelManager __cl_gen_to_be_invoked = (xc.Dungeon.LevelManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int flag = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.SetAreaClose( flag );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadLevelFile(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.LevelManager __cl_gen_to_be_invoked = (xc.Dungeon.LevelManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint stage_id = LuaAPI.xlua_touint(L, 2);
                    bool async = LuaAPI.lua_toboolean(L, 3);
                    
                    __cl_gen_to_be_invoked.LoadLevelFile( stage_id, async );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadLevelFileTemporary(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.LevelManager __cl_gen_to_be_invoked = (xc.Dungeon.LevelManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    
                        Neptune.Data __cl_gen_ret = __cl_gen_to_be_invoked.LoadLevelFileTemporary( id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AreaExclude(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Dungeon.LevelManager __cl_gen_to_be_invoked = (xc.Dungeon.LevelManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.AreaExclude);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsLoadingNavmeshFile(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Dungeon.LevelManager __cl_gen_to_be_invoked = (xc.Dungeon.LevelManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsLoadingNavmeshFile);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AreaExclude(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Dungeon.LevelManager __cl_gen_to_be_invoked = (xc.Dungeon.LevelManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.AreaExclude = (ushort)LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsLoadingNavmeshFile(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Dungeon.LevelManager __cl_gen_to_be_invoked = (xc.Dungeon.LevelManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsLoadingNavmeshFile = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
