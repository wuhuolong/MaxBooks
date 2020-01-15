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
    public class UranusRuntimeUranusManagerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(Uranus.Runtime.UranusManager), L, translator, 0, 14, 1, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetRunningNepKey", _m_GetRunningNepKey);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Update", _m_Update);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RegistConditionCreator", _m_RegistConditionCreator);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetConditionCreator", _m_GetConditionCreator);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RegistActionCreator", _m_RegistActionCreator);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetActionCreator", _m_GetActionCreator);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "LoadNodeGroup", _m_LoadNodeGroup);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "LoadNodeGroupByJson", _m_LoadNodeGroupByJson);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddNodeGroup", _m_AddNodeGroup);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetNodeGroup", _m_GetNodeGroup);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RemoveNodeGroup", _m_RemoveNodeGroup);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ClearAllNodeGroups", _m_ClearAllNodeGroups);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ActiveNode", _m_ActiveNode);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ActiveLevelNode", _m_ActiveLevelNode);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NodeGroups", _g_get_NodeGroups);
            
			
			XUtils.EndObjectRegister(typeof(Uranus.Runtime.UranusManager), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(Uranus.Runtime.UranusManager), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(Uranus.Runtime.UranusManager));
			
			
			XUtils.EndClassRegister(typeof(Uranus.Runtime.UranusManager), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					Uranus.Runtime.UranusManager __cl_gen_ret = new Uranus.Runtime.UranusManager();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Uranus.Runtime.UranusManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetRunningNepKey(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Uranus.Runtime.UranusManager __cl_gen_to_be_invoked = (Uranus.Runtime.UranusManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.GetRunningNepKey(  );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Update(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Uranus.Runtime.UranusManager __cl_gen_to_be_invoked = (Uranus.Runtime.UranusManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Update(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RegistConditionCreator(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Uranus.Runtime.UranusManager __cl_gen_to_be_invoked = (Uranus.Runtime.UranusManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Uranus.Runtime.IConditionCreator creator = (Uranus.Runtime.IConditionCreator)translator.GetObject(L, 2, typeof(Uranus.Runtime.IConditionCreator));
                    
                    __cl_gen_to_be_invoked.RegistConditionCreator( creator );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetConditionCreator(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Uranus.Runtime.UranusManager __cl_gen_to_be_invoked = (Uranus.Runtime.UranusManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        Uranus.Runtime.IConditionCreator __cl_gen_ret = __cl_gen_to_be_invoked.GetConditionCreator(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RegistActionCreator(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Uranus.Runtime.UranusManager __cl_gen_to_be_invoked = (Uranus.Runtime.UranusManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Uranus.Runtime.IActionCreator creator = (Uranus.Runtime.IActionCreator)translator.GetObject(L, 2, typeof(Uranus.Runtime.IActionCreator));
                    
                    __cl_gen_to_be_invoked.RegistActionCreator( creator );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetActionCreator(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Uranus.Runtime.UranusManager __cl_gen_to_be_invoked = (Uranus.Runtime.UranusManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        Uranus.Runtime.IActionCreator __cl_gen_ret = __cl_gen_to_be_invoked.GetActionCreator(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadNodeGroup(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Uranus.Runtime.UranusManager __cl_gen_to_be_invoked = (Uranus.Runtime.UranusManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string key = LuaAPI.lua_tostring(L, 2);
                    
                        Uranus.Runtime.NodeGroup __cl_gen_ret = __cl_gen_to_be_invoked.LoadNodeGroup( key );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadNodeGroupByJson(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Uranus.Runtime.UranusManager __cl_gen_to_be_invoked = (Uranus.Runtime.UranusManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string path = LuaAPI.lua_tostring(L, 2);
                    
                        Uranus.Runtime.NodeGroup __cl_gen_ret = __cl_gen_to_be_invoked.LoadNodeGroupByJson( path );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddNodeGroup(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Uranus.Runtime.UranusManager __cl_gen_to_be_invoked = (Uranus.Runtime.UranusManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string key = LuaAPI.lua_tostring(L, 2);
                    Uranus.Runtime.NodeGroup group = (Uranus.Runtime.NodeGroup)translator.GetObject(L, 3, typeof(Uranus.Runtime.NodeGroup));
                    
                    __cl_gen_to_be_invoked.AddNodeGroup( key, group );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNodeGroup(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Uranus.Runtime.UranusManager __cl_gen_to_be_invoked = (Uranus.Runtime.UranusManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string key = LuaAPI.lua_tostring(L, 2);
                    
                        Uranus.Runtime.NodeGroup __cl_gen_ret = __cl_gen_to_be_invoked.GetNodeGroup( key );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveNodeGroup(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Uranus.Runtime.UranusManager __cl_gen_to_be_invoked = (Uranus.Runtime.UranusManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string key = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.RemoveNodeGroup( key );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<Uranus.Runtime.NodeGroup>(L, 2)) 
                {
                    Uranus.Runtime.NodeGroup group = (Uranus.Runtime.NodeGroup)translator.GetObject(L, 2, typeof(Uranus.Runtime.NodeGroup));
                    
                    __cl_gen_to_be_invoked.RemoveNodeGroup( group );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Uranus.Runtime.UranusManager.RemoveNodeGroup!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearAllNodeGroups(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Uranus.Runtime.UranusManager __cl_gen_to_be_invoked = (Uranus.Runtime.UranusManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ClearAllNodeGroups(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ActiveNode(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Uranus.Runtime.UranusManager __cl_gen_to_be_invoked = (Uranus.Runtime.UranusManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string key = LuaAPI.lua_tostring(L, 2);
                    uint id = LuaAPI.xlua_touint(L, 3);
                    
                    __cl_gen_to_be_invoked.ActiveNode( key, id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ActiveLevelNode(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Uranus.Runtime.UranusManager __cl_gen_to_be_invoked = (Uranus.Runtime.UranusManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.ActiveLevelNode( id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NodeGroups(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Uranus.Runtime.UranusManager __cl_gen_to_be_invoked = (Uranus.Runtime.UranusManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.NodeGroups);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
