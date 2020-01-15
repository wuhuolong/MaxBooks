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
    public class xcDBTextResourceWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBTextResource), L, translator, 0, 1, 2, 2);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Load", _m_Load);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mStrName", _g_get_mStrName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mStrPath", _g_get_mStrPath);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mStrName", _s_set_mStrName);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mStrPath", _s_set_mStrPath);
            
			XUtils.EndObjectRegister(typeof(xc.DBTextResource), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBTextResource), L, __CreateInstance, 47, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseUI", _m_ParseUI_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseUI_s", _m_ParseUI_s_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseI", _m_ParseI_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseI_s", _m_ParseI_s_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseUL", _m_ParseUL_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseUL_s", _m_ParseUL_s_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseL", _m_ParseL_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseL_s", _m_ParseL_s_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseF", _m_ParseF_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseF_s", _m_ParseF_s_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseBT", _m_ParseBT_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseSBT", _m_ParseSBT_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseBT_s", _m_ParseBT_s_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseByteArray", _m_ParseByteArray_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseB", _m_ParseB_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseB_s", _m_ParseB_s_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseUS", _m_ParseUS_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseUS_s", _m_ParseUS_s_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseS", _m_ParseS_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseS_s", _m_ParseS_s_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "Byte2Str", _m_Byte2Str_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "Str2Byte", _m_Str2Byte_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseArrayString", _m_ParseArrayString_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseArrayUint", _m_ParseArrayUint_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseArrayLong", _m_ParseArrayLong_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseArrayByte", _m_ParseArrayByte_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseArrayVector2", _m_ParseArrayVector2_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseArrayVector3", _m_ParseArrayVector3_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseArrayVector4", _m_ParseArrayVector4_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseVector2", _m_ParseVector2_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseVector3", _m_ParseVector3_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseVector4", _m_ParseVector4_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseRect", _m_ParseRect_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseArrayStringString", _m_ParseArrayStringString_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "FreeDualList", _m_FreeDualList_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseArrayStringStringPool", _m_ParseArrayStringStringPool_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseArrayUintUint", _m_ParseArrayUintUint_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseArrayKeyValuePairUintUint", _m_ParseArrayKeyValuePairUintUint_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseUintListByBrace", _m_ParseUintListByBrace_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseDictionaryUintUint", _m_ParseDictionaryUintUint_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseDBGoodsItem", _m_ParseDBGoodsItem_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseDBAttrItems", _m_ParseDBAttrItems_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetStringArrayUint", _m_GetStringArrayUint_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseKeyValuePairList", _m_ParseKeyValuePairList_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseKeyUlongValuePairList", _m_ParseKeyUlongValuePairList_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseArrayUintAndUint", _m_ParseArrayUintAndUint_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBTextResource));
			
			
			XUtils.EndClassRegister(typeof(xc.DBTextResource), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 3 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING))
				{
					string strName = LuaAPI.lua_tostring(L, 2);
					string strPath = LuaAPI.lua_tostring(L, 3);
					
					xc.DBTextResource __cl_gen_ret = new xc.DBTextResource(strName, strPath);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBTextResource constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Load(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBTextResource __cl_gen_to_be_invoked = (xc.DBTextResource)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Load(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseUI_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string strValue = LuaAPI.lua_tostring(L, 1);
                    
                        uint __cl_gen_ret = xc.DBTextResource.ParseUI( strValue );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseUI_s_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string strValue = LuaAPI.lua_tostring(L, 1);
                    uint uiDefault = LuaAPI.xlua_touint(L, 2);
                    
                        uint __cl_gen_ret = xc.DBTextResource.ParseUI_s( strValue, uiDefault );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseI_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string strValue = LuaAPI.lua_tostring(L, 1);
                    
                        int __cl_gen_ret = xc.DBTextResource.ParseI( strValue );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseI_s_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string strValue = LuaAPI.lua_tostring(L, 1);
                    int iDefault = LuaAPI.xlua_tointeger(L, 2);
                    
                        int __cl_gen_ret = xc.DBTextResource.ParseI_s( strValue, iDefault );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseUL_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string strValue = LuaAPI.lua_tostring(L, 1);
                    
                        ulong __cl_gen_ret = xc.DBTextResource.ParseUL( strValue );
                        LuaAPI.lua_pushuint64(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseUL_s_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string strValue = LuaAPI.lua_tostring(L, 1);
                    ulong iDefault = LuaAPI.lua_touint64(L, 2);
                    
                        ulong __cl_gen_ret = xc.DBTextResource.ParseUL_s( strValue, iDefault );
                        LuaAPI.lua_pushuint64(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseL_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string strValue = LuaAPI.lua_tostring(L, 1);
                    
                        long __cl_gen_ret = xc.DBTextResource.ParseL( strValue );
                        LuaAPI.lua_pushint64(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseL_s_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string strValue = LuaAPI.lua_tostring(L, 1);
                    long iDefault = LuaAPI.lua_toint64(L, 2);
                    
                        long __cl_gen_ret = xc.DBTextResource.ParseL_s( strValue, iDefault );
                        LuaAPI.lua_pushint64(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseF_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string strValue = LuaAPI.lua_tostring(L, 1);
                    
                        float __cl_gen_ret = xc.DBTextResource.ParseF( strValue );
                        LuaAPI.lua_pushnumber(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseF_s_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string strValue = LuaAPI.lua_tostring(L, 1);
                    float fDefault = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        float __cl_gen_ret = xc.DBTextResource.ParseF_s( strValue, fDefault );
                        LuaAPI.lua_pushnumber(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseBT_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string strValue = LuaAPI.lua_tostring(L, 1);
                    
                        byte __cl_gen_ret = xc.DBTextResource.ParseBT( strValue );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseSBT_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string strValue = LuaAPI.lua_tostring(L, 1);
                    
                        sbyte __cl_gen_ret = xc.DBTextResource.ParseSBT( strValue );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseBT_s_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string strValue = LuaAPI.lua_tostring(L, 1);
                    byte btDefault = (byte)LuaAPI.lua_tonumber(L, 2);
                    
                        byte __cl_gen_ret = xc.DBTextResource.ParseBT_s( strValue, btDefault );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseByteArray_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string strValue = LuaAPI.lua_tostring(L, 1);
                    
                        byte[] __cl_gen_ret = xc.DBTextResource.ParseByteArray( strValue );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseB_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string strValue = LuaAPI.lua_tostring(L, 1);
                    
                        bool __cl_gen_ret = xc.DBTextResource.ParseB( strValue );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseB_s_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string strValue = LuaAPI.lua_tostring(L, 1);
                    bool bDefault = LuaAPI.lua_toboolean(L, 2);
                    
                        bool __cl_gen_ret = xc.DBTextResource.ParseB_s( strValue, bDefault );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseUS_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string strValue = LuaAPI.lua_tostring(L, 1);
                    
                        ushort __cl_gen_ret = xc.DBTextResource.ParseUS( strValue );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseUS_s_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string strValue = LuaAPI.lua_tostring(L, 1);
                    ushort usDefault = (ushort)LuaAPI.xlua_tointeger(L, 2);
                    
                        ushort __cl_gen_ret = xc.DBTextResource.ParseUS_s( strValue, usDefault );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseS_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string strValue = LuaAPI.lua_tostring(L, 1);
                    
                        short __cl_gen_ret = xc.DBTextResource.ParseS( strValue );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseS_s_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string strValue = LuaAPI.lua_tostring(L, 1);
                    short sDefault = (short)LuaAPI.xlua_tointeger(L, 2);
                    
                        short __cl_gen_ret = xc.DBTextResource.ParseS_s( strValue, sDefault );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Byte2Str_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    byte[] strData = LuaAPI.lua_tobytes(L, 1);
                    
                        string __cl_gen_ret = xc.DBTextResource.Byte2Str( strData );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Str2Byte_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string bytesData = LuaAPI.lua_tostring(L, 1);
                    
                        byte[] __cl_gen_ret = xc.DBTextResource.Str2Byte( bytesData );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseArrayString_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string arrayString = LuaAPI.lua_tostring(L, 1);
                    
                        System.Collections.Generic.List<string> __cl_gen_ret = xc.DBTextResource.ParseArrayString( arrayString );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    string arrayString = LuaAPI.lua_tostring(L, 1);
                    string del = LuaAPI.lua_tostring(L, 2);
                    bool exceptHeadAndEndChar = LuaAPI.lua_toboolean(L, 3);
                    
                        System.Collections.Generic.List<string> __cl_gen_ret = xc.DBTextResource.ParseArrayString( arrayString, del, exceptHeadAndEndChar );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string arrayString = LuaAPI.lua_tostring(L, 1);
                    string del = LuaAPI.lua_tostring(L, 2);
                    
                        System.Collections.Generic.List<string> __cl_gen_ret = xc.DBTextResource.ParseArrayString( arrayString, del );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBTextResource.ParseArrayString!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseArrayUint_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string arrayString = LuaAPI.lua_tostring(L, 1);
                    
                        System.Collections.Generic.List<uint> __cl_gen_ret = xc.DBTextResource.ParseArrayUint( arrayString );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    string arrayString = LuaAPI.lua_tostring(L, 1);
                    string del = LuaAPI.lua_tostring(L, 2);
                    bool exceptHeadAndEndChar = LuaAPI.lua_toboolean(L, 3);
                    
                        System.Collections.Generic.List<uint> __cl_gen_ret = xc.DBTextResource.ParseArrayUint( arrayString, del, exceptHeadAndEndChar );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string arrayString = LuaAPI.lua_tostring(L, 1);
                    string del = LuaAPI.lua_tostring(L, 2);
                    
                        System.Collections.Generic.List<uint> __cl_gen_ret = xc.DBTextResource.ParseArrayUint( arrayString, del );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBTextResource.ParseArrayUint!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseArrayLong_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string arrayString = LuaAPI.lua_tostring(L, 1);
                    string del = LuaAPI.lua_tostring(L, 2);
                    
                        System.Collections.Generic.List<long> __cl_gen_ret = xc.DBTextResource.ParseArrayLong( arrayString, del );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseArrayByte_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string arrayString = LuaAPI.lua_tostring(L, 1);
                    string del = LuaAPI.lua_tostring(L, 2);
                    
                        System.Collections.Generic.List<byte> __cl_gen_ret = xc.DBTextResource.ParseArrayByte( arrayString, del );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseArrayVector2_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string arrayString = LuaAPI.lua_tostring(L, 1);
                    
                        System.Collections.Generic.List<UnityEngine.Vector2> __cl_gen_ret = xc.DBTextResource.ParseArrayVector2( arrayString );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseArrayVector3_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string arrayString = LuaAPI.lua_tostring(L, 1);
                    
                        System.Collections.Generic.List<UnityEngine.Vector3> __cl_gen_ret = xc.DBTextResource.ParseArrayVector3( arrayString );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseArrayVector4_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string arrayString = LuaAPI.lua_tostring(L, 1);
                    
                        System.Collections.Generic.List<UnityEngine.Vector4> __cl_gen_ret = xc.DBTextResource.ParseArrayVector4( arrayString );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseVector2_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string str = LuaAPI.lua_tostring(L, 1);
                    
                        UnityEngine.Vector2 __cl_gen_ret = xc.DBTextResource.ParseVector2( str );
                        translator.PushUnityEngineVector2(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseVector3_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string str = LuaAPI.lua_tostring(L, 1);
                    
                        UnityEngine.Vector3 __cl_gen_ret = xc.DBTextResource.ParseVector3( str );
                        translator.PushUnityEngineVector3(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseVector4_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string str = LuaAPI.lua_tostring(L, 1);
                    
                        UnityEngine.Vector4 __cl_gen_ret = xc.DBTextResource.ParseVector4( str );
                        translator.PushUnityEngineVector4(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseRect_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string str = LuaAPI.lua_tostring(L, 1);
                    
                        UnityEngine.Rect __cl_gen_ret = xc.DBTextResource.ParseRect( str );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseArrayStringString_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string str = LuaAPI.lua_tostring(L, 1);
                    
                        System.Collections.Generic.List<System.Collections.Generic.List<string>> __cl_gen_ret = xc.DBTextResource.ParseArrayStringString( str );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FreeDualList_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    System.Collections.Generic.List<System.Collections.Generic.List<string>> dual_list = (System.Collections.Generic.List<System.Collections.Generic.List<string>>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<System.Collections.Generic.List<string>>));
                    
                    xc.DBTextResource.FreeDualList( dual_list );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseArrayStringStringPool_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string str = LuaAPI.lua_tostring(L, 1);
                    bool usePool = LuaAPI.lua_toboolean(L, 2);
                    
                        System.Collections.Generic.List<System.Collections.Generic.List<string>> __cl_gen_ret = xc.DBTextResource.ParseArrayStringStringPool( str, usePool );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseArrayUintUint_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string str = LuaAPI.lua_tostring(L, 1);
                    
                        System.Collections.Generic.List<System.Collections.Generic.List<uint>> __cl_gen_ret = xc.DBTextResource.ParseArrayUintUint( str );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseArrayKeyValuePairUintUint_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string str = LuaAPI.lua_tostring(L, 1);
                    
                        System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<uint, uint>> __cl_gen_ret = xc.DBTextResource.ParseArrayKeyValuePairUintUint( str );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseUintListByBrace_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string raw = LuaAPI.lua_tostring(L, 1);
                    
                        System.Collections.Generic.List<uint> __cl_gen_ret = xc.DBTextResource.ParseUintListByBrace( raw );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseDictionaryUintUint_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string str = LuaAPI.lua_tostring(L, 1);
                    
                        System.Collections.Generic.Dictionary<uint, uint> __cl_gen_ret = xc.DBTextResource.ParseDictionaryUintUint( str );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseDBGoodsItem_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string raw = LuaAPI.lua_tostring(L, 1);
                    
                        System.Collections.Generic.List<xc.DBTextResource.DBGoodsItem> __cl_gen_ret = xc.DBTextResource.ParseDBGoodsItem( raw );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseDBAttrItems_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string raw = LuaAPI.lua_tostring(L, 1);
                    
                        System.Collections.Generic.List<xc.DBTextResource.DBAttrItem> __cl_gen_ret = xc.DBTextResource.ParseDBAttrItems( raw );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetStringArrayUint_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    System.Collections.Generic.List<uint> uint_array = (System.Collections.Generic.List<uint>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<uint>));
                    string del = LuaAPI.lua_tostring(L, 2);
                    string prefix_str = LuaAPI.lua_tostring(L, 3);
                    string suffix_str = LuaAPI.lua_tostring(L, 4);
                    
                        string __cl_gen_ret = xc.DBTextResource.GetStringArrayUint( uint_array, del, prefix_str, suffix_str );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseKeyValuePairList_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string str = LuaAPI.lua_tostring(L, 1);
                    
                        System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<uint, uint>> __cl_gen_ret = xc.DBTextResource.ParseKeyValuePairList( str );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseKeyUlongValuePairList_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string str = LuaAPI.lua_tostring(L, 1);
                    
                        System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<uint, ulong>> __cl_gen_ret = xc.DBTextResource.ParseKeyUlongValuePairList( str );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseArrayUintAndUint_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string arrayString = LuaAPI.lua_tostring(L, 1);
                    string del = LuaAPI.lua_tostring(L, 2);
                    
                        System.Collections.Generic.List<uint> __cl_gen_ret = xc.DBTextResource.ParseArrayUintAndUint( arrayString, del );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mStrName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBTextResource __cl_gen_to_be_invoked = (xc.DBTextResource)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.mStrName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mStrPath(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBTextResource __cl_gen_to_be_invoked = (xc.DBTextResource)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.mStrPath);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mStrName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBTextResource __cl_gen_to_be_invoked = (xc.DBTextResource)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mStrName = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mStrPath(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBTextResource __cl_gen_to_be_invoked = (xc.DBTextResource)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mStrPath = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
