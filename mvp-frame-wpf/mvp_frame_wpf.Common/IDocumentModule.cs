namespace mvp_frame_wpf.Common
{
  public interface IDocumentModule
  {
    string Caption { get; }
    bool IsActive { get; set; }
  }
}
