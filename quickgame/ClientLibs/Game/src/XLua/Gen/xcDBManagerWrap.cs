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
    public class xcDBManagerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBManager), L, translator, 0, 12, 4, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetDB", _m_GetDB);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RegisterDB", _m_RegisterDB);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Load", _m_Load);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Unload", _m_Unload);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "LoadDBFile", _m_LoadDBFile);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "LoadAllDBAsset", _m_LoadAllDBAsset);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetColumnInfo", _m_GetColumnInfo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetColumnInfo", _m_SetColumnInfo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetSqliteCache", _m_GetSqliteCache);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "QuerySqliteRow", _m_QuerySqliteRow);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CloseAllSqliteDB", _m_CloseAllSqliteDB);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ClearCache", _m_ClearCache);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DBBundle", _g_get_DBBundle);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LatestVbn", _g_get_LatestVbn);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CurProcess", _g_get_CurProcess);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsLoadAllFinished", _g_get_IsLoadAllFinished);
            
			
			XUtils.EndObjectRegister(typeof(xc.DBManager), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBManager), L, __CreateInstance, 2, 1, 1);
			
			
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CharIndexTable", xc.DBManager.CharIndexTable);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBManager));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "AssetsResPath", _g_get_AssetsResPath);
            
			XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "AssetsResPath", _s_set_AssetsResPath);
            
			XUtils.EndClassRegister(typeof(xc.DBManager), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DBManager __cl_gen_ret = new xc.DBManager();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDB(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBManager __cl_gen_to_be_invoked = (xc.DBManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    
                        xc.DBManager.DBBase __cl_gen_ret = __cl_gen_to_be_invoked.GetDB( name );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RegisterDB(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBManager __cl_gen_to_be_invoked = (xc.DBManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.DBManager.DBBase db = (xc.DBManager.DBBase)translator.GetObject(L, 2, typeof(xc.DBManager.DBBase));
                    
                    __cl_gen_to_be_invoked.RegisterDB( db );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Load(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBManager __cl_gen_to_be_invoked = (xc.DBManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.Load(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Unload(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBManager __cl_gen_to_be_invoked = (xc.DBManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Unload(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadDBFile(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBManager __cl_gen_to_be_invoked = (xc.DBManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string fileName = LuaAPI.lua_tostring(L, 2);
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.LoadDBFile( fileName );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadAllDBAsset(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBManager __cl_gen_to_be_invoked = (xc.DBManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.LoadAllDBAsset(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetColumnInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBManager __cl_gen_to_be_invoked = (xc.DBManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string table_name = LuaAPI.lua_tostring(L, 2);
                    
                        System.Collections.Generic.List<xc.DBManager.ColumnInfo> __cl_gen_ret = __cl_gen_to_be_invoked.GetColumnInfo( table_name );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetColumnInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBManager __cl_gen_to_be_invoked = (xc.DBManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string table_name = LuaAPI.lua_tostring(L, 2);
                    System.Collections.Generic.List<xc.DBManager.ColumnInfo> info = (System.Collections.Generic.List<xc.DBManager.ColumnInfo>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<xc.DBManager.ColumnInfo>));
                    
                    __cl_gen_to_be_invoked.SetColumnInfo( table_name, info );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSqliteCache(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBManager __cl_gen_to_be_invoked = (xc.DBManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string fileName = LuaAPI.lua_tostring(L, 2);
                    string table_name = LuaAPI.lua_tostring(L, 3);
                    string queryStr = LuaAPI.lua_tostring(L, 4);
                    
                        xc.DBManager.SqliteCache __cl_gen_ret = __cl_gen_to_be_invoked.GetSqliteCache( fileName, table_name, queryStr );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_QuerySqliteRow(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBManager __cl_gen_to_be_invoked = (xc.DBManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string fileName = LuaAPI.lua_tostring(L, 2);
                    string table_name = LuaAPI.lua_tostring(L, 3);
                    string queryStr = LuaAPI.lua_tostring(L, 4);
                    
                        System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>> __cl_gen_ret = __cl_gen_to_be_invoked.QuerySqliteRow( fileName, table_name, queryStr );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CloseAllSqliteDB(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBManager __cl_gen_to_be_invoked = (xc.DBManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.CloseAllSqliteDB(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearCache(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBManager __cl_gen_to_be_invoked = (xc.DBManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ClearCache(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DBBundle(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBManager __cl_gen_to_be_invoked = (xc.DBManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.DBBundle);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LatestVbn(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBManager __cl_gen_to_be_invoked = (xc.DBManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.LatestVbn);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CurProcess(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBManager __cl_gen_to_be_invoked = (xc.DBManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.CurProcess);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsLoadAllFinished(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBManager __cl_gen_to_be_invoked = (xc.DBManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsLoadAllFinished);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AssetsResPath(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, xc.DBManager.AssetsResPath);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AssetsResPath(RealStatePtr L)
        {
            
            try {
			    xc.DBManager.AssetsResPath = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
