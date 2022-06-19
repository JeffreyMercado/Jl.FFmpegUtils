namespace Jl.FFmpegUtils;

public interface IAudioStream : IMediaStream
{
    MediaStreamType IMediaStream.MediaType => MediaStreamType.Audio;
    int SampleRate { get; }
    int Channels { get; }
    TimeSpan Duration { get; }
    long Bitrate { get; }

    int? Default { get; }
    int? Forced { get; }
    string? Language { get; }
    string? Title { get; }

    /*
      <!-- audio attributes -->
      <xsd:attribute name="sample_fmt"       type="xsd:string"/>
      <xsd:attribute name="sample_rate"      type="xsd:int"/>
      <xsd:attribute name="channels"         type="xsd:int"/>
      <xsd:attribute name="channel_layout"   type="xsd:string"/>
      <xsd:attribute name="bits_per_sample"  type="xsd:int"/>

      <xsd:attribute name="id"               type="xsd:string"/>
      <xsd:attribute name="r_frame_rate"     type="xsd:string" use="required"/>
      <xsd:attribute name="avg_frame_rate"   type="xsd:string" use="required"/>
      <xsd:attribute name="time_base"        type="xsd:string" use="required"/>
      <xsd:attribute name="start_pts"        type="xsd:long"/>
      <xsd:attribute name="start_time"       type="xsd:float"/>
      <xsd:attribute name="duration_ts"      type="xsd:long"/>
      <xsd:attribute name="duration"         type="xsd:float"/>
      <xsd:attribute name="bit_rate"         type="xsd:int"/>
      <xsd:attribute name="max_bit_rate"     type="xsd:int"/>
      <xsd:attribute name="bits_per_raw_sample" type="xsd:int"/>
      <xsd:attribute name="nb_frames"        type="xsd:int"/>
      <xsd:attribute name="nb_read_frames"   type="xsd:int"/>
      <xsd:attribute name="nb_read_packets"  type="xsd:int"/>
    */
}
