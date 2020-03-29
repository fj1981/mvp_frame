using DevExpress.Mvvm.POCO;

namespace mvp_frame_wpf.Main.ViewModels
{
  public class MainViewModel
  {
    public static MainViewModel Create()
    {
      return ViewModelSource.Create(() => new MainViewModel());
    }
  }
}
