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
    public class xcMountEquipHelperWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.MountEquipHelper), L, translator, 0, 0, 0, 0);
			
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.MountEquipHelper), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.MountEquipHelper), L, __CreateInstance, 5, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetFilterAndSortGoodsList", _m_GetFilterAndSortGoodsList_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetMountLv", _m_GetMountLv_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetBestMountEquip", _m_GetBestMountEquip_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsBetterMountEquip", _m_IsBetterMountEquip_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.MountEquipHelper));
			
			
			XUtils.EndClassRegister(typeof(xc.MountEquipHelper), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.MountEquipHelper __cl_gen_ret = new xc.MountEquipHelper();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.MountEquipHelper constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFilterAndSortGoodsList_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    int level = LuaAPI.xlua_tointeger(L, 1);
                    int pos = LuaAPI.xlua_tointeger(L, 2);
                    
                        System.Collections.Generic.List<xc.GoodsMountEquip> __cl_gen_ret = xc.MountEquipHelper.GetFilterAndSortGoodsList( level, pos );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMountLv_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                        int __cl_gen_ret = xc.MountEquipHelper.GetMountLv(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBestMountEquip_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    
                        xc.GoodsMountEquip __cl_gen_ret = xc.MountEquipHelper.GetBestMountEquip(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsBetterMountEquip_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.GoodsMountEquip goods = (xc.GoodsMountEquip)translator.GetObject(L, 1, typeof(xc.GoodsMountEquip));
                    
                        bool __cl_gen_ret = xc.MountEquipHelper.IsBetterMountEquip( goods );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
