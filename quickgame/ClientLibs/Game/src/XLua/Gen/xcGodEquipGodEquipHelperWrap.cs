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
    public class xcGodEquipGodEquipHelperWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.GodEquip.GodEquipHelper), L, translator, 0, 0, 0, 0);
			
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.GodEquip.GodEquipHelper), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.GodEquip.GodEquipHelper), L, __CreateInstance, 11, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CheckHadGoodsByPos", _m_CheckHadGoodsByPos_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetTotalExp", _m_GetTotalExp_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetExpByList", _m_GetExpByList_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ComputeAttribute", _m_ComputeAttribute_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetBagItemByFilter", _m_GetBagItemByFilter_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetAttrMacro", _m_GetAttrMacro_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ShowGodEquipTipsWindowLayer", _m_ShowGodEquipTipsWindowLayer_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ShowGodEquipTipsWindow", _m_ShowGodEquipTipsWindow_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsBetterGodEquip", _m_IsBetterGodEquip_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetBestGoodsGodEquip", _m_GetBestGoodsGodEquip_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.GodEquip.GodEquipHelper));
			
			
			XUtils.EndClassRegister(typeof(xc.GodEquip.GodEquipHelper), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.GodEquip.GodEquipHelper __cl_gen_ret = new xc.GodEquip.GodEquipHelper();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.GodEquip.GodEquipHelper constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckHadGoodsByPos_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint pos = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.GodEquip.GodEquipHelper.CheckHadGoodsByPos( pos );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTotalExp_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                        uint __cl_gen_ret = xc.GodEquip.GodEquipHelper.GetTotalExp(  );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetExpByList_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    System.Collections.Generic.List<ulong> oids = (System.Collections.Generic.List<ulong>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<ulong>));
                    
                        uint __cl_gen_ret = xc.GodEquip.GodEquipHelper.GetExpByList( oids );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ComputeAttribute_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.GoodsGodEquip goods = (xc.GoodsGodEquip)translator.GetObject(L, 1, typeof(xc.GoodsGodEquip));
                    uint activeCount = LuaAPI.xlua_touint(L, 2);
                    xc.ActorAttribute attr = (xc.ActorAttribute)translator.GetObject(L, 3, typeof(xc.ActorAttribute));
                    
                    xc.GodEquip.GodEquipHelper.ComputeAttribute( goods, activeCount, attr );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBagItemByFilter_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)) 
                {
                    uint pos = LuaAPI.xlua_touint(L, 1);
                    uint level = LuaAPI.xlua_touint(L, 2);
                    uint colorType = LuaAPI.xlua_touint(L, 3);
                    System.Collections.Generic.List<uint> showPos = (System.Collections.Generic.List<uint>)translator.GetObject(L, 4, typeof(System.Collections.Generic.List<uint>));
                    bool isDescending = LuaAPI.lua_toboolean(L, 5);
                    
                        System.Collections.Generic.List<xc.GoodsGodEquip> __cl_gen_ret = xc.GodEquip.GodEquipHelper.GetBagItemByFilter( pos, level, colorType, showPos, isDescending );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 4)) 
                {
                    uint pos = LuaAPI.xlua_touint(L, 1);
                    uint level = LuaAPI.xlua_touint(L, 2);
                    uint colorType = LuaAPI.xlua_touint(L, 3);
                    System.Collections.Generic.List<uint> showPos = (System.Collections.Generic.List<uint>)translator.GetObject(L, 4, typeof(System.Collections.Generic.List<uint>));
                    
                        System.Collections.Generic.List<xc.GoodsGodEquip> __cl_gen_ret = xc.GodEquip.GodEquipHelper.GetBagItemByFilter( pos, level, colorType, showPos );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    uint pos = LuaAPI.xlua_touint(L, 1);
                    uint level = LuaAPI.xlua_touint(L, 2);
                    uint colorType = LuaAPI.xlua_touint(L, 3);
                    
                        System.Collections.Generic.List<xc.GoodsGodEquip> __cl_gen_ret = xc.GodEquip.GodEquipHelper.GetBagItemByFilter( pos, level, colorType );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.GodEquip.GodEquipHelper.GetBagItemByFilter!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAttrMacro_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint attr_id = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = xc.GodEquip.GodEquipHelper.GetAttrMacro( attr_id );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowGodEquipTipsWindowLayer_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    int layer = LuaAPI.xlua_tointeger(L, 1);
                    xc.GoodsGodEquip godEquip = (xc.GoodsGodEquip)translator.GetObject(L, 2, typeof(xc.GoodsGodEquip));
                    string showType = LuaAPI.lua_tostring(L, 3);
                    
                    xc.GodEquip.GodEquipHelper.ShowGodEquipTipsWindowLayer( layer, godEquip, showType );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowGodEquipTipsWindow_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.GoodsGodEquip godEquip = (xc.GoodsGodEquip)translator.GetObject(L, 1, typeof(xc.GoodsGodEquip));
                    string showType = LuaAPI.lua_tostring(L, 2);
                    
                    xc.GodEquip.GodEquipHelper.ShowGodEquipTipsWindow( godEquip, showType );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsBetterGodEquip_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.GoodsGodEquip goods = (xc.GoodsGodEquip)translator.GetObject(L, 1, typeof(xc.GoodsGodEquip));
                    
                        bool __cl_gen_ret = xc.GodEquip.GodEquipHelper.IsBetterGodEquip( goods );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBestGoodsGodEquip_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    
                        xc.GoodsGodEquip __cl_gen_ret = xc.GodEquip.GodEquipHelper.GetBestGoodsGodEquip(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
