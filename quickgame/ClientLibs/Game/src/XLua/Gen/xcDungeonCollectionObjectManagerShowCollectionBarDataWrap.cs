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
    public class xcDungeonCollectionObjectManagerShowCollectionBarDataWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.Dungeon.CollectionObjectManager.ShowCollectionBarData), L, translator, 0, 0, 3, 3);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mInteractButtonText", _g_get_mInteractButtonText);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mInteractButtonPic", _g_get_mInteractButtonPic);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mId", _g_get_mId);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mInteractButtonText", _s_set_mInteractButtonText);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mInteractButtonPic", _s_set_mInteractButtonPic);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mId", _s_set_mId);
            
			XUtils.EndObjectRegister(typeof(xc.Dungeon.CollectionObjectManager.ShowCollectionBarData), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.Dungeon.CollectionObjectManager.ShowCollectionBarData), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.Dungeon.CollectionObjectManager.ShowCollectionBarData));
			
			
			XUtils.EndClassRegister(typeof(xc.Dungeon.CollectionObjectManager.ShowCollectionBarData), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.Dungeon.CollectionObjectManager.ShowCollectionBarData __cl_gen_ret = new xc.Dungeon.CollectionObjectManager.ShowCollectionBarData();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Dungeon.CollectionObjectManager.ShowCollectionBarData constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mInteractButtonText(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Dungeon.CollectionObjectManager.ShowCollectionBarData __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectManager.ShowCollectionBarData)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.mInteractButtonText);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mInteractButtonPic(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Dungeon.CollectionObjectManager.ShowCollectionBarData __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectManager.ShowCollectionBarData)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.mInteractButtonPic);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Dungeon.CollectionObjectManager.ShowCollectionBarData __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectManager.ShowCollectionBarData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mInteractButtonText(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Dungeon.CollectionObjectManager.ShowCollectionBarData __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectManager.ShowCollectionBarData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mInteractButtonText = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mInteractButtonPic(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Dungeon.CollectionObjectManager.ShowCollectionBarData __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectManager.ShowCollectionBarData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mInteractButtonPic = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Dungeon.CollectionObjectManager.ShowCollectionBarData __cl_gen_to_be_invoked = (xc.Dungeon.CollectionObjectManager.ShowCollectionBarData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
