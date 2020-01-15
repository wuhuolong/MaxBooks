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
    public class xcDungeonColliderObjectManagerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.Dungeon.ColliderObjectManager), L, translator, 0, 8, 1, 1);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CreateAllColliderObjects", _m_CreateAllColliderObjects);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CreateColliderObject", _m_CreateColliderObject);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetColliderObject", _m_GetColliderObject);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetNeedNavigateColliderObjects", _m_GetNeedNavigateColliderObjects);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetColliderObjectBehaviour", _m_GetColliderObjectBehaviour);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RemoveColliderObject", _m_RemoveColliderObject);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RemoveAllColliderObjects", _m_RemoveAllColliderObjects);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "TriggerColliderObject", _m_TriggerColliderObject);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ColliderObjects", _g_get_ColliderObjects);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ColliderObjects", _s_set_ColliderObjects);
            
			XUtils.EndObjectRegister(typeof(xc.Dungeon.ColliderObjectManager), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.Dungeon.ColliderObjectManager), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.Dungeon.ColliderObjectManager));
			
			
			XUtils.EndClassRegister(typeof(xc.Dungeon.ColliderObjectManager), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.Dungeon.ColliderObjectManager __cl_gen_ret = new xc.Dungeon.ColliderObjectManager();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Dungeon.ColliderObjectManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateAllColliderObjects(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.ColliderObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.ColliderObjectManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.CreateAllColliderObjects(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateColliderObject(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.ColliderObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.ColliderObjectManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int id = LuaAPI.xlua_tointeger(L, 2);
                    
                        xc.Dungeon.ColliderObject __cl_gen_ret = __cl_gen_to_be_invoked.CreateColliderObject( id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<Neptune.Collider>(L, 2)) 
                {
                    Neptune.Collider data = (Neptune.Collider)translator.GetObject(L, 2, typeof(Neptune.Collider));
                    
                        xc.Dungeon.ColliderObject __cl_gen_ret = __cl_gen_to_be_invoked.CreateColliderObject( data );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Dungeon.ColliderObjectManager.CreateColliderObject!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetColliderObject(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.ColliderObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.ColliderObjectManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int id = LuaAPI.xlua_tointeger(L, 2);
                    
                        xc.Dungeon.ColliderObject __cl_gen_ret = __cl_gen_to_be_invoked.GetColliderObject( id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNeedNavigateColliderObjects(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.ColliderObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.ColliderObjectManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.Collections.Generic.List<xc.Dungeon.ColliderObject> __cl_gen_ret = __cl_gen_to_be_invoked.GetNeedNavigateColliderObjects(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetColliderObjectBehaviour(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.ColliderObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.ColliderObjectManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int id = LuaAPI.xlua_tointeger(L, 2);
                    
                        xc.Dungeon.ColliderObjectBehaviour __cl_gen_ret = __cl_gen_to_be_invoked.GetColliderObjectBehaviour( id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveColliderObject(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.ColliderObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.ColliderObjectManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int id = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.RemoveColliderObject( id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveAllColliderObjects(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.ColliderObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.ColliderObjectManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.RemoveAllColliderObjects(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TriggerColliderObject(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.ColliderObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.ColliderObjectManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int id = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.TriggerColliderObject( id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ColliderObjects(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Dungeon.ColliderObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.ColliderObjectManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.ColliderObjects);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ColliderObjects(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Dungeon.ColliderObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.ColliderObjectManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ColliderObjects = (System.Collections.Generic.Dictionary<int, xc.Dungeon.ColliderObject>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<int, xc.Dungeon.ColliderObject>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
