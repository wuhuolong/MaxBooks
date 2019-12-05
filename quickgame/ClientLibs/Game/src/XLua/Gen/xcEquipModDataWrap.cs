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
    public class xcEquipModDataWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.EquipModData), L, translator, 0, 1, 18, 2);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CompareTo", _m_CompareTo);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsWeapon", _g_get_IsWeapon);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Id", _g_get_Id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Pos", _g_get_Pos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelId", _g_get_ModelId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LegendCount", _g_get_LegendCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NeedARCON", _g_get_NeedARCON);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NeedARSTR", _g_get_NeedARSTR);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NeedARAGI", _g_get_NeedARAGI);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NeedARINT", _g_get_NeedARINT);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LvStep", _g_get_LvStep);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "StrengthMax", _g_get_StrengthMax);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SuitId", _g_get_SuitId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PetExp", _g_get_PetExp);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DefaultStar", _g_get_DefaultStar);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DefaultExtraDesc", _g_get_DefaultExtraDesc);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CanIdentify", _g_get_CanIdentify);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DefaultScore", _g_get_DefaultScore);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LegendAttrs", _g_get_LegendAttrs);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "DefaultScore", _s_set_DefaultScore);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LegendAttrs", _s_set_LegendAttrs);
            
			XUtils.EndObjectRegister(typeof(xc.EquipModData), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.EquipModData), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.EquipModData));
			
			
			XUtils.EndClassRegister(typeof(xc.EquipModData), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.EquipModData __cl_gen_ret = new xc.EquipModData();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 18 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 7) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 8) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 9) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 10) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 11) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 12) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 13) && (LuaAPI.lua_isnil(L, 14) || LuaAPI.lua_type(L, 14) == LuaTypes.LUA_TSTRING) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 15) && LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 16) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 17) && translator.Assignable<System.Collections.Generic.List<System.Collections.Generic.List<uint>>>(L, 18))
				{
					uint id = LuaAPI.xlua_touint(L, 2);
					uint pos = LuaAPI.xlua_touint(L, 3);
					uint ar_con_need = LuaAPI.xlua_touint(L, 4);
					uint ar_str_need = LuaAPI.xlua_touint(L, 5);
					uint ar_agi_need = LuaAPI.xlua_touint(L, 6);
					uint ar_int_need = LuaAPI.xlua_touint(L, 7);
					uint legend_attrs_num = LuaAPI.xlua_touint(L, 8);
					uint model = LuaAPI.xlua_touint(L, 9);
					uint lv_step = LuaAPI.xlua_touint(L, 10);
					uint strength_max = LuaAPI.xlua_touint(L, 11);
					uint suit_id = LuaAPI.xlua_touint(L, 12);
					uint pet_exp = LuaAPI.xlua_touint(L, 13);
					byte[] default_extra_desc = LuaAPI.lua_tobytes(L, 14);
					uint default_star = LuaAPI.xlua_touint(L, 15);
					bool can_identify = LuaAPI.lua_toboolean(L, 16);
					uint default_score = LuaAPI.xlua_touint(L, 17);
					System.Collections.Generic.List<System.Collections.Generic.List<uint>> legend_attrs = (System.Collections.Generic.List<System.Collections.Generic.List<uint>>)translator.GetObject(L, 18, typeof(System.Collections.Generic.List<System.Collections.Generic.List<uint>>));
					
					xc.EquipModData __cl_gen_ret = new xc.EquipModData(id, pos, ar_con_need, ar_str_need, ar_agi_need, ar_int_need, legend_attrs_num, model, lv_step, strength_max, suit_id, pet_exp, default_extra_desc, default_star, can_identify, default_score, legend_attrs);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.EquipModData constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CompareTo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.EquipModData __cl_gen_to_be_invoked = (xc.EquipModData)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object targetObj = translator.GetObject(L, 2, typeof(object));
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.CompareTo( targetObj );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsWeapon(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipModData __cl_gen_to_be_invoked = (xc.EquipModData)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsWeapon);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipModData __cl_gen_to_be_invoked = (xc.EquipModData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Id);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Pos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipModData __cl_gen_to_be_invoked = (xc.EquipModData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Pos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipModData __cl_gen_to_be_invoked = (xc.EquipModData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ModelId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LegendCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipModData __cl_gen_to_be_invoked = (xc.EquipModData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.LegendCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NeedARCON(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipModData __cl_gen_to_be_invoked = (xc.EquipModData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.NeedARCON);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NeedARSTR(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipModData __cl_gen_to_be_invoked = (xc.EquipModData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.NeedARSTR);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NeedARAGI(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipModData __cl_gen_to_be_invoked = (xc.EquipModData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.NeedARAGI);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NeedARINT(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipModData __cl_gen_to_be_invoked = (xc.EquipModData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.NeedARINT);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LvStep(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipModData __cl_gen_to_be_invoked = (xc.EquipModData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.LvStep);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StrengthMax(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipModData __cl_gen_to_be_invoked = (xc.EquipModData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.StrengthMax);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SuitId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipModData __cl_gen_to_be_invoked = (xc.EquipModData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.SuitId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PetExp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipModData __cl_gen_to_be_invoked = (xc.EquipModData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.PetExp);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DefaultStar(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipModData __cl_gen_to_be_invoked = (xc.EquipModData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.DefaultStar);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DefaultExtraDesc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipModData __cl_gen_to_be_invoked = (xc.EquipModData)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.DefaultExtraDesc);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CanIdentify(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipModData __cl_gen_to_be_invoked = (xc.EquipModData)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.CanIdentify);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DefaultScore(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipModData __cl_gen_to_be_invoked = (xc.EquipModData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.DefaultScore);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LegendAttrs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipModData __cl_gen_to_be_invoked = (xc.EquipModData)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.LegendAttrs);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DefaultScore(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipModData __cl_gen_to_be_invoked = (xc.EquipModData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.DefaultScore = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LegendAttrs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipModData __cl_gen_to_be_invoked = (xc.EquipModData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.LegendAttrs = (System.Collections.Generic.List<System.Collections.Generic.List<uint>>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<System.Collections.Generic.List<uint>>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
