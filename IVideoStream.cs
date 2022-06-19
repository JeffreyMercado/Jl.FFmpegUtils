namespace Jl.FFmpegUtils;

public interface IVideoStream : IMediaStream
{
    MediaStreamType IMediaStream.MediaType => MediaStreamType.Video;
    int Width { get; }
    int Height { get; }
    string Ratio { get; }
    string PixelFormat { get; }
    double Framerate { get; }
    TimeSpan Duration { get; }
    long Bitrate { get; }

    int? Default { get; }
    int? Forced { get; }
    int? Rotation { get; }

    /*
      <!-- video attributes -->
      <xsd:attribute name="width"                type="xsd:int"/>
      <xsd:attribute name="height"               type="xsd:int"/>
      <xsd:attribute name="coded_width"          type="xsd:int"/>
      <xsd:attribute name="coded_height"         type="xsd:int"/>
      <xsd:attribute name="closed_captions"      type="xsd:boolean"/>
      <xsd:attribute name="film_grain"           type="xsd:boolean"/>
      <xsd:attribute name="has_b_frames"         type="xsd:int"/>
      <xsd:attribute name="sample_aspect_ratio"  type="xsd:string"/>
      <xsd:attribute name="display_aspect_ratio" type="xsd:string"/>
      <xsd:attribute name="pix_fmt"              type="xsd:string"/>
      <xsd:attribute name="level"                type="xsd:int"/>
      <xsd:attribute name="color_range"          type="xsd:string"/>
      <xsd:attribute name="color_space"          type="xsd:string"/>
      <xsd:attribute name="color_transfer"       type="xsd:string"/>
      <xsd:attribute name="color_primaries"      type="xsd:string"/>
      <xsd:attribute name="chroma_location"      type="xsd:string"/>
      <xsd:attribute name="field_order"          type="xsd:string"/>
      <xsd:attribute name="refs"                 type="xsd:int"/>
    */
}
