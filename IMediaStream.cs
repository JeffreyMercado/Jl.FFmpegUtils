namespace Jl.FFmpegUtils;

public interface IMediaStream
{
    IMediaSource Source { get; }
    MediaStreamType MediaType { get; }
    int Index { get; }
    string? CodecName { get; }

#if false
    string? CodecLongName { get; }
    string? Profile { get; }
    string CodecTag { get; }
    string CodecTagString { get; }
    string? ExtraData { get; }
    int? ExtraDataSize { get; }
    string? ExtraDataHash { get; }

    IMediaStreamDisposition Disposition { get; }
    IReadOnlyDictionary<string, string> Tags { get; }
    IReadOnlyList<IMediaStreamSideData> SideDataList { get; }

    /*
      <xsd:attribute name="index"            type="xsd:int" use="required"/>
      <xsd:attribute name="codec_name"       type="xsd:string" />
      <xsd:attribute name="codec_long_name"  type="xsd:string" />
      <xsd:attribute name="profile"          type="xsd:string" />
      <xsd:attribute name="codec_type"       type="xsd:string" />
      <xsd:attribute name="codec_tag"        type="xsd:string" use="required"/>
      <xsd:attribute name="codec_tag_string" type="xsd:string" use="required"/>
      <xsd:attribute name="extradata"        type="xsd:string" />
      <xsd:attribute name="extradata_size"   type="xsd:int"    />
      <xsd:attribute name="extradata_hash"   type="xsd:string" />
    */

    public interface IMediaStreamDisposition
    {
        /*
          <xsd:attribute name="default"          type="xsd:int" use="required" />
          <xsd:attribute name="dub"              type="xsd:int" use="required" />
          <xsd:attribute name="original"         type="xsd:int" use="required" />
          <xsd:attribute name="comment"          type="xsd:int" use="required" />
          <xsd:attribute name="lyrics"           type="xsd:int" use="required" />
          <xsd:attribute name="karaoke"          type="xsd:int" use="required" />
          <xsd:attribute name="forced"           type="xsd:int" use="required" />
          <xsd:attribute name="hearing_impaired" type="xsd:int" use="required" />
          <xsd:attribute name="visual_impaired"  type="xsd:int" use="required" />
          <xsd:attribute name="clean_effects"    type="xsd:int" use="required" />
          <xsd:attribute name="attached_pic"     type="xsd:int" use="required" />
          <xsd:attribute name="timed_thumbnails" type="xsd:int" use="required" />
          <xsd:attribute name="captions"         type="xsd:int" use="required" />
          <xsd:attribute name="descriptions"     type="xsd:int" use="required" />
          <xsd:attribute name="metadata"         type="xsd:int" use="required" />
          <xsd:attribute name="dependent"        type="xsd:int" use="required" />
          <xsd:attribute name="still_image"      type="xsd:int" use="required" />
        */
    }

    public interface IMediaStreamSideData
    {
        /*
          <xsd:attribute name="side_data_type"              type="xsd:string"/>
          <xsd:attribute name="side_data_size"              type="xsd:int"   />
        */
    }
#endif
}
