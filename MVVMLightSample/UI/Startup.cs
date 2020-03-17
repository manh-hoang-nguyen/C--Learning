using GalaSoft.MvvmLight.Threading;

namespace UI
{
  public static  class Startup
    {
        public static void Initialize()
        {
            DispatcherHelper.Initialize();
            (new MainWindow()).Show();
        }
    }
}
