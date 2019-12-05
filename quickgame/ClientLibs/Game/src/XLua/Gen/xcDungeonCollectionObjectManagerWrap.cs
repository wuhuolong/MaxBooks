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
    public class xcDungeonCollectionObjectManagerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.Dungeon.CollectionObjectManager), L, translator, 0, 8, 3, 2);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RegisterMessages", _m_RegisterMessages);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CreateAllCollectionObjects", _m_CreateAllCollectionObjects);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CreateCollectionObject", _m_CreateCollectionObject);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetCollectionObject", _m_GetCollectionObject);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RemoveCollectionObject", _m_RemoveCollectionObject);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RemoveAllCollectionObjects", _m_RemoveAllCollectionObjects);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowCollectionBar", _m_ShowCollectionBar);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "HideCollectionBar", _m_HideCollectionBar);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CollectionObjectsCount", _g_get_CollectionObjectsCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Enable", _g_get_Enable);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CollectionObjects", _g_get_CollectionObjects);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Enable", _s_set_Enable);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CollectionObjects", _s_set_CollectionObjects);
            
			XUtils.EndObjectRegister(typeof(xc.Dungeon.CollectionObjectManager), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.Dungeon.CollectionObjectManager), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.Dungeon.CollectionObjectManager));
			
			
			XUtils.EndClassRegister(typeof(xc.Dungeon.CollectionObjectManager), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.Dungeon.CollectionObjectManager __cl_gen_ret = new xc.Dungeon.CollectionObjectManager();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Dungeon.CollectionObjectManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RegisterMessages(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.CollectionObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.RegisterMessages(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateAllCollectionObjects(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.CollectionObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.CreateAllCollectionObjects(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateCollectionObject(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.CollectionObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int id = LuaAPI.xlua_tointeger(L, 2);
                    
                        xc.Dungeon.CollectionObject __cl_gen_ret = __cl_gen_to_be_invoked.CreateCollectionObject( id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<Neptune.Collection>(L, 2)) 
                {
                    Neptune.Collection data = (Neptune.Collection)translator.GetObject(L, 2, typeof(Neptune.Collection));
                    
                        xc.Dungeon.CollectionObject __cl_gen_ret = __cl_gen_to_be_invoked.CreateCollectionObject( data );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector3>(L, 4)) 
                {
                    int id = LuaAPI.xlua_tointeger(L, 2);
                    uint excelId = LuaAPI.xlua_touint(L, 3);
                    UnityEngine.Vector3 pos;translator.Get(L, 4, out pos);
                    
                        xc.Dungeon.CollectionObject __cl_gen_ret = __cl_gen_to_be_invoked.CreateCollectionObject( id, excelId, pos );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Dungeon.CollectionObjectManager.CreateCollectionObject!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCollectionObject(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.CollectionObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int id = LuaAPI.xlua_tointeger(L, 2);
                    
                        xc.Dungeon.CollectionObject __cl_gen_ret = __cl_gen_to_be_invoked.GetCollectionObject( id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveCollectionObject(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.CollectionObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int id = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.RemoveCollectionObject( id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveAllCollectionObjects(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.CollectionObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.RemoveAllCollectionObjects(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowCollectionBar(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.CollectionObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string mInteractButtonText = LuaAPI.lua_tostring(L, 2);
                    string mInteractButtonPic = LuaAPI.lua_tostring(L, 3);
                    uint mId = LuaAPI.xlua_touint(L, 4);
                    
                    __cl_gen_to_be_invoked.ShowCollectionBar( mInteractButtonText, mInteractButtonPic, mId );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HideCollectionBar(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Dungeon.CollectionObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint mId = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.HideCollectionBar( mId );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CollectionObjectsCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Dungeon.CollectionObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.CollectionObjectsCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Enable(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Dungeon.CollectionObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.Enable);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CollectionObjects(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Dungeon.CollectionObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.CollectionObjects);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Enable(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Dungeon.CollectionObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Enable = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CollectionObjects(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Dungeon.CollectionObjectManager __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CollectionObjects = (System.Collections.Generic.Dictionary<int, xc.Dungeon.CollectionObject>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<int, xc.Dungeon.CollectionObject>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
