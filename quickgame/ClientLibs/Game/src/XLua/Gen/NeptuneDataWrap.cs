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
    public class NeptuneDataWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(Neptune.Data), L, translator, 0, 4, 4, 3);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Clear", _m_Clear);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetData", _m_GetData);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RegisterData", _m_RegisterData);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetDataAtIndex", _m_GetDataAtIndex);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AllDatas", _g_get_AllDatas);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BaseInfo", _g_get_BaseInfo);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mAllDatas", _g_get_mAllDatas);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PathManager", _g_get_PathManager);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "BaseInfo", _s_set_BaseInfo);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mAllDatas", _s_set_mAllDatas);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "PathManager", _s_set_PathManager);
            
			XUtils.EndObjectRegister(typeof(Neptune.Data), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(Neptune.Data), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(Neptune.Data));
			
			
			XUtils.EndClassRegister(typeof(Neptune.Data), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					Neptune.Data __cl_gen_ret = new Neptune.Data();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Neptune.Data constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clear(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Neptune.Data __cl_gen_to_be_invoked = (Neptune.Data)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Clear(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetData(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Neptune.Data __cl_gen_to_be_invoked = (Neptune.Data)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    System.Type node_type = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    
                        Neptune.Data.Container __cl_gen_ret = __cl_gen_to_be_invoked.GetData( node_type );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RegisterData(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Neptune.Data __cl_gen_to_be_invoked = (Neptune.Data)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    System.Type node_type = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    
                    __cl_gen_to_be_invoked.RegisterData( node_type );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDataAtIndex(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Neptune.Data __cl_gen_to_be_invoked = (Neptune.Data)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int index = LuaAPI.xlua_tointeger(L, 2);
                    
                        Neptune.Data.Container __cl_gen_ret = __cl_gen_to_be_invoked.GetDataAtIndex( index );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AllDatas(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Neptune.Data __cl_gen_to_be_invoked = (Neptune.Data)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.AllDatas);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BaseInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Neptune.Data __cl_gen_to_be_invoked = (Neptune.Data)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.BaseInfo);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mAllDatas(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Neptune.Data __cl_gen_to_be_invoked = (Neptune.Data)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mAllDatas);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PathManager(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Neptune.Data __cl_gen_to_be_invoked = (Neptune.Data)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.PathManager);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BaseInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Neptune.Data __cl_gen_to_be_invoked = (Neptune.Data)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.BaseInfo = (Neptune.BaseInfo)translator.GetObject(L, 2, typeof(Neptune.BaseInfo));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mAllDatas(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Neptune.Data __cl_gen_to_be_invoked = (Neptune.Data)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mAllDatas = (System.Collections.Generic.List<Neptune.Data.Container>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<Neptune.Data.Container>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PathManager(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Neptune.Data __cl_gen_to_be_invoked = (Neptune.Data)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.PathManager = (Neptune.Path.PathManager)translator.GetObject(L, 2, typeof(Neptune.Path.PathManager));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
