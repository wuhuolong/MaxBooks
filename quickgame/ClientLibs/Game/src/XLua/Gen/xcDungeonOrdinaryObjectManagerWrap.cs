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
    public class xcDungeonOrdinaryObjectManagerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.Dungeon.OrdinaryObjectManager), L, translator, 0, 5, 1, 1);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CreateAllOrdinaryObjects", _m_CreateAllOrdinaryObjects);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CreateOrdinaryObject", _m_CreateOrdinaryObject);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetOrdinaryObject", _m_GetOrdinaryObject);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RemoveOrdinaryObject", _m_RemoveOrdinaryObject);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RemoveAllOrdinaryObjects", _m_RemoveAllOrdinaryObjects);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "OrdinaryObjects", _g_get_OrdinaryObjects);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "OrdinaryObjects", _s_set_OrdinaryObjects);
            
			XUtils.EndObjectRegister(typeof(xc.Dungeon.OrdinaryObjectManager), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.Dungeon.OrdinaryObjectManager), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.Dungeon.OrdinaryObjectManager));
			
			
			XUtils.EndClassRegister(typeof(xc.Dungeon.OrdinaryObjectManager), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.Dungeon.OrdinaryObjectManager __cl_gen_ret = new xc.Dungeon.OrdinaryObjectManager();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Dungeon.OrdinaryObjectManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateAllOrdinaryObjects(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.OrdinaryObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.OrdinaryObjectManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.CreateAllOrdinaryObjects(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateOrdinaryObject(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.OrdinaryObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.OrdinaryObjectManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int id = LuaAPI.xlua_tointeger(L, 2);
                    
                        xc.Dungeon.OrdinaryObjectObject __cl_gen_ret = __cl_gen_to_be_invoked.CreateOrdinaryObject( id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<Neptune.OrdinaryObject>(L, 2)) 
                {
                    Neptune.OrdinaryObject data = (Neptune.OrdinaryObject)translator.GetObject(L, 2, typeof(Neptune.OrdinaryObject));
                    
                        xc.Dungeon.OrdinaryObjectObject __cl_gen_ret = __cl_gen_to_be_invoked.CreateOrdinaryObject( data );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Dungeon.OrdinaryObjectManager.CreateOrdinaryObject!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetOrdinaryObject(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.OrdinaryObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.OrdinaryObjectManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int id = LuaAPI.xlua_tointeger(L, 2);
                    
                        xc.Dungeon.OrdinaryObjectObject __cl_gen_ret = __cl_gen_to_be_invoked.GetOrdinaryObject( id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveOrdinaryObject(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.OrdinaryObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.OrdinaryObjectManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int id = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.RemoveOrdinaryObject( id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveAllOrdinaryObjects(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.OrdinaryObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.OrdinaryObjectManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.RemoveAllOrdinaryObjects(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OrdinaryObjects(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Dungeon.OrdinaryObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.OrdinaryObjectManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.OrdinaryObjects);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OrdinaryObjects(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Dungeon.OrdinaryObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.OrdinaryObjectManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.OrdinaryObjects = (System.Collections.Generic.Dictionary<int, xc.Dungeon.OrdinaryObjectObject>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<int, xc.Dungeon.OrdinaryObjectObject>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
