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
    public class xcEquipEquipHelperEquipEffectWashSelectDataWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.Equip.EquipHelper.EquipEffectWashSelectData), L, translator, 0, 0, 2, 2);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AttrCount", _g_get_AttrCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AttrLv", _g_get_AttrLv);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "AttrCount", _s_set_AttrCount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "AttrLv", _s_set_AttrLv);
            
			XUtils.EndObjectRegister(typeof(xc.Equip.EquipHelper.EquipEffectWashSelectData), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.Equip.EquipHelper.EquipEffectWashSelectData), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.Equip.EquipHelper.EquipEffectWashSelectData));
			
			
			XUtils.EndClassRegister(typeof(xc.Equip.EquipHelper.EquipEffectWashSelectData), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.Equip.EquipHelper.EquipEffectWashSelectData __cl_gen_ret = new xc.Equip.EquipHelper.EquipEffectWashSelectData();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Equip.EquipHelper.EquipEffectWashSelectData constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AttrCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Equip.EquipHelper.EquipEffectWashSelectData __cl_gen_to_be_invoked = (xc.Equip.EquipHelper.EquipEffectWashSelectData)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.AttrCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AttrLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Equip.EquipHelper.EquipEffectWashSelectData __cl_gen_to_be_invoked = (xc.Equip.EquipHelper.EquipEffectWashSelectData)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.AttrLv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AttrCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Equip.EquipHelper.EquipEffectWashSelectData __cl_gen_to_be_invoked = (xc.Equip.EquipHelper.EquipEffectWashSelectData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.AttrCount = (System.Collections.Generic.List<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AttrLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Equip.EquipHelper.EquipEffectWashSelectData __cl_gen_to_be_invoked = (xc.Equip.EquipHelper.EquipEffectWashSelectData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.AttrLv = (System.Collections.Generic.List<string>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<string>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
