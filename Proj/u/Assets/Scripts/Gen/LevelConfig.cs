// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: gen/xls2proto/LevelConfig.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace X.Res {

  /// <summary>Holder for reflection information generated from gen/xls2proto/LevelConfig.proto</summary>
  public static partial class LevelConfigReflection {

    #region Descriptor
    /// <summary>File descriptor for gen/xls2proto/LevelConfig.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static LevelConfigReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Ch9nZW4veGxzMnByb3RvL0xldmVsQ29uZmlnLnByb3RvEgVYLlJlcyLnAQoL",
            "TGV2ZWxDb25maWcSEAoIbGV2ZWxfaWQYASABKA0SEgoKbGV2ZWxfdHlwZRgC",
            "IAEoDRISCgpsZXZlbF9uYW1lGAMgASgJEhMKC2xldmVsX3RoZW1lGAQgASgJ",
            "EhUKDWxldmVsX3BpY3R1cmUYBSABKAUSFAoMbGV2ZWxfdW5sb2NrGAYgASgF",
            "EhAKCHJhdGluZ18xGAcgASgFEhAKCHJhdGluZ18yGAggAygFEhAKCHJhdGlu",
            "Z18zGAkgAygFEhMKC2xldmVsX3BpeGVsGAogAygJEhEKCWFkX3B1enpsZRgL",
            "IAEoBSI2ChFMZXZlbENvbmZpZ19BUlJBWRIhCgVpdGVtcxgBIAMoCzISLlgu",
            "UmVzLkxldmVsQ29uZmlnYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::X.Res.LevelConfig), global::X.Res.LevelConfig.Parser, new[]{ "LevelId", "LevelType", "LevelName", "LevelTheme", "LevelPicture", "LevelUnlock", "Rating1", "Rating2", "Rating3", "LevelPixel", "AdPuzzle" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::X.Res.LevelConfig_ARRAY), global::X.Res.LevelConfig_ARRAY.Parser, new[]{ "Items" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class LevelConfig : pb::IMessage<LevelConfig> {
    private static readonly pb::MessageParser<LevelConfig> _parser = new pb::MessageParser<LevelConfig>(() => new LevelConfig());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<LevelConfig> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::X.Res.LevelConfigReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LevelConfig() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LevelConfig(LevelConfig other) : this() {
      levelId_ = other.levelId_;
      levelType_ = other.levelType_;
      levelName_ = other.levelName_;
      levelTheme_ = other.levelTheme_;
      levelPicture_ = other.levelPicture_;
      levelUnlock_ = other.levelUnlock_;
      rating1_ = other.rating1_;
      rating2_ = other.rating2_.Clone();
      rating3_ = other.rating3_.Clone();
      levelPixel_ = other.levelPixel_.Clone();
      adPuzzle_ = other.adPuzzle_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LevelConfig Clone() {
      return new LevelConfig(this);
    }

    /// <summary>Field number for the "level_id" field.</summary>
    public const int LevelIdFieldNumber = 1;
    private uint levelId_;
    /// <summary>
    ///* 关卡ID 
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint LevelId {
      get { return levelId_; }
      set {
        levelId_ = value;
      }
    }

    /// <summary>Field number for the "level_type" field.</summary>
    public const int LevelTypeFieldNumber = 2;
    private uint levelType_;
    /// <summary>
    ///* 关卡类型-1：冒险关卡；2：每日签到关卡 
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint LevelType {
      get { return levelType_; }
      set {
        levelType_ = value;
      }
    }

    /// <summary>Field number for the "level_name" field.</summary>
    public const int LevelNameFieldNumber = 3;
    private string levelName_ = "";
    /// <summary>
    ///* 关卡名称 
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string LevelName {
      get { return levelName_; }
      set {
        levelName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "level_theme" field.</summary>
    public const int LevelThemeFieldNumber = 4;
    private string levelTheme_ = "";
    /// <summary>
    ///* 关卡对应主题 
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string LevelTheme {
      get { return levelTheme_; }
      set {
        levelTheme_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "level_picture" field.</summary>
    public const int LevelPictureFieldNumber = 5;
    private int levelPicture_;
    /// <summary>
    ///* 关卡对应原图 
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int LevelPicture {
      get { return levelPicture_; }
      set {
        levelPicture_ = value;
      }
    }

    /// <summary>Field number for the "level_unlock" field.</summary>
    public const int LevelUnlockFieldNumber = 6;
    private int levelUnlock_;
    /// <summary>
    ///* 解锁类型 
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int LevelUnlock {
      get { return levelUnlock_; }
      set {
        levelUnlock_ = value;
      }
    }

    /// <summary>Field number for the "rating_1" field.</summary>
    public const int Rating1FieldNumber = 7;
    private int rating1_;
    /// <summary>
    ///* 1星 
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Rating1 {
      get { return rating1_; }
      set {
        rating1_ = value;
      }
    }

    /// <summary>Field number for the "rating_2" field.</summary>
    public const int Rating2FieldNumber = 8;
    private static readonly pb::FieldCodec<int> _repeated_rating2_codec
        = pb::FieldCodec.ForInt32(66);
    private readonly pbc::RepeatedField<int> rating2_ = new pbc::RepeatedField<int>();
    /// <summary>
    ///* 2星 
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<int> Rating2 {
      get { return rating2_; }
    }

    /// <summary>Field number for the "rating_3" field.</summary>
    public const int Rating3FieldNumber = 9;
    private static readonly pb::FieldCodec<int> _repeated_rating3_codec
        = pb::FieldCodec.ForInt32(74);
    private readonly pbc::RepeatedField<int> rating3_ = new pbc::RepeatedField<int>();
    /// <summary>
    ///* 3星 
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<int> Rating3 {
      get { return rating3_; }
    }

    /// <summary>Field number for the "level_pixel" field.</summary>
    public const int LevelPixelFieldNumber = 10;
    private static readonly pb::FieldCodec<string> _repeated_levelPixel_codec
        = pb::FieldCodec.ForString(82);
    private readonly pbc::RepeatedField<string> levelPixel_ = new pbc::RepeatedField<string>();
    /// <summary>
    ///* 拼图1 
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<string> LevelPixel {
      get { return levelPixel_; }
    }

    /// <summary>Field number for the "ad_puzzle" field.</summary>
    public const int AdPuzzleFieldNumber = 11;
    private int adPuzzle_;
    /// <summary>
    ///* 广告方块,0表示不使用，1表示使用 
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int AdPuzzle {
      get { return adPuzzle_; }
      set {
        adPuzzle_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as LevelConfig);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(LevelConfig other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (LevelId != other.LevelId) return false;
      if (LevelType != other.LevelType) return false;
      if (LevelName != other.LevelName) return false;
      if (LevelTheme != other.LevelTheme) return false;
      if (LevelPicture != other.LevelPicture) return false;
      if (LevelUnlock != other.LevelUnlock) return false;
      if (Rating1 != other.Rating1) return false;
      if(!rating2_.Equals(other.rating2_)) return false;
      if(!rating3_.Equals(other.rating3_)) return false;
      if(!levelPixel_.Equals(other.levelPixel_)) return false;
      if (AdPuzzle != other.AdPuzzle) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (LevelId != 0) hash ^= LevelId.GetHashCode();
      if (LevelType != 0) hash ^= LevelType.GetHashCode();
      if (LevelName.Length != 0) hash ^= LevelName.GetHashCode();
      if (LevelTheme.Length != 0) hash ^= LevelTheme.GetHashCode();
      if (LevelPicture != 0) hash ^= LevelPicture.GetHashCode();
      if (LevelUnlock != 0) hash ^= LevelUnlock.GetHashCode();
      if (Rating1 != 0) hash ^= Rating1.GetHashCode();
      hash ^= rating2_.GetHashCode();
      hash ^= rating3_.GetHashCode();
      hash ^= levelPixel_.GetHashCode();
      if (AdPuzzle != 0) hash ^= AdPuzzle.GetHashCode();
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
      if (LevelId != 0) {
        output.WriteRawTag(8);
        output.WriteUInt32(LevelId);
      }
      if (LevelType != 0) {
        output.WriteRawTag(16);
        output.WriteUInt32(LevelType);
      }
      if (LevelName.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(LevelName);
      }
      if (LevelTheme.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(LevelTheme);
      }
      if (LevelPicture != 0) {
        output.WriteRawTag(40);
        output.WriteInt32(LevelPicture);
      }
      if (LevelUnlock != 0) {
        output.WriteRawTag(48);
        output.WriteInt32(LevelUnlock);
      }
      if (Rating1 != 0) {
        output.WriteRawTag(56);
        output.WriteInt32(Rating1);
      }
      rating2_.WriteTo(output, _repeated_rating2_codec);
      rating3_.WriteTo(output, _repeated_rating3_codec);
      levelPixel_.WriteTo(output, _repeated_levelPixel_codec);
      if (AdPuzzle != 0) {
        output.WriteRawTag(88);
        output.WriteInt32(AdPuzzle);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (LevelId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(LevelId);
      }
      if (LevelType != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(LevelType);
      }
      if (LevelName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(LevelName);
      }
      if (LevelTheme.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(LevelTheme);
      }
      if (LevelPicture != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(LevelPicture);
      }
      if (LevelUnlock != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(LevelUnlock);
      }
      if (Rating1 != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Rating1);
      }
      size += rating2_.CalculateSize(_repeated_rating2_codec);
      size += rating3_.CalculateSize(_repeated_rating3_codec);
      size += levelPixel_.CalculateSize(_repeated_levelPixel_codec);
      if (AdPuzzle != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(AdPuzzle);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(LevelConfig other) {
      if (other == null) {
        return;
      }
      if (other.LevelId != 0) {
        LevelId = other.LevelId;
      }
      if (other.LevelType != 0) {
        LevelType = other.LevelType;
      }
      if (other.LevelName.Length != 0) {
        LevelName = other.LevelName;
      }
      if (other.LevelTheme.Length != 0) {
        LevelTheme = other.LevelTheme;
      }
      if (other.LevelPicture != 0) {
        LevelPicture = other.LevelPicture;
      }
      if (other.LevelUnlock != 0) {
        LevelUnlock = other.LevelUnlock;
      }
      if (other.Rating1 != 0) {
        Rating1 = other.Rating1;
      }
      rating2_.Add(other.rating2_);
      rating3_.Add(other.rating3_);
      levelPixel_.Add(other.levelPixel_);
      if (other.AdPuzzle != 0) {
        AdPuzzle = other.AdPuzzle;
      }
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
            LevelId = input.ReadUInt32();
            break;
          }
          case 16: {
            LevelType = input.ReadUInt32();
            break;
          }
          case 26: {
            LevelName = input.ReadString();
            break;
          }
          case 34: {
            LevelTheme = input.ReadString();
            break;
          }
          case 40: {
            LevelPicture = input.ReadInt32();
            break;
          }
          case 48: {
            LevelUnlock = input.ReadInt32();
            break;
          }
          case 56: {
            Rating1 = input.ReadInt32();
            break;
          }
          case 66:
          case 64: {
            rating2_.AddEntriesFrom(input, _repeated_rating2_codec);
            break;
          }
          case 74:
          case 72: {
            rating3_.AddEntriesFrom(input, _repeated_rating3_codec);
            break;
          }
          case 82: {
            levelPixel_.AddEntriesFrom(input, _repeated_levelPixel_codec);
            break;
          }
          case 88: {
            AdPuzzle = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  public sealed partial class LevelConfig_ARRAY : pb::IMessage<LevelConfig_ARRAY> {
    private static readonly pb::MessageParser<LevelConfig_ARRAY> _parser = new pb::MessageParser<LevelConfig_ARRAY>(() => new LevelConfig_ARRAY());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<LevelConfig_ARRAY> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::X.Res.LevelConfigReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LevelConfig_ARRAY() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LevelConfig_ARRAY(LevelConfig_ARRAY other) : this() {
      items_ = other.items_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LevelConfig_ARRAY Clone() {
      return new LevelConfig_ARRAY(this);
    }

    /// <summary>Field number for the "items" field.</summary>
    public const int ItemsFieldNumber = 1;
    private static readonly pb::FieldCodec<global::X.Res.LevelConfig> _repeated_items_codec
        = pb::FieldCodec.ForMessage(10, global::X.Res.LevelConfig.Parser);
    private readonly pbc::RepeatedField<global::X.Res.LevelConfig> items_ = new pbc::RepeatedField<global::X.Res.LevelConfig>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::X.Res.LevelConfig> Items {
      get { return items_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as LevelConfig_ARRAY);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(LevelConfig_ARRAY other) {
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
    public void MergeFrom(LevelConfig_ARRAY other) {
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
