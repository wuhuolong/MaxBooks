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
    public class xcDungeonDoorObjectManagerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.Dungeon.DoorObjectManager), L, translator, 0, 5, 1, 1);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CreateAllDoorObjects", _m_CreateAllDoorObjects);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CreateDoorObject", _m_CreateDoorObject);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetDoorObject", _m_GetDoorObject);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RemoveDoorObject", _m_RemoveDoorObject);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RemoveAllDoorObjects", _m_RemoveAllDoorObjects);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DoorObjects", _g_get_DoorObjects);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "DoorObjects", _s_set_DoorObjects);
            
			XUtils.EndObjectRegister(typeof(xc.Dungeon.DoorObjectManager), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.Dungeon.DoorObjectManager), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.Dungeon.DoorObjectManager));
			
			
			XUtils.EndClassRegister(typeof(xc.Dungeon.DoorObjectManager), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.Dungeon.DoorObjectManager __cl_gen_ret = new xc.Dungeon.DoorObjectManager();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Dungeon.DoorObjectManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateAllDoorObjects(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.DoorObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.DoorObjectManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.CreateAllDoorObjects(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateDoorObject(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.DoorObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.DoorObjectManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int id = LuaAPI.xlua_tointeger(L, 2);
                    
                        xc.Dungeon.DoorObject __cl_gen_ret = __cl_gen_to_be_invoked.CreateDoorObject( id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<Neptune.Door>(L, 2)) 
                {
                    Neptune.Door data = (Neptune.Door)translator.GetObject(L, 2, typeof(Neptune.Door));
                    
                        xc.Dungeon.DoorObject __cl_gen_ret = __cl_gen_to_be_invoked.CreateDoorObject( data );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Dungeon.DoorObjectManager.CreateDoorObject!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDoorObject(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.DoorObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.DoorObjectManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int id = LuaAPI.xlua_tointeger(L, 2);
                    
                        xc.Dungeon.DoorObject __cl_gen_ret = __cl_gen_to_be_invoked.GetDoorObject( id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveDoorObject(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.DoorObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.DoorObjectManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int id = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.RemoveDoorObject( id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveAllDoorObjects(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.DoorObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.DoorObjectManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.RemoveAllDoorObjects(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DoorObjects(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Dungeon.DoorObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.DoorObjectManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.DoorObjects);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DoorObjects(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Dungeon.DoorObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.DoorObjectManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.DoorObjects = (System.Collections.Generic.Dictionary<int, xc.Dungeon.DoorObject>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<int, xc.Dungeon.DoorObject>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
