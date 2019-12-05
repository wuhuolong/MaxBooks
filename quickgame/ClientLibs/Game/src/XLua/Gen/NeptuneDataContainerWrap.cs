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
    public class NeptuneDataContainerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(Neptune.Data.Container), L, translator, 0, 0, 4, 2);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "RootGameObjectName", _g_get_RootGameObjectName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "GenerateId", _g_get_GenerateId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ItemRealType", _g_get_ItemRealType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Data", _g_get_Data);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ItemRealType", _s_set_ItemRealType);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Data", _s_set_Data);
            
			XUtils.EndObjectRegister(typeof(Neptune.Data.Container), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(Neptune.Data.Container), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(Neptune.Data.Container));
			
			
			XUtils.EndClassRegister(typeof(Neptune.Data.Container), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					Neptune.Data.Container __cl_gen_ret = new Neptune.Data.Container();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<System.Type>(L, 2))
				{
					System.Type item_type = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
					
					Neptune.Data.Container __cl_gen_ret = new Neptune.Data.Container(item_type);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Neptune.Data.Container constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RootGameObjectName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Neptune.Data.Container __cl_gen_to_be_invoked = (Neptune.Data.Container)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.RootGameObjectName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GenerateId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Neptune.Data.Container __cl_gen_to_be_invoked = (Neptune.Data.Container)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.GenerateId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ItemRealType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Neptune.Data.Container __cl_gen_to_be_invoked = (Neptune.Data.Container)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.ItemRealType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Data(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Neptune.Data.Container __cl_gen_to_be_invoked = (Neptune.Data.Container)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Data);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ItemRealType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Neptune.Data.Container __cl_gen_to_be_invoked = (Neptune.Data.Container)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ItemRealType = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Data(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Neptune.Data.Container __cl_gen_to_be_invoked = (Neptune.Data.Container)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Data = (System.Collections.Generic.Dictionary<int, Neptune.BaseGenericNode>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<int, Neptune.BaseGenericNode>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
