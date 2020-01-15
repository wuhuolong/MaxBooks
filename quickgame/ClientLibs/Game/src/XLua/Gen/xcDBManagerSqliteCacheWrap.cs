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
    public class xcDBManagerSqliteCacheWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBManager.SqliteCache), L, translator, 0, 3, 1, 1);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetRetListDic", _m_GetRetListDic);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnFreeToPool", _m_OnFreeToPool);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnGetFromPool", _m_OnGetFromPool);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Data", _g_get_Data);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Data", _s_set_Data);
            
			XUtils.EndObjectRegister(typeof(xc.DBManager.SqliteCache), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBManager.SqliteCache), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBManager.SqliteCache));
			
			
			XUtils.EndClassRegister(typeof(xc.DBManager.SqliteCache), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DBManager.SqliteCache __cl_gen_ret = new xc.DBManager.SqliteCache();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBManager.SqliteCache constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetRetListDic(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBManager.SqliteCache __cl_gen_to_be_invoked = (xc.DBManager.SqliteCache)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>> __cl_gen_ret = __cl_gen_to_be_invoked.GetRetListDic(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnFreeToPool(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBManager.SqliteCache __cl_gen_to_be_invoked = (xc.DBManager.SqliteCache)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.OnFreeToPool(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnGetFromPool(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBManager.SqliteCache __cl_gen_to_be_invoked = (xc.DBManager.SqliteCache)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.OnGetFromPool(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Data(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBManager.SqliteCache __cl_gen_to_be_invoked = (xc.DBManager.SqliteCache)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Data);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Data(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBManager.SqliteCache __cl_gen_to_be_invoked = (xc.DBManager.SqliteCache)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Data = (System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
