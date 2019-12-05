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
    public class xcDecorateDecorateHelperWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.Decorate.DecorateHelper), L, translator, 0, 0, 0, 0);
			
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.Decorate.DecorateHelper), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.Decorate.DecorateHelper), L, __CreateInstance, 17, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetStrengthAttr", _m_GetStrengthAttr_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetAppendAttr", _m_GetAppendAttr_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetBreakAppendAttr", _m_GetBreakAppendAttr_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetWearingDecorateByPos", _m_GetWearingDecorateByPos_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetBagDecoratesByPos", _m_GetBagDecoratesByPos_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetPosInfo", _m_GetPosInfo_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsBetterDecorateCanQuickUse", _m_IsBetterDecorateCanQuickUse_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetBestBagDecorate", _m_GetBestBagDecorate_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetPlayerDecorateSumScore", _m_GetPlayerDecorateSumScore_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetPlayerDecorateSumAttrsDesc", _m_GetPlayerDecorateSumAttrsDesc_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetDecorateSuitAttrList", _m_GetDecorateSuitAttrList_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetDecorateLegendAttrStr", _m_GetDecorateLegendAttrStr_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetDecorateStar", _m_GetDecorateStar_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ShowDecorateTipsWindowLayer", _m_ShowDecorateTipsWindowLayer_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ShowDecorateTipsWindow", _m_ShowDecorateTipsWindow_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetSubAttrDescEx", _m_GetSubAttrDescEx_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.Decorate.DecorateHelper));
			
			
			XUtils.EndClassRegister(typeof(xc.Decorate.DecorateHelper), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.Decorate.DecorateHelper __cl_gen_ret = new xc.Decorate.DecorateHelper();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Decorate.DecorateHelper constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetStrengthAttr_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint strengthLv = LuaAPI.xlua_touint(L, 1);
                    xc.GoodsDecorate decorate = (xc.GoodsDecorate)translator.GetObject(L, 2, typeof(xc.GoodsDecorate));
                    
                        xc.ActorAttribute __cl_gen_ret = xc.Decorate.DecorateHelper.GetStrengthAttr( strengthLv, decorate );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAppendAttr_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.GoodsDecorate decorate = (xc.GoodsDecorate)translator.GetObject(L, 1, typeof(xc.GoodsDecorate));
                    
                        xc.ActorAttribute __cl_gen_ret = xc.Decorate.DecorateHelper.GetAppendAttr( decorate );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBreakAppendAttr_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.GoodsDecorate decorate = (xc.GoodsDecorate)translator.GetObject(L, 1, typeof(xc.GoodsDecorate));
                    
                        xc.ActorAttribute __cl_gen_ret = xc.Decorate.DecorateHelper.GetBreakAppendAttr( decorate );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetWearingDecorateByPos_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint pos = LuaAPI.xlua_touint(L, 1);
                    
                        xc.GoodsDecorate __cl_gen_ret = xc.Decorate.DecorateHelper.GetWearingDecorateByPos( pos );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBagDecoratesByPos_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    uint pos = LuaAPI.xlua_touint(L, 1);
                    bool can_use_limit = LuaAPI.lua_toboolean(L, 2);
                    
                        System.Collections.Generic.List<xc.GoodsDecorate> __cl_gen_ret = xc.Decorate.DecorateHelper.GetBagDecoratesByPos( pos, can_use_limit );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint pos = LuaAPI.xlua_touint(L, 1);
                    
                        System.Collections.Generic.List<xc.GoodsDecorate> __cl_gen_ret = xc.Decorate.DecorateHelper.GetBagDecoratesByPos( pos );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Decorate.DecorateHelper.GetBagDecoratesByPos!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPosInfo_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint pos = LuaAPI.xlua_touint(L, 1);
                    
                        xc.DecoratePosInfo __cl_gen_ret = xc.Decorate.DecorateHelper.GetPosInfo( pos );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsBetterDecorateCanQuickUse_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.GoodsDecorate decorate = (xc.GoodsDecorate)translator.GetObject(L, 1, typeof(xc.GoodsDecorate));
                    
                        bool __cl_gen_ret = xc.Decorate.DecorateHelper.IsBetterDecorateCanQuickUse( decorate );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBestBagDecorate_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    
                        xc.GoodsDecorate __cl_gen_ret = xc.Decorate.DecorateHelper.GetBestBagDecorate(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPlayerDecorateSumScore_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                        int __cl_gen_ret = xc.Decorate.DecorateHelper.GetPlayerDecorateSumScore(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPlayerDecorateSumAttrsDesc_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    
                        System.Collections.Generic.List<xc.DBDecorate.LegendAttrDescItem> __cl_gen_ret = xc.Decorate.DecorateHelper.GetPlayerDecorateSumAttrsDesc(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDecorateSuitAttrList_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    
                        System.Collections.Generic.List<System.Collections.Generic.List<uint>> __cl_gen_ret = xc.Decorate.DecorateHelper.GetDecorateSuitAttrList(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDecorateLegendAttrStr_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.GoodsDecorate decorate = (xc.GoodsDecorate)translator.GetObject(L, 1, typeof(xc.GoodsDecorate));
                    
                        string __cl_gen_ret = xc.Decorate.DecorateHelper.GetDecorateLegendAttrStr( decorate );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDecorateStar_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.GoodsDecorate decorate = (xc.GoodsDecorate)translator.GetObject(L, 1, typeof(xc.GoodsDecorate));
                    
                        uint __cl_gen_ret = xc.Decorate.DecorateHelper.GetDecorateStar( decorate );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowDecorateTipsWindowLayer_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    int layer = LuaAPI.xlua_tointeger(L, 1);
                    xc.GoodsDecorate decorate = (xc.GoodsDecorate)translator.GetObject(L, 2, typeof(xc.GoodsDecorate));
                    string showType = LuaAPI.lua_tostring(L, 3);
                    
                    xc.Decorate.DecorateHelper.ShowDecorateTipsWindowLayer( layer, decorate, showType );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowDecorateTipsWindow_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<xc.GoodsDecorate>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    xc.GoodsDecorate decorate = (xc.GoodsDecorate)translator.GetObject(L, 1, typeof(xc.GoodsDecorate));
                    string showType = LuaAPI.lua_tostring(L, 2);
                    
                    xc.Decorate.DecorateHelper.ShowDecorateTipsWindow( decorate, showType );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& translator.Assignable<xc.GoodsDecorate>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    xc.GoodsDecorate decorate = (xc.GoodsDecorate)translator.GetObject(L, 1, typeof(xc.GoodsDecorate));
                    string showType = LuaAPI.lua_tostring(L, 2);
                    uint strengthenLv = LuaAPI.xlua_touint(L, 3);
                    
                    xc.Decorate.DecorateHelper.ShowDecorateTipsWindow( decorate, showType, strengthenLv );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Decorate.DecorateHelper.ShowDecorateTipsWindow!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSubAttrDescEx_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.EquipAttrData attrData = (xc.EquipAttrData)translator.GetObject(L, 1, typeof(xc.EquipAttrData));
                    uint[] values = translator.GetParams<uint>(L, 2);
                    
                        System.Collections.Generic.List<string> __cl_gen_ret = xc.Decorate.DecorateHelper.GetSubAttrDescEx( attrData, values );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
