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
    public class xcDBEquipPosDBEquipPosItemWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBEquipPos.DBEquipPosItem), L, translator, 0, 0, 14, 14);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PosId", _g_get_PosId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Name", _g_get_Name);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PosType", _g_get_PosType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CanStrength", _g_get_CanStrength);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CanBaptize", _g_get_CanBaptize);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CanInlay", _g_get_CanInlay);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CanSuit", _g_get_CanSuit);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CanCastSoul", _g_get_CanCastSoul);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SortId", _g_get_SortId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CanBaptizeLv", _g_get_CanBaptizeLv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CanAutoRecycle", _g_get_CanAutoRecycle);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CanEngrave", _g_get_CanEngrave);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "EngraveAtrrsDesc", _g_get_EngraveAtrrsDesc);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "EngraveShowAttrIds", _g_get_EngraveShowAttrIds);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "PosId", _s_set_PosId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Name", _s_set_Name);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "PosType", _s_set_PosType);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CanStrength", _s_set_CanStrength);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CanBaptize", _s_set_CanBaptize);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CanInlay", _s_set_CanInlay);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CanSuit", _s_set_CanSuit);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CanCastSoul", _s_set_CanCastSoul);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SortId", _s_set_SortId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CanBaptizeLv", _s_set_CanBaptizeLv);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CanAutoRecycle", _s_set_CanAutoRecycle);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CanEngrave", _s_set_CanEngrave);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "EngraveAtrrsDesc", _s_set_EngraveAtrrsDesc);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "EngraveShowAttrIds", _s_set_EngraveShowAttrIds);
            
			XUtils.EndObjectRegister(typeof(xc.DBEquipPos.DBEquipPosItem), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBEquipPos.DBEquipPosItem), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBEquipPos.DBEquipPosItem));
			
			
			XUtils.EndClassRegister(typeof(xc.DBEquipPos.DBEquipPosItem), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DBEquipPos.DBEquipPosItem __cl_gen_ret = new xc.DBEquipPos.DBEquipPosItem();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBEquipPos.DBEquipPosItem constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PosId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEquipPos.DBEquipPosItem __cl_gen_to_be_invoked = (xc.DBEquipPos.DBEquipPosItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.PosId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEquipPos.DBEquipPosItem __cl_gen_to_be_invoked = (xc.DBEquipPos.DBEquipPosItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Name);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PosType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEquipPos.DBEquipPosItem __cl_gen_to_be_invoked = (xc.DBEquipPos.DBEquipPosItem)translator.FastGetCSObj(L, 1);
                translator.PushxcDBEquipPosEquipPosType(L, __cl_gen_to_be_invoked.PosType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CanStrength(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEquipPos.DBEquipPosItem __cl_gen_to_be_invoked = (xc.DBEquipPos.DBEquipPosItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.CanStrength);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CanBaptize(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEquipPos.DBEquipPosItem __cl_gen_to_be_invoked = (xc.DBEquipPos.DBEquipPosItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.CanBaptize);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CanInlay(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEquipPos.DBEquipPosItem __cl_gen_to_be_invoked = (xc.DBEquipPos.DBEquipPosItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.CanInlay);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CanSuit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEquipPos.DBEquipPosItem __cl_gen_to_be_invoked = (xc.DBEquipPos.DBEquipPosItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.CanSuit);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CanCastSoul(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEquipPos.DBEquipPosItem __cl_gen_to_be_invoked = (xc.DBEquipPos.DBEquipPosItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.CanCastSoul);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SortId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEquipPos.DBEquipPosItem __cl_gen_to_be_invoked = (xc.DBEquipPos.DBEquipPosItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.SortId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CanBaptizeLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEquipPos.DBEquipPosItem __cl_gen_to_be_invoked = (xc.DBEquipPos.DBEquipPosItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.CanBaptizeLv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CanAutoRecycle(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEquipPos.DBEquipPosItem __cl_gen_to_be_invoked = (xc.DBEquipPos.DBEquipPosItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.CanAutoRecycle);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CanEngrave(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEquipPos.DBEquipPosItem __cl_gen_to_be_invoked = (xc.DBEquipPos.DBEquipPosItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.CanEngrave);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EngraveAtrrsDesc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEquipPos.DBEquipPosItem __cl_gen_to_be_invoked = (xc.DBEquipPos.DBEquipPosItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.EngraveAtrrsDesc);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EngraveShowAttrIds(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEquipPos.DBEquipPosItem __cl_gen_to_be_invoked = (xc.DBEquipPos.DBEquipPosItem)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.EngraveShowAttrIds);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PosId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEquipPos.DBEquipPosItem __cl_gen_to_be_invoked = (xc.DBEquipPos.DBEquipPosItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.PosId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEquipPos.DBEquipPosItem __cl_gen_to_be_invoked = (xc.DBEquipPos.DBEquipPosItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Name = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PosType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEquipPos.DBEquipPosItem __cl_gen_to_be_invoked = (xc.DBEquipPos.DBEquipPosItem)translator.FastGetCSObj(L, 1);
                xc.DBEquipPos.EquipPosType __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.PosType = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CanStrength(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEquipPos.DBEquipPosItem __cl_gen_to_be_invoked = (xc.DBEquipPos.DBEquipPosItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CanStrength = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CanBaptize(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEquipPos.DBEquipPosItem __cl_gen_to_be_invoked = (xc.DBEquipPos.DBEquipPosItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CanBaptize = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CanInlay(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEquipPos.DBEquipPosItem __cl_gen_to_be_invoked = (xc.DBEquipPos.DBEquipPosItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CanInlay = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CanSuit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEquipPos.DBEquipPosItem __cl_gen_to_be_invoked = (xc.DBEquipPos.DBEquipPosItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CanSuit = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CanCastSoul(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEquipPos.DBEquipPosItem __cl_gen_to_be_invoked = (xc.DBEquipPos.DBEquipPosItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CanCastSoul = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SortId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEquipPos.DBEquipPosItem __cl_gen_to_be_invoked = (xc.DBEquipPos.DBEquipPosItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SortId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CanBaptizeLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEquipPos.DBEquipPosItem __cl_gen_to_be_invoked = (xc.DBEquipPos.DBEquipPosItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CanBaptizeLv = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CanAutoRecycle(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEquipPos.DBEquipPosItem __cl_gen_to_be_invoked = (xc.DBEquipPos.DBEquipPosItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CanAutoRecycle = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CanEngrave(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEquipPos.DBEquipPosItem __cl_gen_to_be_invoked = (xc.DBEquipPos.DBEquipPosItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CanEngrave = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_EngraveAtrrsDesc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEquipPos.DBEquipPosItem __cl_gen_to_be_invoked = (xc.DBEquipPos.DBEquipPosItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.EngraveAtrrsDesc = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_EngraveShowAttrIds(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEquipPos.DBEquipPosItem __cl_gen_to_be_invoked = (xc.DBEquipPos.DBEquipPosItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.EngraveShowAttrIds = (System.Collections.Generic.List<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
