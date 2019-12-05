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
using System;
using Mono.Data.Sqlite;
using System.Data;

namespace XLua.CSObjectWrap
{
    using XUtils = XLua.XUtils;
    public class xcLuaSqliteUtilityWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);

            XUtils.BeginObjectRegister(typeof(xc.LuaSqliteUtility), L, translator, 0, 2, 0, 0);
            XUtils.EndObjectRegister(typeof(xc.LuaSqliteUtility), L, translator, null, null, null, null, null);

            XUtils.BeginClassRegister(typeof(xc.LuaSqliteUtility), L, __CreateInstance, 1, 0, 0);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.LuaSqliteUtility));
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetFirstRow", GetFirstRow);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetAllRows", GetAllRows);
            XUtils.EndClassRegister(typeof(xc.LuaSqliteUtility), L, translator); 
        }

        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try
            {
                if (LuaAPI.lua_gettop(L) == 1)
                {

                    xc.LuaSqliteUtility __cl_gen_ret = new xc.LuaSqliteUtility();
                    translator.Push(L, __cl_gen_ret);
                    return 1;
                }

            }
            catch (System.Exception __gen_e)
            {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return LuaAPI.luaL_error(L, "invalid arguments to xc.SqliteRows constructor!");
        }

        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int GetFirstRow(RealStatePtr L)
        {
            try
            {
                string db_name = LuaAPI.lua_tostring(L, 1);
                string table_name = LuaAPI.lua_tostring(L, 2);
                string query_str = LuaAPI.lua_tostring(L, 3);
                LuaAPI.lua_newtable(L);

                var data_reader = xc.DBManager.Instance.ExecuteSqliteQueryToReader(db_name, table_name, query_str);

                if (data_reader != null)
                {
                    if (data_reader.HasRows)
                    {
                        int field_count = data_reader.FieldCount;

                        // 只对SELECT * 的SQL语句进行列信息的缓存和获取
                        bool select_all = false;
                        for (int i = 0; i < query_str.Length && i < 10; ++i)
                        {
                            char c = query_str[i];
                            if (c == '*')
                            {
                                select_all = true;
                                break;
                            }
                        }

                        // 获取可用的列信息
                        bool has_column_info = false;
                        List<xc.DBManager.ColumnInfo> column_info = null;
                        if (select_all)
                        {
                            column_info = xc.DBManager.Instance.GetColumnInfo(table_name);
                            if (column_info != null)
                            {
                                if (column_info.Count != field_count)
                                    has_column_info = false;
                                else
                                    has_column_info = true;
                            }
                            else
                                has_column_info = false;

                            if (!has_column_info)
                                column_info = new List<xc.DBManager.ColumnInfo>();
                        }

                        data_reader.Read();

                        PackRow(L, data_reader, table_name, has_column_info, column_info, field_count);

                        if(!has_column_info && column_info != null)
                        {
                            xc.DBManager.Instance.SetColumnInfo(table_name, column_info);
                            has_column_info = true;
                        }
                    }

                    data_reader.Close();
                    data_reader.Dispose();
                }
            }
            catch (System.Exception e)
            {
                return LuaAPI.luaL_error(L, "c# exception:" + e);
            }
            return 1;
        }

        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int GetAllRows(RealStatePtr L)
        {
            try
            {
                string db_name = LuaAPI.lua_tostring(L, 1);
                string table_name = LuaAPI.lua_tostring(L, 2);
                string query_str = LuaAPI.lua_tostring(L, 3);
                LuaAPI.lua_newtable(L);

                var data_reader = xc.DBManager.Instance.ExecuteSqliteQueryToReader(db_name, table_name, query_str);

                if (data_reader != null)
                {
                    if(data_reader.HasRows)
                    {
                        int field_count = data_reader.FieldCount;
                        int row_index = 1;

                        // 只对SELECT * 的SQL语句进行列信息的缓存和获取
                        bool select_all = false;
                        for (int i = 0; i < query_str.Length && i < 10; ++i)
                        {
                            char c = query_str[i];
                            if (c == '*')
                            {
                                select_all = true;
                                break;
                            }
                        }

                        // 获取可用的列信息
                        bool has_column_info = false;
                        List<xc.DBManager.ColumnInfo> column_info = null;
                        if (select_all)
                        {
                            column_info = xc.DBManager.Instance.GetColumnInfo(table_name);
                            if (column_info != null)
                            {
                                if (column_info.Count != field_count)
                                    has_column_info = false;
                                else
                                    has_column_info = true;
                            }
                            else
                                has_column_info = false;

                            if (!has_column_info)
                                column_info = new List<xc.DBManager.ColumnInfo>();
                        }

                        while (data_reader.Read())
                        {
                            LuaAPI.lua_newtable(L);

                            PackRow(L, data_reader, table_name, has_column_info, column_info, field_count);

                            if (!has_column_info && column_info != null)
                            {
                                xc.DBManager.Instance.SetColumnInfo(table_name, column_info);
                                has_column_info = true;
                            }

                            LuaAPI.xlua_rawseti(L, -2, row_index);
                            row_index++;
                        }
                    }
                    
                    data_reader.Close();
                    data_reader.Dispose();
                }
            }
            catch (System.Exception e)
            {
                return LuaAPI.luaL_error(L, "c# exception:" + e);
            }
            return 1;
        }

        static void PackRow(RealStatePtr L, SqliteDataReader data_reader, string table_name, bool has_column_info, List<xc.DBManager.ColumnInfo> column_info, int field_count)
        {
            for (int i = 0; i < field_count; ++i)
            {
                string field_name = "";
                Type field_type = null;
                if (has_column_info)
                {
                    field_name = column_info[i].name;
                    field_type = column_info[i].type;
                }
                else
                {
                    field_name = data_reader.GetName(i);
                    field_type = data_reader.GetFieldType(i);

                    if(column_info != null)
                    {
                        var info = new xc.DBManager.ColumnInfo();
                        info.name = field_name;
                        info.type = field_type;

                        column_info.Add(info);
                    }
                }

                LuaAPI.lua_pushstring(L, field_name);

                if (field_type.Equals(typeof(string)))
                {
                    var str = data_reader.GetString(i);

                    // 如果指定列有中文，则通过翻译表的文本进行替换
                    var hasChineseChars = xc.DBCharIndex.Instance.HasChineseChars(table_name, field_name);
                    if (hasChineseChars)
                        str = xc.DBTranslate.Instance.GetTranslateText(table_name, str);

                    LuaAPI.lua_pushstring(L, str);
                }
                else if (field_type.IsValueType)
                {
                    LuaAPI.lua_pushnumber(L, Convert.ToDouble(data_reader.GetValue(i)));
                }
                else
                {
                    LuaAPI.lua_pushnil(L);
                }
                LuaAPI.lua_rawset(L, -3);
            }
        }
    }
}
