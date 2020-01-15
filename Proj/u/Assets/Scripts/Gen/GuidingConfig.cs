// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: gen/xls2proto/GuidingConfig.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace X.Res {

  /// <summary>Holder for reflection information generated from gen/xls2proto/GuidingConfig.proto</summary>
  public static partial class GuidingConfigReflection {

    #region Descriptor
    /// <summary>File descriptor for gen/xls2proto/GuidingConfig.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static GuidingConfigReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CiFnZW4veGxzMnByb3RvL0d1aWRpbmdDb25maWcucHJvdG8SBVguUmVzIlAK",
            "DUd1aWRpbmdDb25maWcSDwoHZnVuY19pZBgBIAEoDRIOCgZvcFR5cGUYAiAD",
            "KAUSDgoGb3BTdXAxGAMgAygFEg4KBm9wU3VwMhgEIAMoBSI6ChNHdWlkaW5n",
            "Q29uZmlnX0FSUkFZEiMKBWl0ZW1zGAEgAygLMhQuWC5SZXMuR3VpZGluZ0Nv",
            "bmZpZ2IGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::X.Res.GuidingConfig), global::X.Res.GuidingConfig.Parser, new[]{ "FuncId", "OpType", "OpSup1", "OpSup2" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::X.Res.GuidingConfig_ARRAY), global::X.Res.GuidingConfig_ARRAY.Parser, new[]{ "Items" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class GuidingConfig : pb::IMessage<GuidingConfig> {
    private static readonly pb::MessageParser<GuidingConfig> _parser = new pb::MessageParser<GuidingConfig>(() => new GuidingConfig());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GuidingConfig> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::X.Res.GuidingConfigReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GuidingConfig() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GuidingConfig(GuidingConfig other) : this() {
      funcId_ = other.funcId_;
      opType_ = other.opType_.Clone();
      opSup1_ = other.opSup1_.Clone();
      opSup2_ = other.opSup2_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GuidingConfig Clone() {
      return new GuidingConfig(this);
    }

    /// <summary>Field number for the "func_id" field.</summary>
    public const int FuncIdFieldNumber = 1;
    private uint funcId_;
    /// <summary>
    ///* ����id 
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint FuncId {
      get { return funcId_; }
      set {
        funcId_ = value;
      }
    }

    /// <summary>Field number for the "opType" field.</summary>
    public const int OpTypeFieldNumber = 2;
    private static readonly pb::FieldCodec<int> _repeated_opType_codec
        = pb::FieldCodec.ForInt32(18);
    private readonly pbc::RepeatedField<int> opType_ = new pbc::RepeatedField<int>();
    /// <summary>
    ///* ������������ 
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<int> OpType {
      get { return opType_; }
    }

    /// <summary>Field number for the "opSup1" field.</summary>
    public const int OpSup1FieldNumber = 3;
    private static readonly pb::FieldCodec<int> _repeated_opSup1_codec
        = pb::FieldCodec.ForInt32(26);
    private readonly pbc::RepeatedField<int> opSup1_ = new pbc::RepeatedField<int>();
    /// <summary>
    ///* ��������1 
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<int> OpSup1 {
      get { return opSup1_; }
    }

    /// <summary>Field number for the "opSup2" field.</summary>
    public const int OpSup2FieldNumber = 4;
    private static readonly pb::FieldCodec<int> _repeated_opSup2_codec
        = pb::FieldCodec.ForInt32(34);
    private readonly pbc::RepeatedField<int> opSup2_ = new pbc::RepeatedField<int>();
    /// <summary>
    ///* ��������2 
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<int> OpSup2 {
      get { return opSup2_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GuidingConfig);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GuidingConfig other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (FuncId != other.FuncId) return false;
      if(!opType_.Equals(other.opType_)) return false;
      if(!opSup1_.Equals(other.opSup1_)) return false;
      if(!opSup2_.Equals(other.opSup2_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (FuncId != 0) hash ^= FuncId.GetHashCode();
      hash ^= opType_.GetHashCode();
      hash ^= opSup1_.GetHashCode();
      hash ^= opSup2_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (FuncId != 0) {
        output.WriteRawTag(8);
        output.WriteUInt32(FuncId);
      }
      opType_.WriteTo(output, _repeated_opType_codec);
      opSup1_.WriteTo(output, _repeated_opSup1_codec);
      opSup2_.WriteTo(output, _repeated_opSup2_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (FuncId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(FuncId);
      }
      size += opType_.CalculateSize(_repeated_opType_codec);
      size += opSup1_.CalculateSize(_repeated_opSup1_codec);
      size += opSup2_.CalculateSize(_repeated_opSup2_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GuidingConfig other) {
      if (other == null) {
        return;
      }
      if (other.FuncId != 0) {
        FuncId = other.FuncId;
      }
      opType_.Add(other.opType_);
      opSup1_.Add(other.opSup1_);
      opSup2_.Add(other.opSup2_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            FuncId = input.ReadUInt32();
            break;
          }
          case 18:
          case 16: {
            opType_.AddEntriesFrom(input, _repeated_opType_codec);
            break;
          }
          case 26:
          case 24: {
            opSup1_.AddEntriesFrom(input, _repeated_opSup1_codec);
            break;
          }
          case 34:
          case 32: {
            opSup2_.AddEntriesFrom(input, _repeated_opSup2_codec);
            break;
          }
        }
      }
    }

  }

  public sealed partial class GuidingConfig_ARRAY : pb::IMessage<GuidingConfig_ARRAY> {
    private static readonly pb::MessageParser<GuidingConfig_ARRAY> _parser = new pb::MessageParser<GuidingConfig_ARRAY>(() => new GuidingConfig_ARRAY());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GuidingConfig_ARRAY> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::X.Res.GuidingConfigReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GuidingConfig_ARRAY() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GuidingConfig_ARRAY(GuidingConfig_ARRAY other) : this() {
      items_ = other.items_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GuidingConfig_ARRAY Clone() {
      return new GuidingConfig_ARRAY(this);
    }

    /// <summary>Field number for the "items" field.</summary>
    public const int ItemsFieldNumber = 1;
    private static readonly pb::FieldCodec<global::X.Res.GuidingConfig> _repeated_items_codec
        = pb::FieldCodec.ForMessage(10, global::X.Res.GuidingConfig.Parser);
    private readonly pbc::RepeatedField<global::X.Res.GuidingConfig> items_ = new pbc::RepeatedField<global::X.Res.GuidingConfig>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::X.Res.GuidingConfig> Items {
      get { return items_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GuidingConfig_ARRAY);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GuidingConfig_ARRAY other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!items_.Equals(other.items_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= items_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      items_.WriteTo(output, _repeated_items_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += items_.CalculateSize(_repeated_items_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GuidingConfig_ARRAY other) {
      if (other == null) {
        return;
      }
      items_.Add(other.items_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            items_.AddEntriesFrom(input, _repeated_items_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code